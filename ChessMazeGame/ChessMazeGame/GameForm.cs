using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace ChessMazeGame
{
    public partial class GameForm : Form
    {
        // Model objects
        private GameLoader _load;
        private GameActive _chess;

        // Form objects
        private int gridX;
        private int gridY;
        const double VERSION = 1.0;
        private PictureBox p;
        PictureBox[,] PicBoxList;

        public GameForm(GameLoader load, GameActive chess)
        {
            this._load = load;
            this._chess = chess;
            InitializeComponent();

            Text = $"Game Version: {VERSION}";
        }

        private void LoadNewLevel(string FileName)
        {
            try
            {
                //Load new file into Model
                _chess.Restart();
                string gameStr = _load.Load(FileName);
                _chess.Load(gameStr);

                // Enable buttons
                this.ButtonUpLeft.Enabled = true;
                this.ButtonUp.Enabled = true;
                this.ButtonUpRight.Enabled = true;
                this.ButtonLeft.Enabled = true;
                this.ButtonRight.Enabled = true;
                this.ButtonDownLeft.Enabled = true;
                this.ButtonDown.Enabled = true;
                this.ButtonDownRight.Enabled = true;
                this.ButtonUndo.Enabled = true;
                this.ButtonReset.Enabled = true;


                // Set new form values and state
                gridX = _chess.gridLengthX;
                gridY = _chess.gridLengthY;
                PicBoxList = new PictureBox[gridY + 1, gridX + 1];

                //Delete old table
                Controls.Remove(TableGame);

                //Setup new table
                TableGame = new System.Windows.Forms.TableLayoutPanel();
                TableGame.ColumnCount = gridX;
                for (int i = 0; i < gridX; i++)
                {
                    TableGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
                }
                TableGame.Location = new System.Drawing.Point(200, 100);
                TableGame.Name = "TableGame";
                TableGame.RowCount = gridY;
                for (int i = 0; i < gridY; i++)
                {
                    TableGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
                }
                int sizeX = 68 * gridX;
                int sizeY = 68 * gridY;
                TableGame.Size = new System.Drawing.Size(sizeX, sizeY);
                TableGame.TabIndex = 2;
                Controls.Add(TableGame);

                //Populates Table with blank PictureBox objects
                for (int i = 0; i < gridY; i++)
                {
                    for (int j = 0; j < gridX; j++)
                    {
                        //create obj here
                        p = new PictureBox
                        {
                            Name = $"{i},{j}",
                            Size = new Size(68, 68),
                            Image = ChessMazeGame.Properties.Resources.PlayerOnPawn,
                        };
                        PicBoxList[i, j] = p;
                        TableGame.Controls.Add(p, j, i);
                    }
                }

                //Update form Displays
                for (int i = 0; i < gridX; i++)
                {
                    for (int j = 0; j < gridY; j++)
                    {
                        UpdateGameTableSpot(i, j);
                    }
                }
                switch (_chess.currentPiece)
                {
                    case Part.PlayerOnKing:
                        CurrentPiece.Text = "King";
                        break;
                    case Part.PlayerOnQueen:
                        CurrentPiece.Text = "Queen";
                        break;
                    case Part.PlayerOnRook:
                        CurrentPiece.Text = "Rook";
                        break;
                    case Part.PlayerOnBishop:
                        CurrentPiece.Text = "Bishop";
                        break;
                }
                MoveCountLabel.Text = "0";
                Feedback.Text = _chess.GetUserMessage();
            }
            catch (Exception e)
            {
                // Cannot read file
                MessageBox.Show("Could not read file");
            }
        }

        private void UpdateGameTableSpot(int spotY, int spotX)
        {
            string piece = _chess.grid[spotY, spotX];
            switch (piece)
            {
                case "K":
                    PicBoxList[spotY,spotX].Image = ChessMazeGame.Properties.Resources.King;
                    break;
                case "E":
                    PicBoxList[spotY, spotX].Image = ChessMazeGame.Properties.Resources.Empty;
                    break;
                case "Q":
                    PicBoxList[spotY, spotX].Image = ChessMazeGame.Properties.Resources.Queen;
                    break;
                case "N":
                    PicBoxList[spotY, spotX].Image = ChessMazeGame.Properties.Resources.Knight;
                    break;
                case "B":
                    PicBoxList[spotY, spotX].Image = ChessMazeGame.Properties.Resources.Bishop;
                    break;
                case "R":
                    PicBoxList[spotY, spotX].Image = ChessMazeGame.Properties.Resources.Rook;
                    break;
                case "k":
                    PicBoxList[spotY, spotX].Image = ChessMazeGame.Properties.Resources.PlayerOnKing;
                    break;
                case "q":
                    PicBoxList[spotY, spotX].Image = ChessMazeGame.Properties.Resources.PlayerOnQueen;
                    break;
                case "n":
                    PicBoxList[spotY, spotX].Image = ChessMazeGame.Properties.Resources.PlayerOnKnight;
                    break;
                case "b":
                    PicBoxList[spotY, spotX].Image = ChessMazeGame.Properties.Resources.PlayerOnBishop;
                    break;
                case "r":
                    PicBoxList[spotY, spotX].Image = ChessMazeGame.Properties.Resources.PlayerOnRook;
                    break;
            }
        }
        public void HandleMoveChange()
        {
            
            //Update initial spot image
            UpdateGameTableSpot(_chess.prevYPointer, _chess.prevXPointer);
            //Update after spot image
            UpdateGameTableSpot(_chess.yPointer, _chess.xPointer);
            //Update labels
            if (_chess.IsFinished() == true)
            {
                MessageBox.Show("You Won!");
            }
            MoveCountLabel.Text = _chess.moveCounter.ToString();
            Feedback.Text = _chess.userMessage;
            switch(_chess.currentPiece)
            {
                case Part.PlayerOnKing:
                    CurrentPiece.Text = "King";
                    break;
                case Part.PlayerOnQueen:
                    CurrentPiece.Text = "Queen";
                    break;
                case Part.PlayerOnRook:
                    CurrentPiece.Text = "Rook";
                    break;
                case Part.PlayerOnBishop:
                    CurrentPiece.Text = "Bishop";
                    break;
            }
        }

        private void ButtonDown_Click(object sender, EventArgs e)
        {
            _chess.Move(Direction.Down);
            HandleMoveChange();
        }

        private void ButtonUp_Click(object sender, EventArgs e)
        {
            _chess.Move(Direction.Up);
            HandleMoveChange();
        }

        private void ButtonLeft_Click(object sender, EventArgs e)
        {
            _chess.Move(Direction.Left);
            HandleMoveChange();
        }

        private void ButtonUpLeft_Click(object sender, EventArgs e)
        {
            _chess.Move(Direction.UpLeft);
            HandleMoveChange();
        }

        private void ButtonUpRight_Click(object sender, EventArgs e)
        {
            _chess.Move(Direction.UpRight);
            HandleMoveChange();
        }

        private void ButtonRight_Click(object sender, EventArgs e)
        {
            _chess.Move(Direction.Right);
            HandleMoveChange();
        }

        private void ButtonDownLeft_Click(object sender, EventArgs e)
        {
            _chess.Move(Direction.DownLeft);
            HandleMoveChange();

        }

        private void ButtonBottomRight_Click(object sender, EventArgs e)
        {
            _chess.Move(Direction.DownRight);
            HandleMoveChange();
        }

        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            _chess.Undo();
            HandleMoveChange();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            _chess.Restart();
            HandleMoveChange();
        }

        private void loadNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Setup File Opner dialog box
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Load New Game";
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Levels";
            open.InitialDirectory = projectDirectory;
            open.ShowDialog();
            LoadNewLevel(open.FileName);
        }

        private void transcriptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_chess.GetTranscript());
        }
    }
}
