using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet.Managers
{
    public class GameBoard
    {
        private PrimaryPlayer _Player;
        private EnemyFactory _EnemyFactory;

        public GameBoard()
        {
            _Player = PrimaryPlayer.Instance;
        }

        public void PlayArea(int level)
        {
            List<IEnemy> enemies = new List<IEnemy>();
            enemies.Add(_EnemyFactory.SpawnZombie(level));
            enemies.Add(_EnemyFactory.SpawnWerewolf(level));
        }
    }
}
