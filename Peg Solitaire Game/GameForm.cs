using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace Peg_Solitaire_Game
{
    public partial class GameForm : Form
    {
        //private PegBoard board;
        private Button[,] buttons;
        private GameBase game;
        private int boardSize;
        private string boardType;
        private Point? selectedPeg = null;



        public GameForm()
        {
            InitializeComponent();
        }
        public GameForm(int size, string type, string selectedMode)
        {

            boardSize = size;//Do not delete these, the GenerateBoard function references the value in boardSize. If this constructor never sets the value,
            boardType = type;//GenerateBoard does not work properly. I can't remember if boardType ever gets referenced tbh but I'm leaving it just in case
            InitializeComponent();

            if (selectedMode == "Manual")
            {
                game = new ManualGame(size, type);
            }
            else
            {
                game = new AutomatedGame(size, type);
            }
            //game = new ManualGame(boardSize, boardType); // or AutomatedGame

            GenerateBoard();
            UpdateBoard();
        }

        public void GenerateBoard()
        {
            boardPanel.Controls.Clear();

            buttons = new Button[boardSize, boardSize];

            int cellSize = 50;

            for (int r = 0; r < boardSize; r++)
            {
                for (int c = 0; c < boardSize; c++)
                {
                    Button btn = new Button();

                    btn.Width = cellSize;
                    btn.Height = cellSize;
                    btn.Left = c * cellSize;
                    btn.Top = r * cellSize;

                    btn.Tag = new Point(r, c); // store position

                    btn.Click += Slot_Click;

                    boardPanel.Controls.Add(btn);

                    buttons[r, c] = btn;
                }
            }
        }

        private void UpdateBoard()
        {
            for (int r = 0; r < boardSize; r++)
            {
                for (int c = 0; c < boardSize; c++)
                {
                    switch (game.Board.Board[r, c])
                    {
                        case SlotState.Peg:
                            buttons[r, c].Text = "●";
                            break;

                        case SlotState.Empty:
                            buttons[r, c].Text = "";
                            break;

                        case SlotState.Invalid:
                            buttons[r, c].Visible = false;
                            break;
                    }

                    /*if (selectedPeg.HasValue &&
                        selectedPeg.Value.X == r &&
                        selectedPeg.Value.Y == c)
                    {
                        buttons[r, c].BackColor = Color.Yellow;
                    }
                    else
                    {
                        buttons[r, c].BackColor = DefaultBackColor;
                    }*/
                }
            }
        }

        /*private void Slot_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            Point pos = (Point)btn.Tag;

            int row = pos.X;
            int col = pos.Y;

            HandleMove(row, col);
        }*/
        private void Slot_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Point pos = (Point)btn.Tag;

            if (game is ManualGame manualGame)
            {
                bool moved = manualGame.HandleClick(pos);

                if (moved)
                {
                    UpdateBoard();
                    CheckGameOver();
                }
            }
        }

        private void HandleMove(int row, int col)
        {
            // First click: select a peg
            if (selectedPeg == null)
            {
                if (game.Board.Board[row, col] == SlotState.Peg)
                {
                    selectedPeg = new Point(row, col);
                }
                return;
            }

            // Second click: attempt move
            Point from = selectedPeg.Value;
            Point to = new Point(row, col);

            if (game.Board.IsValidMove(from, to))
            {
                game.Board.MakeMove(from, to);
                UpdateBoard();
                CheckGameOver();
            }

            selectedPeg = null;
        }

        private void CheckGameOver()
        {
            int pegs = game.Board.CountPegs();

            if (pegs == 1)
            {
                ShowEndDialog("You win! Only one peg remains.");
            }
            else if (!game.Board.HasAnyValidMoves())
            {
                ShowEndDialog($"No more moves! Pegs remaining: {pegs}");
            }
        }

        private void ShowEndDialog(string message)
        {
            var result = MessageBox.Show(
                message + "\n\nYes = Start a new game\nNo = Exit\nCancel = Save game",
        "Game Over",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                RestartGame();
            }
            else if (result == DialogResult.Cancel)
            {
                SaveGameFromDialog();
            }
        }

        private void RestartGame()
        {
            StartNewGameForm newGame = new StartNewGameForm();
            newGame.Show();
            this.Close();
        }

        private async void solveButton_Click(object sender, EventArgs e)
        {
            if (game is AutomatedGame autoGame)
            {

                autoGame.ComputeSolution();

                while (!game.IsGameOver())
                {
                    bool moved = autoGame.PlayStep();

                    if (!moved)
                        break;

                    UpdateBoard();
                    await Task.Delay(200);
                }

                CheckGameOver();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            dialog.Title = "Save Peg Solitaire Game";
            dialog.FileName = "pegsolitaire_save.txt";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    game.SaveToFile(dialog.FileName);
                    MessageBox.Show("Game saved successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to save game:\n" + ex.Message);
                }
            }
        }

        private async void loadAutoButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            dialog.Title = "Load Saved Game for Auto Solve";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                string[] lines = File.ReadAllLines(dialog.FileName);
                PegBoard loadedBoard = PegBoard.FromTextLines(lines);

                game = new AutomatedGame(loadedBoard);

                GenerateBoard();
                UpdateBoard();

                if (game is AutomatedGame autoGame)
                {
                    autoGame.ComputeSolution();

                    while (!game.IsGameOver())
                    {
                        bool moved = autoGame.PlayStep();

                        if (!moved)
                            break;

                        UpdateBoard();
                        await Task.Delay(200);
                    }

                    CheckGameOver();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load saved game:\n" + ex.Message);
            }
        }

        private void saveReplayButton_Click(object sender, EventArgs e)
        {
            using SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            dialog.Title = "Save Replay";
            dialog.FileName = "pegsolitaire_replay.txt";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string modeName = game is AutomatedGame ? "Automated" : "Manual";
                    game.SaveReplayToFile(dialog.FileName, modeName);
                    MessageBox.Show("Replay saved successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to save replay:\n" + ex.Message);
                }
            }
        }

        private async void loadReplayButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            dialog.Title = "Load Replay";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                ReplayData replay = ReplayData.LoadFromFile(dialog.FileName);

                game = new AutomatedGame(replay.Size, replay.Type);
                GenerateBoard();
                UpdateBoard();

                if (game is AutomatedGame autoGame)
                {
                    autoGame.LoadReplayMoves(replay.Moves);

                    while (autoGame.PlayReplayStep())
                    {
                        UpdateBoard();
                        await Task.Delay(200);
                    }

                    CheckGameOver();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load replay:\n" + ex.Message);
            }
        }

        private void shuffleButton_Click(object sender, EventArgs e)
        {
            if (game == null)
                return;

            // Optional: reset history before shuffle
           // game = new ManualGame(game.Board.Size, game.Board.BoardType);

            game.Shuffle(3);  // number of random moves

            UpdateBoard();
        }

        private void SaveGameFromDialog()
        {
            using SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            dialog.Title = "Save Peg Solitaire Game";
            dialog.FileName = "pegsolitaire_save.txt";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    game.SaveReplayToFile(dialog.FileName, game is AutomatedGame ? "Automated" : "Manual");
                    MessageBox.Show("Game saved successfully.", "Save Complete",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ShowPostSaveDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to save game:\n" + ex.Message,
                        "Save Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    ShowEndDialog("The game is still over.");
                }
            }
            else
            {
                ShowEndDialog("The game is still over.");
            }
        }

        private void ShowPostSaveDialog()
        {
            var result = MessageBox.Show(
                "What would you like to do next?\n\nYes = Start a new game\nNo = Exit",
                "Game Saved",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                RestartGame();
            }
            else if (result == DialogResult.No)//Do not remove else if block, 
            {                                  //Despite seeming redundant, program doesn't work correctly otherwise
                Application.Exit();
            }
            else 
            {
                Application.Exit();
            }
        }
        /*private async void solveButton_Click(object sender, EventArgs e)
        {
            if (game is AutomatedGame autoGame)
            {
                while (!game.IsGameOver())
                {
                    bool moved = autoGame.PlayStep();

                    if (!moved)
                        break;

                    UpdateBoard();
                    await Task.Delay(200);
                }

                CheckGameOver();
            }
        }*/
    }
}
