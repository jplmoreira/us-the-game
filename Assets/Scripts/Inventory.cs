﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private const int SLOTS = 9;
	private List<IIventoryItem>[] mItems = new List<IIventoryItem>[4];
	private List<IIventoryItem> craftTable = new List<IIventoryItem> ();
    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemRemoved;
    public event EventHandler<InventoryEventArgs> ItemSelected;
	public event EventHandler<InventoryEventArgs> CraftAdded;
	public event EventHandler<InventoryEventArgs> CraftRemoved;
    public static Inventory ins;

    public int currP;
	public GameObject craftingTool;

	void Awake() {
		ins = this;
		mItems [0] = new List<IIventoryItem> ();
		mItems [1] = new List<IIventoryItem> ();
		GameObject go = Instantiate (craftingTool);
		mItems [1].Add (go.GetComponent<CraftTool>());
		go.SetActive (false);
		mItems [2] = new List<IIventoryItem> ();
		mItems [3] = new List<IIventoryItem> ();
		currP = 0;
	}

    private void Start() {
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

    public void RemoveItem(IIventoryItem item) {
        if (mItems[currP].Contains(item)) {
            mItems[currP].Remove(item);
            CharacterSwap.ins.DeselectItem(item);
            item.OnDrop();
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider != null)
                collider.enabled = true;

            if (ItemRemoved != null)
                ItemRemoved(this, new InventoryEventArgs(item));
        }
    }

	public void AddCraft(IIventoryItem item) {
		if (!craftTable.Contains(item)) {
			craftTable.Add (item);
			if (CraftAdded != null)
				CraftAdded (this, new InventoryEventArgs (item));
		}
	}

	public void RemoveCraft(IIventoryItem item) {
		if (craftTable.Contains (item)) {
			craftTable.Remove (item);
			if (CraftRemoved != null)
				CraftRemoved (this, new InventoryEventArgs (item));
		}
	}

	public void ClearCraft() {
		Debug.Log ("Clearing crafting table");
		while(craftTable.Count > 0) {			
			IIventoryItem item = craftTable [0];
			craftTable.RemoveAt(0);
			if (CraftRemoved != null)
				CraftRemoved (this, new InventoryEventArgs (item));
		}
	}

	public void CombineCraft() {
		ClearCraft ();
	}

    internal void SelectItem(IIventoryItem item) {

        if (ItemSelected != null)
            ItemSelected(this, new InventoryEventArgs(item));
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
