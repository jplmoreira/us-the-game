using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : Item {

	public override void OnUse() {
        if(CharacterSwap.ins.currP.name.Contains("Player3")) {
            CharacterSwap.ins.currP.GetComponent<PointClick>().interacting = !CharacterSwap.ins.currP.GetComponent<PointClick>().interacting;
            Transform arm = CharacterSwap.ins.currP.transform.Find("Arm");
            arm.gameObject.SetActive(!arm.gameObject.activeSelf);
        }
    }
}
