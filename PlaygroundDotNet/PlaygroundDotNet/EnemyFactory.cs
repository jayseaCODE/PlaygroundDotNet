using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet
{
    public class EnemyFactory
    {
        // Utilising Object Pooling for our Enemies
        private Stack<Zombie> _zombiesPool = new Stack<Zombie>();
        private Stack<Werewolf> _werewolvesPool = new Stack<Werewolf>();

        private int _areaLevel;
        public int AreaLevel { get => _areaLevel; }

        #region Private methods
        private void PreloadZombie()
        {
            (int count, int health, int level, int armour) = GetZombieStatsForGivenAreaLevel(_areaLevel);
            for (int i = 0; i < count; i++)
            {
                _zombiesPool.Push(new Zombie(health, level, armour));
            }
        }
        private (int count, int health, int level, int armour) GetZombieStatsForGivenAreaLevel(int areaLevel)
        {
            int count = 0, health = 0, level = 0, armour = 0;
            if (areaLevel < 3)
            {
                count = 15;
                health = 66;
                level = 2;
                armour = 13;
            }
            else if (areaLevel >= 3 && areaLevel < 10)
            {
                count = 30;
                health = 90;
                level = 5;
                armour = 20;
            }
            else
            {
                count = 50;
                health = 125;
                level = 10;
                armour = 30;
            }

            return (count, health, level, armour);
        }
        #endregion

        public EnemyFactory(int areaLevel)
        {
            _areaLevel = areaLevel;
            PreloadZombie();
        }

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
        public Zombie SpawnZombie()
        {
            if (_zombiesPool.Count > 0)
            {
                return _zombiesPool.Pop();
            }
            else
            {
                throw new Exception("Zombies pool depleted.");
            }
        }
        public void ResetZombie(Zombie zombie)
        {
            (int count, int health, int level, int armour) = GetZombieStatsForGivenAreaLevel(_areaLevel);
            zombie.Health = health;
            zombie.Armour = armour;
            _zombiesPool.Push(zombie);
        }
    }
}
