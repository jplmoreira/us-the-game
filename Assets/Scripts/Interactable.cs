using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    [System.Serializable]
    public class Action {
        public Color color;
        public Sprite sprite;
        public string title;
    }

    public string title;
    public Action[] options;

	// Use this for initialization
	void Start () {
		if (title == "" || title == null ) {
            title = gameObject.name;
        }
	}
	
	// Update is called once per frame
	void OnMouseOver () {
		if (Input.GetMouseButtonDown(1)) {
            RadialMenuSpawner.ins.SpawnMenu(this);
        }
	}
}
