using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Inventory.ins.ItemAdded += AddItemUI;
		CharacterSwap.ins.CharSwap += ResetInvUI;
	}

	private void AddItemUI(object sender, InventoryEventArgs e) {
		Transform inventory = transform.Find ("Inventory");
		foreach (Transform slot in inventory) {
			Image image = slot.GetChild (0).GetChild (0).GetComponent<Image> ();
			if (!image.enabled) {
				image.enabled = true;
				image.sprite = e.Item.Image;
				break;
			}
		}
	}

	private void ResetInvUI(object sender, CharacterSwapArgs e) {
		Transform inventory = transform.Find ("Inventory");
		foreach (Transform slot in inventory) {
			Image image = slot.GetChild (0).GetChild (0).GetComponent<Image> ();
			if (image.enabled) {
				image.enabled = false;
				image.sprite = null;
			}
		}
	}
}