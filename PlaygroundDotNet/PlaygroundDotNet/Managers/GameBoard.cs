using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json;

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
        }

        public void PlayArea(int level)
        {
            Console.WriteLine($"Ready to play level {level}?");
            Console.ReadKey();

            _enemyFactory = new EnemyFactory(areaLevel: level);
            List<IEnemy> enemies = new List<IEnemy>();
            enemies.Add(_enemyFactory.SpawnZombie());
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
                if (enemy.GetType() == typeof(Zombie))
                {
                    _enemyFactory.ResetZombie(enemy as Zombie);
                }
            }
        }

        private async Task<IEnumerable<Card>> FetchCards()
        {
            using (var httpClient = new HttpClient())
            {
                var cardsJson = await httpClient.GetStringAsync("https://localhost:44365/api/cards");
                return JsonConvert.DeserializeObject<IEnumerable<Card>>(cardsJson);
            }
        }
    }
}
