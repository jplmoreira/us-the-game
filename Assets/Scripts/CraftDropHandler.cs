using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftDropHandler : MonoBehaviour, IDropHandler {

	public void OnDrop(PointerEventData eventData) {
		RectTransform craftTab = transform as RectTransform;

		if (RectTransformUtility.RectangleContainsScreenPoint(craftTab, Input.mousePosition)) {
			IIventoryItem item = eventData.pointerDrag.gameObject.GetComponent<ItemDragHandler>().Item;
			if (item != null && !item.Name.Equals("Craft Tool"))
				Inventory.ins.AddCraft(item);
		}
	}
}
