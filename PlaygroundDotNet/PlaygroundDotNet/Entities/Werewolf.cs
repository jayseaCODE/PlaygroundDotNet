using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet
{
    /// <summary>
    /// Werewolf can implement more interfaces for werewolf-specific functionalities that other Enemies do not have, in the future
    /// </summary>
    public class Werewolf : IEnemy
    {
        // Backing fields
        private int _health;
        private readonly int _level;
        // Properties
        public int Health { get => _health; set => _health = value; }
        public int Level => _level;

        public int OvertimeDamage { get; set; }
        public int Armour { get; set; }
        public bool Paralyzed { get; set; }
        public int ParalyzedRoundsDuration { get; set; }
        public Werewolf(int health, int level)
        {
            _health = health;
            _level = level;
        }
        public void Attack(PrimaryPlayer primaryPlayer)
        {
            Console.WriteLine("Werewolf attacks " + primaryPlayer.Name);
        }

        public void Defend(PrimaryPlayer primaryPlayer)
        {
            Console.WriteLine("Werewolf defends from " + primaryPlayer.Name);
        }
    }
}
