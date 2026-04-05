namespace Peg_Solitaire_Game
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            boardPanel = new Panel();
            solveButton = new Button();
            SuspendLayout();
            // 
            // boardPanel
            // 
            boardPanel.AutoScroll = true;
            boardPanel.Location = new Point(12, 12);
            boardPanel.Name = "boardPanel";
            boardPanel.Size = new Size(776, 426);
            boardPanel.TabIndex = 0;
            // 
            // solveButton
            // 
            solveButton.Location = new Point(811, 12);
            solveButton.Name = "solveButton";
            solveButton.Size = new Size(112, 34);
            solveButton.TabIndex = 1;
            solveButton.Text = "Auto Solve";
            solveButton.UseVisualStyleBackColor = true;
            solveButton.Click += solveButton_Click;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 637);
            Controls.Add(solveButton);
            Controls.Add(boardPanel);
            Name = "GameForm";
            Text = "GameForm";
            ResumeLayout(false);
        }

        #endregion

        private Panel boardPanel;
        private Button solveButton;
    }
}