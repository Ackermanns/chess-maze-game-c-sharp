using System;
using System.Collections;

namespace ChessMazeGame
{
    public class GameActive : IGame
    {
        public string[,] grid;
        public int xPointer = 0;
        public int yPointer = 0;
        public int prevXPointer = 0;
        public int prevYPointer = 0;
        public int xNextPointer = 0;
        public int yNextPointer = 0;
        public string userMessage = "New Game Set";
        private string transcript = "";
        public int moveCounter = 0;
        public int gridLengthX;
        public int gridLengthY;
        public Part currentPiece;
        private Part nextPiece;
        public Stack moveYList;
        public Stack moveXList;

        public void Move(Direction move)
        {
            //Handles player moves. Only this method is called and player piece management is done within the model
            switch (currentPiece)
            {
                case Part.PlayerOnKing:
                    HandleKingMove(move);
                    break;
                case Part.PlayerOnKnight:
                    HandleKnightMove(move);
                    break;
                case Part.PlayerOnRook:
                    HandleRookMove(move);
                    break;
                case Part.PlayerOnBishop:
                    HandleBishopMove(move);
                    break;
                case Part.PlayerOnQueen:
                    HandleQueenMove(move);
                    break;
            }
        }
        public int GetMoveCount()
        {
            //Returns the player move counter
            return moveCounter;
        }

        public void Undo()
        {
            //Undoes last user move
            if (moveCounter != 0)
            {
                moveCounter--;
                moveYList.Pop();
                moveXList.Pop();
                yNextPointer = Convert.ToInt32(moveYList.Peek());
                xNextPointer = Convert.ToInt32(moveXList.Peek());
                nextPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                SwapNextPlayerPiece(yNextPointer, xNextPointer);
                SwapCurrentPlayerPiece(yPointer, xPointer);
                yPointer = yNextPointer;
                xPointer = xNextPointer;
                currentPiece = (Part)grid[yPointer, xPointer].ToCharArray()[0];
                userMessage = "Undone last move";
                transcript += userMessage + "\n";
            }
            else
            {
                userMessage = "You are at the start";
                transcript += userMessage + "\n";
            }
        }
        public void Restart()
        {
            //Resets game based on current level
            if (moveCounter != 0)
            {
                yNextPointer = 0;
                xNextPointer = 0;
                SwapNextPlayerPiece(yNextPointer, xNextPointer);
                prevXPointer = Convert.ToInt32(moveXList.Peek());
                prevYPointer = Convert.ToInt32(moveYList.Peek());
                SwapCurrentPlayerPiece(prevYPointer, prevXPointer);
                yPointer = 0;
                xPointer = 0;
                moveCounter = 0;
                userMessage = "Game Reset";
                transcript = "";
                moveYList.Clear();
                moveXList.Clear();
                moveYList.Push(0);
                moveXList.Push(0);
                currentPiece = (Part)grid[yPointer, xPointer].ToCharArray()[0];
                nextPiece = (Part)grid[yPointer, xPointer].ToCharArray()[0];
            }
        }
        public bool IsFinished()
        {
            //checks if player marker is on the bottom right square, need to be checked after every move
            if (xPointer == gridLengthX - 1 & yPointer == gridLengthY - 1)
            {
                userMessage = "Game Won";
                transcript += userMessage + "\n";
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Load(string newLevel)
        {
            //Converts the uncompressed string into a 2d array so it can be played in this class
            //NOTE: assumes format e.g. kKK\nKKK\nKKK
            string[] rows = newLevel.Split("\\n");
            gridLengthY = rows.Length;
            gridLengthX = rows[0].Length;
            grid = new string[gridLengthY + 1, gridLengthX + 1];
            //Loads new level to 2d array here
            for (int i = 0; i != gridLengthY; i++)
            {
                for (int j = 0; j != gridLengthX; j++)
                {
                    grid[i, j] = rows[i][j].ToString();
                }
            }
            SwapInStartPlayerPiece();
            moveYList = new Stack();
            moveXList = new Stack();
            moveYList.Push(0);
            moveXList.Push(0);

            moveCounter = 0;
            userMessage = "Next level loaded";
            transcript += userMessage + "\n";
        }
        public string ExportLevelString()
        {
            //Formats the game grid 2D array into string format
            //Assumes a game has successfully loaded
            //Not currently used but useful for when saving files works with other models
            string returnStr = "";
            for (int i = 0; i < gridLengthY; i++)
            {
                for (int j = 0; j < gridLengthX; j++)
                {
                    returnStr += grid[i, j];
                }
                returnStr += "\n";
            }
            returnStr = returnStr.Remove(returnStr.Length - 2); //Remove the last \n
            return returnStr;
        }
        //PIECE MOVE METHODS
        private void HandleKingMove(Direction move)
        {
            //8 possible movements:
            switch (move)
            {
                case (Direction.UpLeft):
                    userMessage = "Not valid up-left move";
                    yNextPointer = yPointer - 1;
                    xNextPointer = xPointer - 1;
                    if (yNextPointer >= 0 & xNextPointer >= 0)
                    {
                        nextPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {

                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            SwapNextPlayerPiece(yNextPointer, xNextPointer);
                            currentPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid up-left move");
                            yPointer = yNextPointer;
                            xPointer = xNextPointer;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.Up):
                    userMessage = "Not valid up move";
                    yNextPointer = yPointer - 1;
                    if (yNextPointer >= 0)
                    {
                        nextPiece = (Part)grid[yNextPointer, xPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xPointer].ToCharArray()[0];
                            CommitChanges("Valid up move");
                            yPointer = yNextPointer;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.UpRight):
                    userMessage = "Not valid up-right move";
                    yNextPointer = yPointer - 1;
                    xNextPointer = xPointer + 1;
                    if (yNextPointer >= 0 & xNextPointer < gridLengthX)
                    {
                        nextPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid up-right move");
                            yPointer = yNextPointer;
                            xPointer = xNextPointer;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.Left):
                    userMessage = "Not valid left move";
                    xNextPointer = xPointer - 1;
                    if (xNextPointer >= 0)
                    {
                        nextPiece = (Part)grid[yPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid left move");
                            xPointer = xNextPointer;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.Right):
                    userMessage = "Not valid right move";
                    xNextPointer = xPointer + 1;
                    if (xNextPointer < gridLengthX)
                    {
                        nextPiece = (Part)grid[yPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid right move");
                            xPointer = xNextPointer;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.DownLeft):
                    userMessage = "Not valid down-left move";
                    yNextPointer = yPointer + 1;
                    xNextPointer = xPointer - 1;
                    if (yNextPointer <= gridLengthY & xNextPointer >= 0)
                    {
                        nextPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid down-left move");
                            yPointer = yNextPointer;
                            xPointer = xNextPointer;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.Down):
                    userMessage = "Not valid down move";
                    yNextPointer = yPointer + 1;
                    if (yNextPointer < gridLengthY)
                    {
                        nextPiece = (Part)grid[yNextPointer, xPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xPointer].ToCharArray()[0];
                            CommitChanges("Valid down move");
                            yPointer = yNextPointer;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.DownRight):
                    userMessage = "Not valid down-right move";
                    yNextPointer = yPointer + 1;
                    xNextPointer = xPointer + 1;
                    if (yNextPointer < gridLengthY & xNextPointer < gridLengthX)
                    {
                        nextPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid down-right move");
                            yPointer = yNextPointer;
                            xPointer = xNextPointer;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
            }
        }
        private void HandleKnightMove(Direction move)
        {
            /*8 possible movements:
            . 0 . 1 .
            7 . . . 2
            . . N . .
            6 . . . 3
            . 5 . 4 .
            FROM ENUM VALUES:
            0: Up
            1: UpRight
            2: Right
            3: DownRight
            4: Down
            5: DownLeft
            6: Left
            7: UpLeft
            */
            switch (move)
            {
                case (Direction.Up):
                    userMessage = "Not valid up-left move";
                    yNextPointer = yPointer - 2;
                    xNextPointer = xPointer - 1;
                    if (yNextPointer >= 0 & xNextPointer >= 0)
                    {
                        nextPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid up-left move");
                            yPointer = yNextPointer;
                            xPointer = xNextPointer;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.UpRight):
                    userMessage = "Not valid up-right move";
                    yNextPointer = yPointer - 2;
                    xNextPointer = xPointer + 1;
                    if (yNextPointer >= 0 & xNextPointer < gridLengthX)
                    {
                        nextPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid up-right move");
                            yPointer = yNextPointer;
                            xPointer = xNextPointer;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.Right):
                    userMessage = "Not valid right-up move";
                    yNextPointer = yPointer - 1;
                    xNextPointer = xPointer + 2;
                    if (yNextPointer >= 0 & xNextPointer < gridLengthX)
                    {
                        nextPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid right-up move");
                            yPointer = yNextPointer;
                            xPointer = xNextPointer;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.DownRight):
                    userMessage = "Not valid right-down move";
                    yNextPointer = yPointer + 1;
                    xNextPointer = xPointer + 2;
                    if (yNextPointer < gridLengthY & xNextPointer < gridLengthX)
                    {
                        nextPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid down-right move");
                            yPointer = yNextPointer;
                            xPointer = xNextPointer;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.Down):
                    userMessage = "Not valid down-right move";
                    yNextPointer = yPointer + 2;
                    xNextPointer = xPointer + 1;
                    if (yNextPointer < gridLengthY & xNextPointer < gridLengthX)
                    {
                        nextPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid down-right move");
                            yPointer = yNextPointer;
                            xPointer = xNextPointer;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.DownLeft):
                    userMessage = "Not valid down-left move";
                    yNextPointer = yPointer + 2;
                    xNextPointer = xPointer - 1;
                    if (yNextPointer < gridLengthY & xNextPointer >= 0)
                    {
                        nextPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid down-left move");
                            yPointer = yNextPointer;
                            xPointer = xNextPointer;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.Left):
                    userMessage = "Not valid left-down move";
                    yNextPointer = yPointer + 1;
                    xNextPointer = xPointer - 2;
                    if (yNextPointer < gridLengthY & xNextPointer >= 0)
                    {
                        nextPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid left-down move");
                            yPointer = yNextPointer;
                            xPointer = xNextPointer;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.UpLeft):
                    userMessage = "Not valid left-up move";
                    yNextPointer = yPointer - 1;
                    xNextPointer = xPointer - 2;
                    if (yNextPointer >= 0 & xNextPointer >= 0)
                    {
                        nextPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid left-up move");
                            yPointer = yNextPointer;
                            xPointer = xNextPointer;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
            }
        }
        private void AdjacentJump(Direction move)
        {
            //Handles adjacent jumps for ROOK and QUEEN moves 
            switch (move)
            {
                case (Direction.Right):
                    userMessage = "Not valid right jump";
                    xNextPointer = xPointer + 1;
                    while (xNextPointer < gridLengthX)
                    {
                        nextPiece = (Part)grid[yPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid right jump");
                            xPointer = xNextPointer;
                            break;
                        }
                        else
                        {
                            xNextPointer += 1;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.Left):
                    userMessage = "Not valid left jump";
                    xNextPointer = xPointer - 1;
                    while (xNextPointer >= 0)
                    {
                        nextPiece = (Part)grid[yPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid left jump");
                            xPointer = xNextPointer;
                            break;
                        }
                        else
                        {
                            xNextPointer -= 1;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.Up):
                    userMessage = "Not valid up jump";
                    yNextPointer = yPointer - 1;
                    while (yNextPointer >= 0)
                    {
                        nextPiece = (Part)grid[yNextPointer, xPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xPointer].ToCharArray()[0];
                            CommitChanges("Valid up jump");
                            yPointer = yNextPointer;
                            break;
                        }
                        else
                        {
                            yNextPointer -= 1;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.Down):
                    userMessage = "Not valid down jump";
                    yNextPointer = yPointer + 1;
                    while (yNextPointer < gridLengthY)
                    {
                        nextPiece = (Part)grid[yNextPointer, xPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xPointer].ToCharArray()[0];
                            CommitChanges("Valid down jump");
                            yPointer = yNextPointer;
                            break;
                        }
                        else
                        {
                            yNextPointer += 1;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
            }
        }
        private void DiagonalJump(Direction move)
        {
            //Handles diagonal jumps for BISHOP and QUEEN moves 
            switch (move)
            {
                case (Direction.UpLeft):
                    userMessage = "Not valid up-left jump";
                    xNextPointer = xPointer - 1;
                    yNextPointer = yPointer - 1;
                    while (xNextPointer >= 0 & yNextPointer >= 0)
                    {
                        nextPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid up-left jump");
                            xPointer = xNextPointer;
                            yPointer = yNextPointer;
                            break;
                        }
                        else
                        {
                            xNextPointer -= 1;
                            yNextPointer -= 1;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.UpRight):
                    userMessage = "Not valid up-right jump";
                    xNextPointer = xPointer + 1;
                    yNextPointer = yPointer - 1;
                    while (xNextPointer < gridLengthX & yNextPointer >= 0)
                    {
                        nextPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid up-right jump");
                            xPointer = xNextPointer;
                            yPointer = yNextPointer;
                            break;
                        }
                        else
                        {
                            xNextPointer += 1;
                            yNextPointer -= 1;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.DownLeft):
                    userMessage = "Not valid down-left jump";
                    xNextPointer = xPointer - 1;
                    yNextPointer = yPointer + 1;
                    while (xNextPointer >= 0 & yNextPointer < gridLengthY)
                    {
                        nextPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid down-left jump");
                            xPointer = xNextPointer;
                            yPointer = yNextPointer;
                            break;
                        }
                        else
                        {
                            xNextPointer -= 1;
                            yNextPointer += 1;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
                case (Direction.DownRight):
                    userMessage = "Not valid down-right jump";
                    xNextPointer = xPointer + 1;
                    yNextPointer = yPointer + 1;
                    while (xNextPointer < gridLengthX & yNextPointer < gridLengthY)
                    {
                        nextPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                        if (nextPiece != Part.Empty)
                        {
                            SwapNextPlayerPiece(yNextPointer, xNextPointer);
                            SwapCurrentPlayerPiece(yPointer, xPointer);
                            currentPiece = (Part)grid[yNextPointer, xNextPointer].ToCharArray()[0];
                            CommitChanges("Valid down-right jump");
                            xPointer = xNextPointer;
                            yPointer = yNextPointer;
                            break;
                        }
                        else
                        {
                            xNextPointer += 1;
                            yNextPointer += 1;
                        }
                    }
                    transcript += userMessage + "\n";
                    break;
            }
        }
        private void HandleRookMove(Direction move)
        {
            //4 possible directions
            switch (move)
            {
                case (Direction.Up):
                    AdjacentJump(Direction.Up);
                    break;
                case (Direction.Right):
                    AdjacentJump(Direction.Right);
                    break;
                case (Direction.Down):
                    AdjacentJump(Direction.Down);
                    break;
                case (Direction.Left):
                    AdjacentJump(Direction.Left);
                    break;
            }
        }
        private void HandleBishopMove(Direction move)
        {
            //4 possible directions
            switch (move)
            {
                case (Direction.UpLeft):
                    DiagonalJump(Direction.UpLeft);
                    break;
                case (Direction.UpRight):
                    DiagonalJump(Direction.UpRight);
                    break;
                case (Direction.DownLeft):
                    DiagonalJump(Direction.DownLeft);
                    break;
                case (Direction.DownRight):
                    DiagonalJump(Direction.DownRight);
                    break;
            }
        }
        private void HandleQueenMove(Direction move)
        {
            //8 possible directions
            switch (move)
            {
                case (Direction.Up):
                    AdjacentJump(Direction.Up);
                    break;
                case (Direction.Right):
                    AdjacentJump(Direction.Right);
                    break;
                case (Direction.Down):
                    AdjacentJump(Direction.Down);
                    break;
                case (Direction.Left):
                    AdjacentJump(Direction.Left);
                    break;
                case (Direction.UpLeft):
                    DiagonalJump(Direction.UpLeft);
                    break;
                case (Direction.UpRight):
                    DiagonalJump(Direction.UpRight);
                    break;
                case (Direction.DownLeft):
                    DiagonalJump(Direction.DownLeft);
                    break;
                case (Direction.DownRight):
                    DiagonalJump(Direction.DownRight);
                    break;
            }
        }
        private void SwapNextPlayerPiece(int y, int x)
        {
            //When the player commits moving to a new valid sport, player marker is added
            //WARNING: DO BEFORE POINTER COMMITS!
            switch (nextPiece)
            {
                case (Part.Bishop):
                    grid[y, x] = "b";
                    break;
                case (Part.Rook):
                    grid[y, x] = "r";
                    break;
                case (Part.King):
                    grid[y, x] = "k";
                    break;
                case (Part.Knight):
                    grid[y, x] = "n";
                    break;
                case (Part.Queen):
                    grid[y, x] = "q";
                    break;
            }
        }

        private void SwapCurrentPlayerPiece(int y, int x)
        {
            //When the player commits to moving to a new spot, the old piece needs to be swapped back in
            //WARNING: DO BEFORE POINTER COMMITS!
            switch (currentPiece)
            {
                case (Part.PlayerOnBishop):
                    grid[y, x] = "B";
                    break;
                case (Part.PlayerOnRook):
                    grid[y, x] = "R";
                    break;
                case (Part.PlayerOnKing):
                    grid[y, x] = "K";
                    break;
                case (Part.PlayerOnKnight):
                    grid[y, x] = "N";
                    break;
                case (Part.PlayerOnQueen):
                    grid[y, x] = "Q";
                    break;
            }
        }
        private void SwapInStartPlayerPiece()
        {
            //When the player commits to moving to a new spot, the old piece needs to be swapped back in
            //WARNING: DO BEFORE POINTER COMMITS!
            switch (grid[yPointer, xPointer].ToString())
            {
                case ("B"):
                    grid[yPointer, xPointer] = "b";
                    break;
                case ("R"):
                    grid[yPointer, xPointer] = "r";
                    break;
                case ("K"):
                    grid[yPointer, xPointer] = "k";
                    break;
                case ("N"):
                    grid[yPointer, xPointer] = "n";
                    break;
                case ("Q"):
                    grid[yPointer, xPointer] = "q";
                    break;
            }
            currentPiece = (Part)grid[yPointer, xPointer].ToCharArray()[0];
            nextPiece = (Part)grid[yPointer, xPointer].ToCharArray()[0];
        }
        public string GetUserMessage()
        {
            //Gets user feedback based on last action
            return userMessage;
        }
        //TESTING FUNCTIONS BELOW
        public void PointerOverride(int newX, int newY)
        {
            //This method is for testing purposes only to create scenarios that test piece movement
            xPointer = newX;
            yPointer = newY;
            SwapCurrentPlayerPiece(newY, newX);
            SwapInStartPlayerPiece();
        }
        public Part GetPlayerPiece()
        {
            //Returns the current piece the player is on, for testing purposes
            return currentPiece;
        }
        public string GetTranscript()
        {
            //Returns the transcript
            return transcript;
        }
        public string GridDisplay()
        {
            //A string output of the grid that lets the developers visually see the 2d array
            string g = "";
            for (int i = 0; i < gridLengthY + 1; i++)
            {
                for (int j = 0; j < gridLengthX + 1; j++)
                {
                    g += grid[i, j] + " ";
                }
                g += "\n";
            }
            return g;
        }
        private void CommitChanges(string errormessage)
        {
            // Commits constant changes between jumps and moves
            userMessage = errormessage;
            prevXPointer = xPointer;
            prevYPointer = yPointer;
            moveCounter += 1;
            moveYList.Push(yNextPointer);
            moveXList.Push(xNextPointer);
        }
    }
}
