using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenuSpawner : MonoBehaviour {

    public RadialMenu menuPrefab;
    public static RadialMenuSpawner ins;

    private void Awake() {
        ins = this;
    }

    public void SpawnMenu(Interactable obj) {
		if (obj.canInteract) {
			RadialMenu newMenu = Instantiate (menuPrefab) as RadialMenu;
			newMenu.transform.SetParent (transform, false);
			newMenu.transform.position = Input.mousePosition;
			newMenu.label.text = obj.title.ToUpper ();
			newMenu.SpawnButtons (obj);
		}
    }
}
