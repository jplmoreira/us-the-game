using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftItemHandler : MonoBehaviour {

	[HideInInspector]
	public IIventoryItem item;

	public void RemoveItem() {
		Inventory.ins.RemoveCraft (item);
	}
}
