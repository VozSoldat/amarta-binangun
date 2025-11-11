namespace PolinemaNegeriMalang.AmartaBinangun.Core.Combat
{
    using System.Collections;
    using System.Linq;
    using UnityEngine;
    
    public class DealController : MonoBehaviour {
        [SerializeField] private TargetGetter _targetGetter;

        [Header("Attack Commands")]

        [SerializeField] private AttackRegistry _attackRegistry;
        public void Attack()
        {
            // _attackRegistry.Registry.FirstOrDefault(r => r._attackEnum == AttackEnum.Claw)._attack.Execute();

            var attack = _attackRegistry.GetAttack(AttackEnum.Claw);

            // var targettedOccupants = _targetGetter.GetTargetOccupants(attack.Data);
            attack.Execute(targetGetter: _targetGetter);
            Debug.Log("[DealController] Attack");
        }
    }
}