using System;
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
    public GameObject slingShot;

	void Awake() {
		ins = this;
		mItems [0] = new List<IIventoryItem> ();
		mItems [1] = new List<IIventoryItem> ();
		GameObject go = Instantiate (craftingTool);
		mItems [1].Add (go.GetComponent<CraftTool>());
		go.SetActive (false);
		mItems [2] = new List<IIventoryItem> ();
        go = Instantiate(slingShot);
        mItems[2].Add(go.GetComponent<Slingshot>());
        go.SetActive(false);
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
		for (int i = craftTable.Count - 1; i >= 0; i--) {			
			IIventoryItem item = craftTable [i];

			if (CraftRemoved != null)
				CraftRemoved (this, new InventoryEventArgs (item));
            craftTable.RemoveAt(i);
        }
	}

	public void CombineCraft() {
        if (craftTable.Count > 0) {
            string[] ingredients = new string[craftTable.Count];
            IIventoryItem[] items = new IIventoryItem[craftTable.Count];
            for (int i = 0; i < craftTable.Count; i++) {
                ingredients[i] = craftTable[i].Name;
                items[i] = craftTable[i];
            }
            GameObject result = CraftingDatabase.ins.Craft(ingredients);
            if (result != null) {
                ClearCraft();
                foreach (IIventoryItem item in items) {
                    if (ItemRemoved != null)
                        ItemRemoved(this, new InventoryEventArgs(item));
                    mItems[currP].Remove(item);
                    Destroy(item.GetObject(), 1f);
                }
                GameObject realItem = Instantiate(result);
                AddItem(realItem.GetComponent<IIventoryItem>());
                CharacterSwap.ins.DeselectItem(CharacterSwap.ins.currItem);
                GameObject craftingTable = GameObject.Find("HUD").transform.Find("CraftingTable").gameObject;
                craftingTable.SetActive(false);
                StressBar.ins.decrement(20);
            }
        }
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

    IIventoryItem GetItem(string item) {
        foreach (IIventoryItem invItem in mItems[currP]) {
            if (invItem.Name.Equals(item))
                return invItem;
        }
        return null;
    }
}
