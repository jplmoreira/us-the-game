using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : Item {

    bool shining = false;
    GameObject[] hitObjs;
    float t = 0f;
    float upperLimit = 1f;
    float lowerLimit = 0f;

    void Awake() {
        hitObjs = GameObject.FindGameObjectsWithTag("Hittable");
    }

    public override void OnUse() {
        if(CharacterSwap.ins.currP.name.Contains("Player3")) {
			canInteract = !canInteract;
            shining = !shining;
            ResetColor();
            CharacterSwap.ins.currP.GetComponent<PointClick>().interacting = !CharacterSwap.ins.currP.GetComponent<PointClick>().interacting;
            Transform arm = CharacterSwap.ins.currP.transform.Find("Arm");
            arm.gameObject.SetActive(!arm.gameObject.activeSelf);
        }
    }

    void ResetColor() {
        foreach (GameObject obj in hitObjs) {
            if (obj != null)
                obj.GetComponent<SpriteRenderer>().color = Color.white;
        }
        upperLimit = 1f;
        lowerLimit = 0f;
    }

    private void Update() {
        if (shining) {
            float blue = Mathf.Lerp(upperLimit, lowerLimit, t);
            foreach (GameObject obj in hitObjs) {
                if (obj != null) {
                    Color color = new Color(1f, 1f, blue);
                    obj.GetComponent<SpriteRenderer>().color = color;
                }
            }
            t += Time.deltaTime;
            if (t > 1f) {
                float temp = upperLimit;
                upperLimit = lowerLimit;
                lowerLimit = temp;
                t = 0f;
            }
        }
    }
}
