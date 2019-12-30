using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet.Interfaces
{
    /// <summary>
    /// Used for the purpose of converting an <see cref="IWeapon"/> to this <see cref="ISpaceWeapon"/> by using a <see cref="Adapters.WeaponAdapter"/>
    /// </summary>
    public interface ISpaceWeapon
    {
        int ImpactDamage { get; }
        int LaserDamage { get; }
        int MissChance { get; }
        int Shoot();
    }
}
