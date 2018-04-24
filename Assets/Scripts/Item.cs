using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable, IIventoryItem {

	public void OnPickup () {
		gameObject.SetActive(false);
	}

	public string _Name;
	public string Name {
		get {
			return _Name;
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

	public void Interact_Test1() {
		Debug.Log ("Test1");
	}

	public void Interact_Test2() {
		Debug.Log ("Test2");
	}

	public void Interact_Test3() {
		Debug.Log ("Test3");
	}
}
