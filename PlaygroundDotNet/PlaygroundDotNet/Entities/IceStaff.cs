using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet
{
    public class IceStaff : IStaff
    {
        private int _paralyzedRoundDuration;
        private int _damageOutputOverTime;
        public int DamageOutputOvertime => _damageOutputOverTime;
        private int _damage;
        public int Damage => _damage;

        public IceStaff(int damage, int iceDamage, int paralyzedRoundDuration)
        {
            _damage = damage;
            _damageOutputOverTime = iceDamage;
            _paralyzedRoundDuration = paralyzedRoundDuration;
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
            enemy.OvertimeDamageTaken = -_damageOutputOverTime;
            enemy.Paralyzed = true;
            enemy.ParalyzedRoundsDuration = _paralyzedRoundDuration;
        }
    }
}
