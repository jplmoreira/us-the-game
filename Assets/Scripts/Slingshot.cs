using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : Item {

    bool shining = false;
    GameObject[] hitObjs;

    public int blueOffset = 150;

    void Awake() {
        hitObjs = GameObject.FindGameObjectsWithTag("Hittable");
    }

    public override void OnUse() {
        if(CharacterSwap.ins.currP.name.Contains("Player3")) {
			canInteract = !canInteract;
            shining = !shining;
            StartCoroutine(Shine());
            CharacterSwap.ins.currP.GetComponent<PointClick>().interacting = !CharacterSwap.ins.currP.GetComponent<PointClick>().interacting;
            Transform arm = CharacterSwap.ins.currP.transform.Find("Arm");
            arm.gameObject.SetActive(!arm.gameObject.activeSelf);
        }
    }

    IEnumerator Shine() {
        yield return new WaitForSeconds(0.5f);
        if (shining) {
            foreach (GameObject obj in hitObjs) {
                Color color = obj.GetComponent<SpriteRenderer>().color;
                obj.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b - blueOffset);
            }
            blueOffset *= -1;
            StartCoroutine(Shine());
        }
    }
}
