using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler {

    public IIventoryItem Item { get; set; }

	void Start() {
		CharacterSwap.ins.CharSwap += SwapReset;
	}

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        transform.localPosition = Vector3.zero;
    }

	private void SwapReset(object sender, CharacterSwapArgs e) {
		Item = null;
	}
}
