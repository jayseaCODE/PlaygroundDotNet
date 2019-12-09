using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet
{
    public interface IEnemy
    {
        string Name { get; }
        int Level { get; }
        int Armour { get; set; }
        int Health { get; set; }
        int OvertimeDamageTaken { get; set; }
        bool Paralyzed { get; set; }
        int ParalyzedRoundsDuration { get; set; }
        void Attack(PrimaryPlayer primaryPlayer);
        void Defend(PrimaryPlayer primaryPlayer);
    }
}
