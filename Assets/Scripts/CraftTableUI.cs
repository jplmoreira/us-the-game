using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftTableUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Inventory.ins.CraftAdded += AddCraftUI;
		Inventory.ins.CraftRemoved += RemoveCraftUI;
	}

	void AddCraftUI(object sender, InventoryEventArgs e) {
		Transform craftItems = transform.Find ("CraftingTable").GetChild (0);
		foreach (Transform slot in craftItems) {
			Image image = slot.GetChild (0).GetComponent<Image> ();
			CraftItemHandler craftItem = slot.GetComponent<CraftItemHandler> ();
			if (!image.enabled) {
				image.enabled = true;
				image.sprite = e.Item.Image;
				craftItem.item = e.Item;
				break;
			}
		}
	}

	void RemoveCraftUI(object sender, InventoryEventArgs e) {
		Transform craftItems = transform.Find ("CraftingTable").GetChild (0);
		foreach (Transform slot in craftItems) {
			Image image = slot.GetChild (0).GetComponent<Image> ();
			CraftItemHandler craftItem = slot.GetComponent<CraftItemHandler> ();
			if (craftItem.item.Equals(e.Item)) {
                image.sprite = null;
                image.enabled = false;
				craftItem.item = null;
				break;
			}
		}
	}
}
