using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet.Managers
{
    public class GameBoard
    {
        private PrimaryPlayer _player;
        private EnemyFactory _enemyFactory;

        public GameBoard()
        {
            _player = PrimaryPlayer.Instance;
            _player.Weapon = new Sword(12, 5);
            _enemyFactory = new EnemyFactory();
        }

        public void PlayArea(int level)
        {
            List<IEnemy> enemies = new List<IEnemy>();
            enemies.Add(_enemyFactory.SpawnZombie(level));
            enemies.Add(_enemyFactory.SpawnWerewolf(level));

            foreach(var enemy in enemies)
            {
                Console.WriteLine($"New enemy approaches...");
                Console.WriteLine($"Player: {_player.Health} health, {_player.Armour} armour.");
                Console.WriteLine($"Enemy: {enemy.Health} health, {enemy.Armour} armour.");
                while (enemy.Health > 0  && _player.Health > 0)
                {
                    // Through interface segregation and using abstraction (not concrete implementations), 
                    // we demonstrate the power of loose coupling with the player being able
                    // to attack any enemy (IEnemy) using any weapon (IWeapon)
                    Console.WriteLine("Player attacks " + enemy.Name);
                    _player.Weapon.Attack(enemy);
                    Console.WriteLine($"Enemy: {enemy.Health} health, {enemy.Armour} armour.");
                    //TODO: Add check if Enemy is already dead before attack
                    enemy.Attack(_player);
                    Console.WriteLine($"Player: {_player.Health} health, {_player.Armour} armour.");
                    //TODO: Add check if player is dead
                }
            }
        }
    }
}
