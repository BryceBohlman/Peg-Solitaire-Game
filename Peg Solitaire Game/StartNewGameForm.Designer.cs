namespace Peg_Solitaire_Game
{
    partial class StartNewGameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LineLabel1 = new Label();
            ExampleTextLabel = new Label();
            BoardSizeNumericUpDown = new NumericUpDown();
            SizePromptText = new TextBox();
            BoardTypeInputComboBox = new ComboBox();
            label1 = new Label();
            StartGameButton = new Button();
            ManualAutoComboBox = new ComboBox();
            ManualAutoSelectionLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)BoardSizeNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // LineLabel1
            // 
            LineLabel1.BorderStyle = BorderStyle.FixedSingle;
            LineLabel1.Location = new Point(195, 234);
            LineLabel1.Name = "LineLabel1";
            LineLabel1.Size = new Size(400, 2);
            LineLabel1.TabIndex = 1;
            LineLabel1.Click += label1_Click;
            // 
            // ExampleTextLabel
            // 
            ExampleTextLabel.AutoSize = true;
            ExampleTextLabel.Location = new Point(291, 349);
            ExampleTextLabel.Name = "ExampleTextLabel";
            ExampleTextLabel.Size = new Size(165, 25);
            ExampleTextLabel.TabIndex = 5;
            ExampleTextLabel.Text = "This is example text";
            // 
            // BoardSizeNumericUpDown
            // 
            BoardSizeNumericUpDown.Location = new Point(386, 49);
            BoardSizeNumericUpDown.Name = "BoardSizeNumericUpDown";
            BoardSizeNumericUpDown.Size = new Size(180, 31);
            BoardSizeNumericUpDown.TabIndex = 6;
            BoardSizeNumericUpDown.Value = new decimal(new int[] { 7, 0, 0, 0 });
            BoardSizeNumericUpDown.ValueChanged += BoardSizeSelect_ValueChanged;
            // 
            // SizePromptText
            // 
            SizePromptText.BorderStyle = BorderStyle.None;
            SizePromptText.Location = new Point(195, 49);
            SizePromptText.Name = "SizePromptText";
            SizePromptText.Size = new Size(170, 24);
            SizePromptText.TabIndex = 7;
            SizePromptText.Text = "Choose Board Size";
            // 
            // BoardTypeInputComboBox
            // 
            BoardTypeInputComboBox.FormattingEnabled = true;
            BoardTypeInputComboBox.Items.AddRange(new object[] { "English", "Hexagonal" });
            BoardTypeInputComboBox.Location = new Point(386, 107);
            BoardTypeInputComboBox.Name = "BoardTypeInputComboBox";
            BoardTypeInputComboBox.Size = new Size(182, 33);
            BoardTypeInputComboBox.TabIndex = 8;
            BoardTypeInputComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(195, 115);
            label1.Name = "label1";
            label1.Size = new Size(166, 25);
            label1.TabIndex = 9;
            label1.Text = "Choose Board Type";
            // 
            // StartGameButton
            // 
            StartGameButton.Location = new Point(319, 312);
            StartGameButton.Name = "StartGameButton";
            StartGameButton.Size = new Size(112, 34);
            StartGameButton.TabIndex = 10;
            StartGameButton.Text = "Start";
            StartGameButton.UseVisualStyleBackColor = true;
            StartGameButton.Click += StartGameButton_Click;
            // 
            // ManualAutoComboBox
            // 
            ManualAutoComboBox.FormattingEnabled = true;
            ManualAutoComboBox.Items.AddRange(new object[] { "Manual", "Automatic" });
            ManualAutoComboBox.Location = new Point(386, 170);
            ManualAutoComboBox.Name = "ManualAutoComboBox";
            ManualAutoComboBox.Size = new Size(182, 33);
            ManualAutoComboBox.TabIndex = 11;
            // 
            // ManualAutoSelectionLabel
            // 
            ManualAutoSelectionLabel.AutoSize = true;
            ManualAutoSelectionLabel.Location = new Point(195, 173);
            ManualAutoSelectionLabel.Name = "ManualAutoSelectionLabel";
            ManualAutoSelectionLabel.Size = new Size(136, 25);
            ManualAutoSelectionLabel.TabIndex = 12;
            ManualAutoSelectionLabel.Text = "Manual or Auto";
            // 
            // StartNewGameForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ManualAutoSelectionLabel);
            Controls.Add(ManualAutoComboBox);
            Controls.Add(StartGameButton);
            Controls.Add(label1);
            Controls.Add(BoardTypeInputComboBox);
            Controls.Add(SizePromptText);
            Controls.Add(BoardSizeNumericUpDown);
            Controls.Add(ExampleTextLabel);
            Controls.Add(LineLabel1);
            Name = "StartNewGameForm";
            Text = "Start New Game";
            ((System.ComponentModel.ISupportInitialize)BoardSizeNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label LineLabel1;
        private Label ExampleTextLabel;
        private NumericUpDown BoardSizeInput;
        private TextBox SizePromptText;
        private ComboBox BoardTypeInputComboBox;
        private Label label1;
        private Button StartGameButton;
        private NumericUpDown BoardSizeNumericUpDown;
        private ComboBox ManualAutoComboBox;
        private Label ManualAutoSelectionLabel;
    }
}
