using DG.Tweening;
using UnityEngine;
namespace PolinemaNegeriMalang.AmartaBinangun.Core.Flip
{

    public class CharacterFlipController : MonoBehaviour
    {
        [SerializeField] Transform _transform;
        public void Flip()
        {
            _transform.DORotate(_transform.rotation.eulerAngles + new Vector3(0, 180, 0), 0.2f);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Flip();
            }
        }
    }
}