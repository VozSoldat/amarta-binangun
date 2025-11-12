using DG.Tweening;
using PolinemaNegeriMalang.AmartaBinangun.Core.SequenceSystem;
using UnityEngine;
namespace PolinemaNegeriMalang.AmartaBinangun.Core.Flip
{

    public class CharacterFlipController : MonoBehaviour
    {
        [SerializeField] Transform _transform;
        private bool _isFlipping = false;
        public void Flip()
        {
            if (_isFlipping)
            {
                return;
            }

            _isFlipping = true;
            _transform.DORotate(_transform.rotation.eulerAngles + new Vector3(0, 180, 0), 0.2f).OnComplete(() => { _isFlipping = false; });


            SequenceManager.Instance.ProgressSequence();
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