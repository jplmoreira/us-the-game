using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private const int SLOTS = 9;
	private List<IIventoryItem>[] mItems = new List<IIventoryItem>[4];
    public event EventHandler<InventoryEventArgs> ItemAdded;
	public static Inventory ins;
	public int currP;

	void Awake() {
		ins = this;
		mItems [0] = new List<IIventoryItem> ();
		mItems [1] = new List<IIventoryItem> ();
		mItems [2] = new List<IIventoryItem> ();
		mItems [3] = new List<IIventoryItem> ();
		currP = 0;
		CharacterSwap.ins.CharSwap += SwapEvent;
	}

    public void AddItem(IIventoryItem item) {
		if  (mItems[currP].Count < SLOTS) {
			mItems[currP].Add(item);
			item.OnPickup();
			if (ItemAdded != null) {
				ItemAdded (this, new InventoryEventArgs (item));
			}
        }
    }

	private void SwapEvent(object sender, CharacterSwapArgs e) {
		StartCoroutine (UpdateInventory (e.Num));
	}

	IEnumerator UpdateInventory(int currChar) {
		yield return new WaitForSeconds(0.1f);
		currP = currChar - 1;
		foreach (IIventoryItem item in mItems[currP]) {
			if (ItemAdded != null)
				ItemAdded (this, new InventoryEventArgs (item));
		}
	}
}
