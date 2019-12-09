using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet
{
    public class EnemyFactory
    {
        public Werewolf SpawnWerewolf(int areaLevel)
        {
            if (areaLevel < 5)
            {
                return new Werewolf(100, 10, 8);
            }
            else
            {
                return new Werewolf(100, 20, 15);
            }
        }

        public Zombie SpawnZombie(int areaLevel)
        {
            if (areaLevel < 2)
            {
                return new Zombie(100, 2, 2);
            }
            else
            {
                return new Zombie(100, 10, 5);
            }
        }
    }
}
