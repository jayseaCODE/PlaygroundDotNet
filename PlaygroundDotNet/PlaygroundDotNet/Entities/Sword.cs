using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet
{
    public class Sword : IWeapon
    {
        private int _damage;
        public int Damage => _damage;
        private int _armourDamage;
        public int ArmourDamage => _armourDamage;

        public Sword(int damage, int armourDamage)
        {
            _damage = damage;
            _armourDamage = armourDamage;
        }

        public void Attack(IEnemy enemy)
        {
            enemy.TakeDamage(_damage, _armourDamage);
        }
    }
}
