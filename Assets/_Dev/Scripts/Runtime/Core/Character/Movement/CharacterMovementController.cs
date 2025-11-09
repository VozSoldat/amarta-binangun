using DG.Tweening;
using PolinemaNegeriMalang.AmartaBinangun.Core.OccupiableBoard;
using UnityEngine;

namespace PolinemaNegeriMalang.AmartaBinangun.Core.Movement
{
    public class CharacterMovementController : MonoBehaviour
    {
        [SerializeField] private float _cellSize = 1; // temporary
        [SerializeField] private float _moveDuration = 1;

        [SerializeField] private CharacterLocomotion _locomotion;
        [SerializeField] private CellOccupantController _cellOccupant;
        [SerializeField] private BoardController _board;
        private void Start()
        {
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                MoveLeft();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                MoveRight();
            }
        }

        public void MoveRight()
        {
            Move(Vector3.right);
        }

        public void MoveLeft()
        {
            Move(Vector3.left);
        }

        private void Move(Vector3 direction )
        {

            if (_cellOccupant.CurrentCell == null) return;

            int newIndex = (int)(_cellOccupant.CurrentCell.Index + direction.x);

            var nextCell = _board.GetCell(newIndex);

            if (nextCell != null && !nextCell.IsOccupied)
            {
                _cellOccupant.MoveTo(nextCell);

                _locomotion.Move(direction);
            }else
            {
                Debug.Log("Tidak bisa pindah — cell terisi!");
            }
        }

    }

}