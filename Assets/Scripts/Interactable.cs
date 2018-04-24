using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {
    public string title;

	// Use this for initialization
	void Start () {
		if (title == "" || title == null ) {
            title = gameObject.name;
        }
	}
	
	// Update is called once per frame
	void OnMouseOver () {
		if (Input.GetMouseButtonDown(0)) {
            if (CharacterSwap.ins.currP.GetComponent<Interact>().Reachable(this.gameObject))
                RadialMenuSpawner.ins.SpawnMenu(this);
            else
                Debug.Log("Out of reach!");
        }
	}
}
