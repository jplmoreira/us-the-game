using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class RadialMenu : MonoBehaviour {

    public Text label;
    public RadialButton buttonPrefab;
    public RadialButton selected;

	float offset = .5f;

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
			float yPos = - offset - 0.7f * i;
			newButton.transform.localPosition = new Vector3(0f, yPos, 0f) * 30f;
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
                selected.method.Invoke(selected.receiver, null);
            }
            Destroy(gameObject);
        }
    }
}
