﻿using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class RadialMenu : MonoBehaviour {

    public Text label;
    public RadialButton buttonPrefab;
    public RadialButton selected;

	// Use this for initialization
	public void SpawnButtons(Interactable obj) {
        StartCoroutine(AnimateButtons(obj));
	}

    IEnumerator AnimateButtons(Interactable obj) {
        MethodInfo[] methods = obj.GetType().GetMethods();
        List<MethodInfo> intMethods = new List<MethodInfo>();
        for (int i = 0; i < methods.Length; i++)
            if (methods[i].Name.Contains("Interact"))
                intMethods.Add(methods[i]);

        for (int i = 0; i < intMethods.Count; i++) {
            RadialButton newButton = Instantiate(buttonPrefab) as RadialButton;
            newButton.transform.SetParent(transform, false);
            float theta = (2 * Mathf.PI / intMethods.Count) * i;
            float xPos = Mathf.Sin(theta);
            float yPos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector3(xPos, yPos, 0f) * 30f;
            newButton.label.text = intMethods[i].Name.Split('_')[1];
            newButton.myMenu = this;
            newButton.method = intMethods[i];
            newButton.receiver = obj;
            newButton.Anim();
            yield return new WaitForSeconds(0.06f);
        }
    }

    private void Update() {
        if (Input.GetMouseButtonUp(0)) {
            if (selected) {
                Debug.Log(selected.label.text + " was selected");
                selected.method.Invoke(selected.receiver, null);
            }
            Destroy(gameObject);
        }
    }
}
