using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : MonoBehaviour, IIventoryItem {

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

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (1)) {
			if (CharacterSwap.ins.currP.GetComponent<Interact> ().Reachable (this.gameObject))
				Inventory.ins.AddItem (this);
			else
				Debug.Log("Out of reach!");
		}
	}
}
