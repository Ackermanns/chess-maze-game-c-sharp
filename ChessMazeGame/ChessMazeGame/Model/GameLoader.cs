using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMazeGame
{
    public class GameLoader : ILoader
    {
        public string Load(string fileName)
        {

            using (StreamReader inputFile = new StreamReader(fileName))
            {
                //NOTE: Assumes that the game string is on line 1 with e.g format: kKK\nKKK\nKKK
                return inputFile.ReadLine();
            }
            
        }
    }
}
