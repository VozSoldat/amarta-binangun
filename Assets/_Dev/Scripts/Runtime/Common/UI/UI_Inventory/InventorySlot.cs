using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // Dapatkan GameObject yang di-drop
        GameObject droppedObject = eventData.pointerDrag;
        Item droppedItem = droppedObject.GetComponent<Item>();

        // Jika yang di-drop adalah Item
        if (droppedItem != null)
        {
            // --- LOGIKA UTAMA ---

            // 1. Cek apakah slot ini KOSONG
            if (transform.childCount == 0)
            {
                // Pindahkan item ke slot ini
                droppedItem.transform.SetParent(this.transform);
                droppedItem.transform.localPosition = Vector2.zero;
                // Perbarui slot asal item
                droppedItem.originalParent = this.transform;
            }
            // 2. Cek apakah slot ini SUDAH TERISI
            else
            {
                // Dapatkan item yang sudah ada di slot ini
                Item itemInThisSlot = transform.GetChild(0).GetComponent<Item>();
                Transform originalItemParent = droppedItem.originalParent;

                // Tukar tempat:
                
                // Pindahkan item yang ada di slot ini (itemInThisSlot) ke slot asal item yang di-drop (originalItemParent)
                itemInThisSlot.transform.SetParent(originalItemParent);
                itemInThisSlot.transform.localPosition = Vector2.zero;
                itemInThisSlot.originalParent = originalItemParent; // Update slot asalnya

                // Pindahkan item yang di-drop (droppedItem) ke slot ini
                droppedItem.transform.SetParent(this.transform);
                droppedItem.transform.localPosition = Vector2.zero;
                droppedItem.originalParent = this.transform; // Update slot asalnya
            }
        }
    }
}