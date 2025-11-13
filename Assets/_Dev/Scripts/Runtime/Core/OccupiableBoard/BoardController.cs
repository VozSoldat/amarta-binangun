namespace PolinemaNegeriMalang.AmartaBinangun.Core.OccupiableBoard
{
    using UnityEngine;
    using System.Linq;
    using UnityEditor.EditorTools;
    using System;
    using System.Collections.Generic;

    public class BoardController : MonoBehaviour
    {
        [Tooltip("Drag & drop cell 0-4 on Inspector\n Starting from the left to the right")]
        public Cell[] Cells; // drag & drop cell 0-4 di Inspector

        public Cell GetCell(int index)
        {
            if (index < 0 || index >= Cells.Length) return null;
            return Cells[index];
        }

        public Cell GetEmptyCell()
        {
            return Cells.FirstOrDefault(c => !c.IsOccupied);
        }

        public bool IsCellEmpty(int index)
        {
            var cell = GetCell(index);
            return cell != null && !cell.IsOccupied;
        }

        public CellOccupantController GetCellOccupantByIndex(int index)
        {
            var cell = GetCell(index);
            return cell != null ? cell.Occupant : null;
        }
        public CellOccupantController[] GetCellOccupants()
        {
            var cellOccupants = Cells.Where(c => c.IsOccupied).Select(c => c.Occupant).ToArray();
            Debug.Log("Cell Occupants: " + string.Join(", ", cellOccupants.Select(o => o.gameObject.name)));
            return cellOccupants;
        }

        // public NeighboringCellOccupantDTO GetNeighboringCellOccupant(int index)
        // {
        //     // validasi index
        //     var cell = GetCell(index);
        //     if (cell == null)
        //         return new NeighboringCellOccupantDTO();

        //     // tetapkan list untuk neighbor
        //     List<CellOccupantController> leftNeighbors = new();
        //     List<CellOccupantController> rightNeighbors = new();

        //     // cari kiri
        //     if (index - 1 >= 0)
        //     {
        //         var leftCell = GetCell(index - 1);
        //         if (leftCell != null && leftCell.IsOccupied && leftCell.Occupant != null)
        //             leftNeighbors.Add(leftCell.Occupant);
        //     }

        //     // cari kanan
        //     if (index + 1 < Cells.Length)
        //     {
        //         var rightCell = GetCell(index + 1);
        //         if (rightCell != null && rightCell.IsOccupied && rightCell.Occupant != null)
        //             rightNeighbors.Add(rightCell.Occupant);
        //     }

        //     return new NeighboringCellOccupantDTO
        //     {
        //         LeftNeighbors = leftNeighbors.ToArray(),
        //         RightNeighbors = rightNeighbors.ToArray()
        //     };
        // }

        public CellOccupantController[] GetNeighboringCellOccupants(int index)
        {
            var cellOccupants = GetCellOccupants().Where(o => o.CurrentCell.Index != index).ToArray();
            Debug.Log("Cell Occupants: " + string.Join(", ", cellOccupants.Select(o => o.gameObject.name)));
            return cellOccupants;
        }


    }

    [Serializable]
    public struct NeighboringCellOccupantDTO
    {
        public CellOccupantController[] LeftNeighbors;
        public CellOccupantController[] RightNeighbors;
    }

}