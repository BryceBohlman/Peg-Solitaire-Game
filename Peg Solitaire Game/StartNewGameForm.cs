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
            int sizeInput = (int)BoardSizeNumericUpDown.Value;
            string typeInput = BoardTypeInputComboBox.SelectedItem.ToString();
            string manualAutoInput = ManualAutoComboBox.SelectedItem.ToString();

            GameForm game = new GameForm(sizeInput, typeInput, manualAutoInput);
            game.Show();

            this.Hide();
        }
    }
    
}
