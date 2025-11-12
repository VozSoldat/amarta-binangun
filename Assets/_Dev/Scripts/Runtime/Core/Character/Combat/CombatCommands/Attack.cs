using System;
using System.Linq;
using DG.Tweening;
using PolinemaNegeriMalang.AmartaBinangun.Core.Flip;
using PolinemaNegeriMalang.AmartaBinangun.Core.SequenceSystem;
using UnityEngine;
using VozSoldat.CommandPattern;

namespace PolinemaNegeriMalang.AmartaBinangun.Core.Combat
{
    public abstract class Attack : ScriptableObject
    {
        public Action OnAttackStart;
        public Action OnAttackEnd;
        [SerializeField]
        protected AttackData _data;
        // public AttackData Data{ get; private set; }

        // public Attack(Transform characterTransform, AttackData data)
        // {
        //     _characterTransform = characterTransform;
        //     _data = data;
        // }

        /// <summary>
        /// Execute command
        /// </summary>
        public virtual void Execute(TargetGetter targetGetter)
        {
            Debug.Log("[Attack] Attack");
            var targettedOccupants = targetGetter.GetTargetOccupants(_data).ToList();
            if (targettedOccupants.Count == 0)
            {
                Debug.Log("[Attack] Tidak ada target");
            }

            OnAttackStart?.Invoke();

            targettedOccupants.ForEach(o =>
            {
                if (o != null)
                    o.GetComponent<IDamagable>().ApplyDamage(_data.Damage);
            });

            OnAttackEnd?.Invoke();
        }
    }
}