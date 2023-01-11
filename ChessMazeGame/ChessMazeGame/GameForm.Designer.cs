namespace ChessMazeGame
{
    partial class GameForm
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
            this.TableGame = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.transcriptToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transcriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GameFeedbackBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Feedback = new System.Windows.Forms.Label();
            this.FeedbackTitle = new System.Windows.Forms.Label();
            this.CurrentPiece = new System.Windows.Forms.Label();
            this.MoveCountLabel = new System.Windows.Forms.Label();
            this.MoveCountLabelTitle = new System.Windows.Forms.Label();
            this.ButtonDown = new System.Windows.Forms.Button();
            this.ButtonUp = new System.Windows.Forms.Button();
            this.ButtonUpRight = new System.Windows.Forms.Button();
            this.ButtonUpLeft = new System.Windows.Forms.Button();
            this.ButtonDownRight = new System.Windows.Forms.Button();
            this.ButtonRight = new System.Windows.Forms.Button();
            this.ButtonLeft = new System.Windows.Forms.Button();
            this.ButtonDownLeft = new System.Windows.Forms.Button();
            this.ButtonUndo = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.GameFeedbackBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableGame
            // 
            this.TableGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.TableGame.Location = new System.Drawing.Point(258, 37);
            this.TableGame.Name = "TableGame";
            this.TableGame.Size = new System.Drawing.Size(50, 22);
            this.TableGame.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.gameToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(837, 24);
            this.menuStrip1.TabIndex = 3;
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadNewToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // loadNewToolStripMenuItem
            // 
            this.loadNewToolStripMenuItem.Name = "loadNewToolStripMenuItem";
            this.loadNewToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.loadNewToolStripMenuItem.Text = "Load New";
            this.loadNewToolStripMenuItem.Click += new System.EventHandler(this.loadNewToolStripMenuItem_Click);
            // 
            // gameToolStripMenuItem1
            // 
            this.gameToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transcriptToolStripMenuItem1});
            this.gameToolStripMenuItem1.Name = "gameToolStripMenuItem1";
            this.gameToolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem1.Text = "Game";
            // 
            // transcriptToolStripMenuItem1
            // 
            this.transcriptToolStripMenuItem1.Name = "transcriptToolStripMenuItem1";
            this.transcriptToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.transcriptToolStripMenuItem1.Text = "Transcript";
            this.transcriptToolStripMenuItem1.Click += new System.EventHandler(this.transcriptToolStripMenuItem1_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // sameToolStripMenuItem
            // 
            this.sameToolStripMenuItem.Name = "sameToolStripMenuItem";
            this.sameToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // transcriptToolStripMenuItem
            // 
            this.transcriptToolStripMenuItem.Name = "transcriptToolStripMenuItem";
            this.transcriptToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // GameFeedbackBox
            // 
            this.GameFeedbackBox.Controls.Add(this.label1);
            this.GameFeedbackBox.Controls.Add(this.Feedback);
            this.GameFeedbackBox.Controls.Add(this.FeedbackTitle);
            this.GameFeedbackBox.Controls.Add(this.CurrentPiece);
            this.GameFeedbackBox.Controls.Add(this.MoveCountLabel);
            this.GameFeedbackBox.Controls.Add(this.MoveCountLabelTitle);
            this.GameFeedbackBox.Location = new System.Drawing.Point(12, 27);
            this.GameFeedbackBox.Name = "GameFeedbackBox";
            this.GameFeedbackBox.Size = new System.Drawing.Size(167, 205);
            this.GameFeedbackBox.TabIndex = 4;
            this.GameFeedbackBox.TabStop = false;
            this.GameFeedbackBox.Text = "Game Feedback";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Current Piece:";
            // 
            // Feedback
            // 
            this.Feedback.AutoSize = true;
            this.Feedback.Location = new System.Drawing.Point(18, 142);
            this.Feedback.Name = "Feedback";
            this.Feedback.Size = new System.Drawing.Size(29, 15);
            this.Feedback.TabIndex = 4;
            this.Feedback.Text = "N/A";
            // 
            // FeedbackTitle
            // 
            this.FeedbackTitle.AutoSize = true;
            this.FeedbackTitle.Location = new System.Drawing.Point(9, 86);
            this.FeedbackTitle.Name = "FeedbackTitle";
            this.FeedbackTitle.Size = new System.Drawing.Size(60, 15);
            this.FeedbackTitle.TabIndex = 3;
            this.FeedbackTitle.Text = "Feedback:";
            // 
            // CurrentPiece
            // 
            this.CurrentPiece.AutoSize = true;
            this.CurrentPiece.Location = new System.Drawing.Point(100, 54);
            this.CurrentPiece.Name = "CurrentPiece";
            this.CurrentPiece.Size = new System.Drawing.Size(29, 15);
            this.CurrentPiece.TabIndex = 2;
            this.CurrentPiece.Text = "N/A";
            // 
            // MoveCountLabel
            // 
            this.MoveCountLabel.AutoSize = true;
            this.MoveCountLabel.Location = new System.Drawing.Point(100, 25);
            this.MoveCountLabel.Name = "MoveCountLabel";
            this.MoveCountLabel.Size = new System.Drawing.Size(29, 15);
            this.MoveCountLabel.TabIndex = 1;
            this.MoveCountLabel.Text = "N/A";
            // 
            // MoveCountLabelTitle
            // 
            this.MoveCountLabelTitle.AutoSize = true;
            this.MoveCountLabelTitle.Location = new System.Drawing.Point(9, 25);
            this.MoveCountLabelTitle.Name = "MoveCountLabelTitle";
            this.MoveCountLabelTitle.Size = new System.Drawing.Size(88, 15);
            this.MoveCountLabelTitle.TabIndex = 0;
            this.MoveCountLabelTitle.Text = "Current Moves:";
            // 
            // ButtonDown
            // 
            this.ButtonDown.Location = new System.Drawing.Point(71, 338);
            this.ButtonDown.Name = "ButtonDown";
            this.ButtonDown.Size = new System.Drawing.Size(38, 23);
            this.ButtonDown.TabIndex = 5;
            this.ButtonDown.Text = "🢃";
            this.ButtonDown.UseVisualStyleBackColor = true;
            this.ButtonDown.Click += new System.EventHandler(this.ButtonDown_Click);
            this.ButtonDown.Enabled = false;
            // 
            // ButtonUp
            // 
            this.ButtonUp.Location = new System.Drawing.Point(71, 259);
            this.ButtonUp.Name = "ButtonUp";
            this.ButtonUp.Size = new System.Drawing.Size(38, 23);
            this.ButtonUp.TabIndex = 6;
            this.ButtonUp.Text = "🢁";
            this.ButtonUp.UseVisualStyleBackColor = true;
            this.ButtonUp.Click += new System.EventHandler(this.ButtonUp_Click);
            this.ButtonUp.Enabled = false;
            // 
            // ButtonUpRight
            // 
            this.ButtonUpRight.Location = new System.Drawing.Point(128, 259);
            this.ButtonUpRight.Name = "ButtonUpRight";
            this.ButtonUpRight.Size = new System.Drawing.Size(38, 23);
            this.ButtonUpRight.TabIndex = 7;
            this.ButtonUpRight.Text = "🢅";
            this.ButtonUpRight.UseVisualStyleBackColor = true;
            this.ButtonUpRight.Click += new System.EventHandler(this.ButtonUpRight_Click);
            this.ButtonUpRight.Enabled = false;
            // 
            // ButtonUpLeft
            // 
            this.ButtonUpLeft.Location = new System.Drawing.Point(12, 259);
            this.ButtonUpLeft.Name = "ButtonUpLeft";
            this.ButtonUpLeft.Size = new System.Drawing.Size(38, 23);
            this.ButtonUpLeft.TabIndex = 8;
            this.ButtonUpLeft.Text = "🢄";
            this.ButtonUpLeft.UseVisualStyleBackColor = true;
            this.ButtonUpLeft.Click += new System.EventHandler(this.ButtonUpLeft_Click);
            this.ButtonUpLeft.Enabled = false;
            // 
            // ButtonDownRight
            // 
            this.ButtonDownRight.Location = new System.Drawing.Point(128, 338);
            this.ButtonDownRight.Name = "ButtonDownRight";
            this.ButtonDownRight.Size = new System.Drawing.Size(38, 23);
            this.ButtonDownRight.TabIndex = 9;
            this.ButtonDownRight.Text = "🢆";
            this.ButtonDownRight.UseVisualStyleBackColor = true;
            this.ButtonDownRight.Click += new System.EventHandler(this.ButtonBottomRight_Click);
            this.ButtonDownRight.Enabled = false;
            // 
            // ButtonRight
            // 
            this.ButtonRight.Location = new System.Drawing.Point(128, 298);
            this.ButtonRight.Name = "ButtonRight";
            this.ButtonRight.Size = new System.Drawing.Size(38, 23);
            this.ButtonRight.TabIndex = 10;
            this.ButtonRight.Text = "🢂";
            this.ButtonRight.UseVisualStyleBackColor = true;
            this.ButtonRight.Click += new System.EventHandler(this.ButtonRight_Click);
            this.ButtonRight.Enabled = false;
            // 
            // ButtonLeft
            // 
            this.ButtonLeft.Location = new System.Drawing.Point(12, 298);
            this.ButtonLeft.Name = "ButtonLeft";
            this.ButtonLeft.Size = new System.Drawing.Size(38, 23);
            this.ButtonLeft.TabIndex = 11;
            this.ButtonLeft.Text = "🢀";
            this.ButtonLeft.UseVisualStyleBackColor = true;
            this.ButtonLeft.Click += new System.EventHandler(this.ButtonLeft_Click);
            this.ButtonLeft.Enabled = false;
            // 
            // ButtonDownLeft
            // 
            this.ButtonDownLeft.Location = new System.Drawing.Point(12, 338);
            this.ButtonDownLeft.Name = "ButtonDownLeft";
            this.ButtonDownLeft.Size = new System.Drawing.Size(38, 23);
            this.ButtonDownLeft.TabIndex = 12;
            this.ButtonDownLeft.Text = "🢇";
            this.ButtonDownLeft.UseVisualStyleBackColor = true;
            this.ButtonDownLeft.Click += new System.EventHandler(this.ButtonDownLeft_Click);
            this.ButtonDownLeft.Enabled = false;
            // 
            // ButtonUndo
            // 
            this.ButtonUndo.Location = new System.Drawing.Point(55, 387);
            this.ButtonUndo.Name = "ButtonUndo";
            this.ButtonUndo.Size = new System.Drawing.Size(75, 23);
            this.ButtonUndo.TabIndex = 14;
            this.ButtonUndo.Text = "Undo";
            this.ButtonUndo.UseVisualStyleBackColor = true;
            this.ButtonUndo.Click += new System.EventHandler(this.ButtonUndo_Click);
            this.ButtonUndo.Enabled = false;
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(55, 428);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 15;
            this.ButtonReset.Text = "Reset";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            this.ButtonReset.Enabled = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 600);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.ButtonUndo);
            this.Controls.Add(this.ButtonDownLeft);
            this.Controls.Add(this.ButtonLeft);
            this.Controls.Add(this.ButtonRight);
            this.Controls.Add(this.ButtonDownRight);
            this.Controls.Add(this.ButtonUpLeft);
            this.Controls.Add(this.ButtonUpRight);
            this.Controls.Add(this.ButtonUp);
            this.Controls.Add(this.ButtonDown);
            this.Controls.Add(this.GameFeedbackBox);
            this.Controls.Add(this.TableGame);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.GameFeedbackBox.ResumeLayout(false);
            this.GameFeedbackBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableGame;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transcriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem1;
        private System.Windows.Forms.GroupBox GameFeedbackBox;
        private System.Windows.Forms.Label MoveCountLabel;
        private System.Windows.Forms.Label MoveCountLabelTitle;
        private System.Windows.Forms.Label CurrentPiece;
        private System.Windows.Forms.Label Feedback;
        private System.Windows.Forms.Label FeedbackTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonDown;
        private System.Windows.Forms.Button ButtonUp;
        private System.Windows.Forms.Button ButtonUpRight;
        private System.Windows.Forms.Button ButtonUpLeft;
        private System.Windows.Forms.Button ButtonDownRight;
        private System.Windows.Forms.Button ButtonRight;
        private System.Windows.Forms.Button ButtonLeft;
        private System.Windows.Forms.Button ButtonDownLeft;
        private System.Windows.Forms.Button ButtonUndo;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.ToolStripMenuItem loadNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transcriptToolStripMenuItem1;
    }
}
