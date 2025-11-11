namespace PolinemaNegeriMalang.AmartaBinangun.Core.Combat
{
    using System;
    using UnityEngine;

    [CreateAssetMenu(fileName = "CommandData", menuName = "ScriptableObjects/Combat/AttackData", order = 0)]
    public class AttackData : ScriptableObject
    {
        public int Damage;
        public int NeededCharge;
        public AreaOfAttackDTO AreaOfAttack;


    }
    
    [Serializable]
    public struct AreaOfAttackDTO
    {
        /// <summary>
        /// Positive value is used for front position relative to character heading
        /// </summary>
        public int[] RelativeIndices;
    }
}