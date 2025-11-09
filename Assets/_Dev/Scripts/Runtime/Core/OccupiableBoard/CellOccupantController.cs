using System;
using UnityEngine;
namespace PolinemaNegeriMalang.AmartaBinangun.Core.OccupiableBoard
{

    public class CellOccupantController : MonoBehaviour
    {
        public Cell CurrentCell;

        [SerializeField]
        public void MoveTo(Cell targetCell)
        {
            if (targetCell == null || targetCell.IsOccupied)
            {
                Debug.Log("Tidak bisa pindah — cell terisi!");
                return;
            }

            // Kosongkan cell lama
            if (CurrentCell != null)
                CurrentCell.ClearOccupant();

            // Isi cell baru
            targetCell.SetOccupant(this);
            Debug.Log("Pindah ke cell " + targetCell.Index);

        }
    }

}