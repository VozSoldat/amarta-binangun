namespace PolinemaNegeriMalang.AmartaBinangun.Core.Combat
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class AttackSequenceController : MonoBehaviour
    {
        [SerializeField] private DealController dealController;
        public List<AttackEnum> attacks = new List<AttackEnum>();

        public IEnumerator AttackSequence()
        {
            foreach (var attack in attacks)
            {
                dealController.Attack(attack);
                // yield return StartCoroutine(dealController.WaitForAttack());
                yield return new WaitForSeconds(0.5f);
            }

            // sequence progresses after the attack combo all executed
            SequenceSystem.SequenceManager.Instance.ProgressSequence();
            
            yield return null;
        }

        public void StartSequence() => StartCoroutine(AttackSequence());
    }
}