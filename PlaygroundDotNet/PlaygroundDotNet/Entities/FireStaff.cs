using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet
{
    public class FireStaff : IStaff
    {
        private int _damage;
        public int Damage => _damage;
        private int _damageOutputOvertime;
        public int DamageOutputOvertime => _damageOutputOvertime;

        public FireStaff(int damage, int fireDamage)
        {
            _damage = damage;
            _damageOutputOvertime = fireDamage;
        }

        public void Attack(IEnemy enemy)
        {
            if (enemy.Armour > 0)
            {
                var leftoverArmour = enemy.Armour - _damage;
                if (leftoverArmour < 0)
                {
                    enemy.Armour = 0;
                }
                else
                {
                    enemy.Armour = leftoverArmour;
                }
            }
            else
            {
                enemy.Health -= _damage;
            }
            enemy.OvertimeDamageTaken = _damageOutputOvertime;
        }
    }
}
