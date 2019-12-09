using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet
{
    public interface IStaff : IWeapon
    {
        int DamageOutputOvertime { get; }
    }
}
