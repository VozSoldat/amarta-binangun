namespace PolinemaNegeriMalang.AmartaBinangun.Core.Combat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    [CreateAssetMenu(fileName = "AttackRegistry", menuName = "ScriptableObjects/Combat/AttackRegistry", order = 0)]
    public class AttackRegistry : ScriptableObject
    {
        public List<AttackRegistryDTO> Registry;

        public Attack GetAttack(AttackEnum attackEnum) => Registry.FirstOrDefault(r => r._attackEnum == attackEnum)._attack;
    }


    [Serializable]
    public struct AttackRegistryDTO
    {
        public AttackEnum _attackEnum;
        public Attack _attack;
    }
}