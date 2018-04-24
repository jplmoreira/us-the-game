using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : Interactable, IIventoryItem {

	public void OnPickup () {
		gameObject.SetActive(false);
	}

	public string Name {
		get {
			return "Test item";
		}
	}

	public Sprite _Image = null;
	public Sprite Image {
		get {
			return _Image;
		}
	}

    public void Interact_PickUp() {
        Inventory.ins.AddItem(this);
    }
}
