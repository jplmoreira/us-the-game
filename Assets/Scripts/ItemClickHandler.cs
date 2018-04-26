using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour {

    bool picked = false;

    public void OnItemClicked() {
        ItemDragHandler dragHandler = transform.GetChild(0).GetComponent<ItemDragHandler>();
        IIventoryItem item = dragHandler.Item;

        if (item != null) {
            if (!picked) {
                Inventory.ins.SelectItem(item);
                item.OnUse();
                picked = true;
            } else {
                CharacterSwap.ins.DeselectItem(item);
                picked = false;
            }   
        }
    }
}
