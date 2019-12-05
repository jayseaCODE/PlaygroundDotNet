using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet.Managers
{
    public class GameBoard
    {
        private PrimaryPlayer _Player;

        public GameBoard()
        {
            _Player = PrimaryPlayer.Instance;
        }

    }
}
