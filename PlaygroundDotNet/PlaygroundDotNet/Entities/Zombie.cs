using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet
{
    /// <summary>
    /// Zombie can implement more interfaces for zombie-specific functionalities that other Enemies do not have, in the future
    /// </summary>
    public class Zombie : IEnemy
    {
        // Backing fields
        private int _health;
        private readonly int _level;
        // Properties
        public int Health { get => _health; set => _health = value; }
        public int Level => _level;
        public int Armour { get; set; }
        public int OvertimeDamageTaken { get; set; }
        public bool Paralyzed { get; set; }
        public int ParalyzedRoundsDuration { get; set; }

        public Zombie(int health, int level)
        {
            _health = health;
            _level = level;
        }
        public void Attack(PrimaryPlayer primaryPlayer)
        {
            Console.WriteLine("Zombie attacks " + primaryPlayer.Name);
        }

        public void Defend(PrimaryPlayer primaryPlayer)
        {
            Console.WriteLine("Zombie defends from " + primaryPlayer.Name);
        }
    }
}
