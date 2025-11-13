using UnityEngine;

namespace PolinemaNegeriMalang.AmartaBinangun.Core.Combat
{
    [CreateAssetMenu(fileName = "ClawAttack", menuName = "ScriptableObjects/Combat/ClawAttack")]
    public class ClawAttack : Attack
    {
        // public ClawAttack(Transform characterTransform, AttackData data) : base(characterTransform, data)
        // {
        // }

/// 
        public override void Execute(TargetGetter targetGetter)
        {
            base.Execute(targetGetter);
        }
    }
}