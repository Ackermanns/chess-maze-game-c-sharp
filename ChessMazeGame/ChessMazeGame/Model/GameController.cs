using System.Collections;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ChessMazeGame
{
    public class GameController
    {
        // Note:    Iview is the console view,
        //          gameView is the Form view

        private readonly IView _view;
        private GameForm _formView;

        public GameController(IView view)
        {
            _view = view;
        }

        public void Go()
        {
            // This is the controller that only includes the model and view (form)
            // Note that IView cannot be used here because of the console window is suppressed by the form
            GameLoader _load = new GameLoader();
            GameActive _chess = new GameActive();
            // Form Run
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameForm(_load, _chess));
        }

        public void GoModel()
        {
            // This is the controller that only includes the model and console view
            // Below is test code of loading a file and interacting with the GameActive model

            _view.Begin();
            _view.Show("Game Start");

            /*
            string gameStr = _load.Load("tests/scenario8.txt");
            _chess.Load(gameStr);
            _chess.PointerOverride(1, 1);
            Console.WriteLine(_chess.GridDisplay());
            _chess.Move(Direction.Down);
            Console.WriteLine(_chess.GetUserMessage());

            string gameStr = _load.Load("tests/scenario1.txt");
            _chess.Load(gameStr);
            Console.WriteLine(_chess.GridDisplay());
            _chess.Move(Direction.Right);
            Console.WriteLine(_chess.GridDisplay());
            _chess.Move(Direction.Down);
            Console.WriteLine(_chess.GridDisplay());
            _chess.Move(Direction.Left);
            
            Console.WriteLine(_chess.GridDisplay());
            _chess.Move(Direction.Up);
            Console.WriteLine(_chess.GetUserMessage());
            Console.WriteLine(_chess.GridDisplay());

            Console.WriteLine(_chess.GetYpointer());
            Console.WriteLine(_chess.GetXpointer());


            //Console.WriteLine(a.Count);
            //_chess.pieceChangeHandler(0);
            //_view.End();
            */
        }
    }
}
