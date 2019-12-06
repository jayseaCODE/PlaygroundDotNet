using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet
{
    public interface IEnemy
    {
        int Health { get; set; }
        int Level { get; }
        int OvertimeDamage { get; set; }
        int Armour { get; set; }
        bool Paralyzed { get; set; }
        int ParalyzedRoundsDuration { get; set; }
        void Attack(PrimaryPlayer primaryPlayer);
        void Defend(PrimaryPlayer primaryPlayer);
    }
}
