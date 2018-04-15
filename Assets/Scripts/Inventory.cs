using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private const int SLOTS = 9;
    private List<IIventoryItem> mItems = new List<IIventoryItem>();
    public event EventHandler<InventoryEventArgs> ItemAdded;

    public void AddItem(IIventoryItem item) {
        if  (mItems.Count < SLOTS) {
            // Add item to inventory
        }
    }
}
