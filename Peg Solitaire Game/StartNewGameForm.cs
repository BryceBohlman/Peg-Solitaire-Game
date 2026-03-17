namespace Peg_Solitaire_Game
{
    public partial class StartNewGameForm : Form
    {
        public StartNewGameForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BoardSizeSelect_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            int boardSize = (int)BoardSizeInput.Value;
            string boardType = comboBox1.SelectedItem.ToString();

            GameForm game = new GameForm(boardSize, boardType);
            game.Show();

            this.Hide();
        }
    }
    
}
