namespace PolinemaNegeriMalang.AmartaBinangun.Core.Flip
{
    using UnityEngine;

    public class CharacterFacing : MonoBehaviour
    {
        public Vector3 GetFacingDirection()
        {
            return transform.forward;
        }
    }
}