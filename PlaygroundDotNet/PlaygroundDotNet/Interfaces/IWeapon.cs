using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet
{
    public interface IWeapon
    {
        int Damage { get; }
        void Attack(IEnemy enemy);
    }
}
