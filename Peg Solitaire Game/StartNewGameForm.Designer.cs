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
            BoardSizeInput = new NumericUpDown();
            SizePromptText = new TextBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            StartGameButton = new Button();
            ((System.ComponentModel.ISupportInitialize)BoardSizeInput).BeginInit();
            SuspendLayout();
            // 
            // LineLabel1
            // 
            LineLabel1.BorderStyle = BorderStyle.FixedSingle;
            LineLabel1.Location = new Point(195, 173);
            LineLabel1.Name = "LineLabel1";
            LineLabel1.Size = new Size(400, 2);
            LineLabel1.TabIndex = 1;
            LineLabel1.Click += label1_Click;
            // 
            // ExampleTextLabel
            // 
            ExampleTextLabel.AutoSize = true;
            ExampleTextLabel.Location = new Point(287, 246);
            ExampleTextLabel.Name = "ExampleTextLabel";
            ExampleTextLabel.Size = new Size(165, 25);
            ExampleTextLabel.TabIndex = 5;
            ExampleTextLabel.Text = "This is example text";
            // 
            // BoardSizeInput
            // 
            BoardSizeInput.Location = new Point(386, 49);
            BoardSizeInput.Name = "BoardSizeInput";
            BoardSizeInput.Size = new Size(180, 31);
            BoardSizeInput.TabIndex = 6;
            BoardSizeInput.Value = new decimal(new int[] { 7, 0, 0, 0 });
            BoardSizeInput.ValueChanged += BoardSizeSelect_ValueChanged;
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
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "English", "French", "Triangular" });
            comboBox1.Location = new Point(386, 107);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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
            StartGameButton.Location = new Point(314, 209);
            StartGameButton.Name = "StartGameButton";
            StartGameButton.Size = new Size(112, 34);
            StartGameButton.TabIndex = 10;
            StartGameButton.Text = "Start";
            StartGameButton.UseVisualStyleBackColor = true;
            StartGameButton.Click += StartGameButton_Click;
            // 
            // StartNewGameForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(StartGameButton);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(SizePromptText);
            Controls.Add(BoardSizeInput);
            Controls.Add(ExampleTextLabel);
            Controls.Add(LineLabel1);
            Name = "StartNewGameForm";
            Text = "Start New Game";
            ((System.ComponentModel.ISupportInitialize)BoardSizeInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label LineLabel1;
        private Label ExampleTextLabel;
        private NumericUpDown BoardSizeInput;
        private TextBox SizePromptText;
        private ComboBox comboBox1;
        private Label label1;
        private Button StartGameButton;
    }
}
