using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Inventory.ins.ItemAdded += AddItemUI;
        Inventory.ins.ItemRemoved += RemoveItemUI;
		CharacterSwap.ins.CharSwap += ResetInvUI;
	}

	private void AddItemUI(object sender, InventoryEventArgs e) {
		Transform inventory = transform.Find ("Inventory");
		foreach (Transform slot in inventory) {
			Image image = slot.GetChild (0).GetChild (0).GetComponent<Image> ();
            ItemDragHandler itemDragHandler = slot.GetChild(0).GetChild(0).GetComponent<ItemDragHandler>();
			if (!image.enabled) {
				image.enabled = true;
				image.sprite = e.Item.Image;
                itemDragHandler.Item = e.Item;
				break;
			}
		}
	}

    private void RemoveItemUI(object sender, InventoryEventArgs e) {
        Transform inventory = transform.Find("Inventory");
        foreach (Transform slot in inventory) {
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
            slot.GetChild(0).GetComponent<ItemClickHandler>().picked = false;
            ItemDragHandler itemDragHandler = slot.GetChild(0).GetChild(0).GetComponent<ItemDragHandler>();
            if (e.Item.Equals(itemDragHandler.Item)) {
                image.enabled = false;
                image.sprite = null;
                itemDragHandler.Item = null;
                break;
            }
        }
    }

	private void ResetInvUI(object sender, CharacterSwapArgs e) {
		Transform inventory = transform.Find ("Inventory");
		foreach (Transform slot in inventory) {
			Image image = slot.GetChild (0).GetChild (0).GetComponent<Image> ();
            slot.GetChild(0).GetComponent<ItemClickHandler>().picked = false;
            if (image.enabled) {
				image.enabled = false;
				image.sprite = null;
			}
		}
	}
}