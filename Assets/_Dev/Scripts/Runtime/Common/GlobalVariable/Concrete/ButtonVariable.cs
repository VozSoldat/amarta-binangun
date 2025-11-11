using UnityEngine;
using UnityEngine.UI;

namespace VozSoldat.GlobalVariable
{
    [CreateAssetMenu(fileName = "ButtonVariable", menuName = "ScriptableObjects/GlobalVariables/ButtonVariable", order = 0)]
    public class ButtonVariable : GlobalVariable<Button, ButtonVariable> { }    
}