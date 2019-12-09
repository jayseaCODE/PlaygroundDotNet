using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet
{
    public interface IDamageable
    {
        void TakeDamage(int dealtDamage, int dealtArmourDamage);
    }
}
