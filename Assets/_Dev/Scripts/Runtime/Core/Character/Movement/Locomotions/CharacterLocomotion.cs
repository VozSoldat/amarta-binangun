using DG.Tweening;
using UnityEngine;
namespace PolinemaNegeriMalang.AmartaBinangun.Core.Movement
{

    public class CharacterLocomotion : MonoBehaviour
    {
        [SerializeField] Transform _transform;
        [SerializeField] float _moveDuration = 0.5f;
        [SerializeField] float _cellSize = 1f;
        public Vector3 CurrentPosition
        {
            get; set;
        }

        public void Move(Vector3 direction)
        {
            Vector3 nextPosition = _transform.position + direction;
            _transform.DOMoveX(endValue: _cellSize * nextPosition.x, duration: _moveDuration, snapping: false).OnComplete(() => CurrentPosition = transform.position);

        }


    }
}