using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable, IIventoryItem {

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

    public void OnPickup() {
        gameObject.SetActive(false);
    }

    public void OnDrop() {
        Transform character = CharacterSwap.ins.currP.transform;
        gameObject.transform.position = character.transform.position;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder += 2;
        gameObject.SetActive(true);
    }

    public virtual void OnUse() {}

    public void Interact_PickUp() {
		Inventory.ins.AddItem(this);
	}
}
