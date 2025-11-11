using DG.Tweening;
using PolinemaNegeriMalang.AmartaBinangun.Core.SequenceSystem;
using UnityEngine;
namespace PolinemaNegeriMalang.AmartaBinangun.Core.Flip
{

    public class CharacterFlipController : MonoBehaviour
    {
        [SerializeField] Transform _transform;
        public void Flip()
        {
            _transform.DORotate(_transform.rotation.eulerAngles + new Vector3(0, 180, 0), 0.2f);

            SequenceManager.Instance?.ProgressSequence();
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