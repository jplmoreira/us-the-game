using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour {

    public void OnItemClicked() {
        ItemDragHandler dragHandler = transform.GetChild(0).GetComponent<ItemDragHandler>();
        IIventoryItem item = dragHandler.Item;

        if (item != null) {
            Debug.Log(item.Name);
            Inventory.ins.UseItem(item);
            item.OnUse();
        }
    }
}
