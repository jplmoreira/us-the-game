using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftTool : Item {

	public override void OnUse () {
		GameObject craftingTable = GameObject.Find ("HUD").transform.Find("CraftingTable").gameObject;
		if (CharacterSwap.ins.currP.name.Contains("Player2")) {
			canInteract = !canInteract;
            CharacterSwap.ins.currP.GetComponent<PointClick>().interacting = !CharacterSwap.ins.currP.GetComponent<PointClick>().interacting;
            if (!craftingTable.activeSelf) {
				craftingTable.SetActive (true);
			} else {
				craftingTable.SetActive (false);
			}
		}
	}
}
