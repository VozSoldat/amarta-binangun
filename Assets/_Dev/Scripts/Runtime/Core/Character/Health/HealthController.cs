using PolinemaNegeriMalang.AmartaBinangun.Core.Combat;
using UnityEngine;
using VozSoldat.GlobalVariable;

namespace PolinemaNegeriMalang.AmartaBinangun.Core.Health
{
    public class HealthController : MonoBehaviour, IDamagable
    {
        [SerializeField] private IntVarReference _maxHealth;
        private int _currentHealth;
        void Start()
        {
            _currentHealth = _maxHealth.Value;
        }
        public void ApplyDamage(int damage)
        {
            _currentHealth -= damage;
            Debug.Log("Health: " + _currentHealth);
        }
    }
}