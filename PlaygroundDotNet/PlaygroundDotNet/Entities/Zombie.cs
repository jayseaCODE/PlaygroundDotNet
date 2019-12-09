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
        private readonly int _level;
        private readonly int _damage;
        private readonly int _armourDamage;
        // Properties
        public string Name => "Zombie";
        public int Level => _level;
        public int Armour { get; set; }
        public int Health { get; set; }
        public int Damage => _damage;
        public int ArmourDamage => _armourDamage;
        public int OvertimeDamageTaken { get; set; }
        public bool Paralyzed { get; set; }
        public int ParalyzedRoundsDuration { get; set; }

        public Zombie(int health, int level, int armour)
        {
            _level = level;
            Health = health;
            Armour = armour;
            _damage = level;
            _armourDamage = (level / 2 > 1) ? level / 2 : 1;
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
