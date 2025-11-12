using System;

namespace PolinemaNegeriMalang.AmartaBinangun.Core.Combat
{
    public interface IDamagable
    {
        void ApplyDamage(int damage);

        Action OnHealthZero{ get; set; }
    }
}