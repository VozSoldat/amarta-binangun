namespace PolinemaNegeriMalang.AmartaBinangun.Core.OccupiableBoard
{
    using UnityEngine;
    using System.Linq;
    using UnityEditor.EditorTools;

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
    }

}