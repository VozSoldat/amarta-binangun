using UnityEngine;

namespace VozSoldat.GlobalVariable
{

    [CreateAssetMenu(fileName = "IntVariable", menuName = "ScriptableObjects/GlobalVariables/IntVariable", order = 0)]
    public class IntVariable : NumericGlobalVariable<int, IntVariable>
    { }
}