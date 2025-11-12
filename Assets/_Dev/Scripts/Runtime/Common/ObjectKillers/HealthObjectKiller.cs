using PolinemaNegeriMalang.AmartaBinangun.Core.Combat;
using PolinemaNegeriMalang.AmartaBinangun.Core.Health;
using UnityEngine;
namespace PolinemaNegeriMalang.AmartaBinangun.Common.ObjectKillers
{

    public class HealthObjectKiller : ObjectKiller
    {
        [SerializeReference]
        public HealthController healthController;
        void OnEnable()
        {
            healthController.OnHealthZero += Kill;
        }
        void OnDisable()
        {
            healthController.OnHealthZero -= Kill;
        }
    }
}