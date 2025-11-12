using System;
using PolinemaNegeriMalang.AmartaBinangun.Core.Combat;
using UnityEngine;
using VozSoldat.GlobalVariable;

namespace PolinemaNegeriMalang.AmartaBinangun.Core.Health
{
    public class HealthController : MonoBehaviour, IDamagable
    {
        [SerializeField] private IntVarReference _maxHealth;
        private int _currentHealth;

        public Action OnHealthZero { get => _onHealthZero; set=> _onHealthZero = value; }
        Action _onHealthZero;

        void Start()
        {
            _currentHealth = _maxHealth.Value;
        }
        public void ApplyDamage(int damage)
        {
            _currentHealth -= damage;
            Debug.Log("Health: " + _currentHealth);

            if (_currentHealth <= 0)
            {
                OnHealthZero.Invoke();
            }
        }
    }
}