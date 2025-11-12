namespace PolinemaNegeriMalang.AmartaBinangun.Core.Combat
{
    using System.Linq;
    using PolinemaNegeriMalang.AmartaBinangun.Core.Flip;
    using PolinemaNegeriMalang.AmartaBinangun.Core.OccupiableBoard;
    using UnityEngine;

    public class TargetGetter : MonoBehaviour
    {
        [SerializeField] private BoardController _boardController;

        [SerializeField] private CellOccupantController _playerOccupantController;

        [SerializeField] private CharacterFacing _characterFacing;

        public CellOccupantController[] GetTargetOccupants(AttackData attackData)
        {
            var neighboringOccupants = _boardController.GetNeighboringCellOccupants(_playerOccupantController.CurrentCell.Index);

            // jumlahkan relative indices dengan index diri
            var absoluteIndices = attackData.AreaOfAttack.RelativeIndices
                .Select(i => _playerOccupantController.CurrentCell.Index + i * Mathf.Sign(_characterFacing.GetFacingDirection().x))
                .ToArray();

            foreach (var index in absoluteIndices)
            {
                Debug.Log("Index: " + index);
            }

            var targettedOccupants = neighboringOccupants.Where(o => absoluteIndices.Contains(o.CurrentCell.Index)).ToArray();

            foreach (var targettedOccupant in targettedOccupants)
            {
                Debug.Log("Target: " + targettedOccupant.gameObject.name);
            }

            return targettedOccupants;
        }
        // public CellOccupantController GetTargetOccupant(CellOccupantController characterOccupantController) => _boardController.GetNeighboringCellOccupant(characterOccupantController.CurrentCell.Index).LeftNeighbors;
    }
}