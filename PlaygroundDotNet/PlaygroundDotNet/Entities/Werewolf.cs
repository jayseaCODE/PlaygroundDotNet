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
        private readonly int _level;
        private readonly int _damage;
        private readonly int _armourDamage;
        // Properties
        public string Name => "Werewolf";
        public int Level => _level;
        public int Armour { get; set; }
        public int Health { get; set; }
        public int Damage => _damage;
        public int ArmourDamage => _armourDamage;
        public int OvertimeDamageTaken { get; set; }
        public bool Paralyzed { get; set; }
        public int ParalyzedRoundsDuration { get; set; }
        public Werewolf(int health, int level, int armour)
        {
            _level = level;
            Armour = armour;
            Health = health;
            _damage = level;
            _armourDamage = (level / 2 > 1) ? level / 2 : 1;
        }
        public void Attack(PrimaryPlayer primaryPlayer)
        {
            Console.WriteLine("Werewolf attacks " + primaryPlayer.Name);
            primaryPlayer.TakeDamage(_damage, _armourDamage);
        }

        public void Defend(PrimaryPlayer primaryPlayer)
        {
            Console.WriteLine("Werewolf defends from " + primaryPlayer.Name);
        }

        public void TakeDamage(int dealtDamage, int dealtArmourDamage)
        {
            if (Armour > 0)
            {
                var leftoverArmour = Armour - dealtArmourDamage;
                if (leftoverArmour < 0)
                {
                    Armour = 0;
                }
                else
                {
                    Armour = leftoverArmour;
                }
            }
            else
            {
                Health -= dealtDamage;
            }
        }
    }
}
