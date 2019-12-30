using PlaygroundDotNet.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet.Adapters
{
    public class WeaponAdapter : IWeapon
    {
        private ISpaceWeapon _spaceWeapon;
        public WeaponAdapter(ISpaceWeapon spaceWeapon)
        {
            _spaceWeapon = spaceWeapon;
        }

        public int Damage => _spaceWeapon.ImpactDamage + _spaceWeapon.LaserDamage;

        public void Attack(IEnemy enemy)
        {
            enemy.Health -= _spaceWeapon.Shoot();
        }
    }
}
