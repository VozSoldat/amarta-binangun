namespace PolinemaNegeriMalang.AmartaBinangun.Common.ObjectKillers
{
    using UnityEngine;
    
    public abstract class ObjectKiller : MonoBehaviour {
        [SerializeField] protected GameObject _objectToKill;
        public  void Kill()
        {
            Destroy(_objectToKill);
        }
    }
}