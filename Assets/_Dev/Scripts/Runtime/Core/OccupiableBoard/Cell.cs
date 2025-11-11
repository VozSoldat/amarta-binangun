    using UnityEngine;
namespace PolinemaNegeriMalang.AmartaBinangun.Core.OccupiableBoard
{

    public class Cell : MonoBehaviour
    {
        public int Index;
        public CellOccupantController Occupant; // siapa yang menempati cell ini

        public bool IsOccupied => Occupant != null;

        public void SetOccupant(CellOccupantController occupant)
        {
            Occupant = occupant;
            if (occupant != null)
                occupant.CurrentCell = this;
        }

        public void ClearOccupant()
        {
            if (Occupant != null)
                Occupant.CurrentCell = null;
            Occupant = null;
        }
    }

}