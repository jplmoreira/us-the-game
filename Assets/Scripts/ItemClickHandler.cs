using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour {

    [HideInInspector]
    public bool picked = false;

    public void OnItemClicked() {
        ItemDragHandler dragHandler = transform.GetChild(0).GetComponent<ItemDragHandler>();
        IIventoryItem item = dragHandler.Item;

        if (item != null) {
            if (!(item.Name != "Slingshot" && item.Name != "Craft Tool" && CharacterSwap.ins.currP.GetComponent<PointClick>().interacting)) {
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
}
