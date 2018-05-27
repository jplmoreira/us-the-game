using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {
    public string title;

    public bool canInteract = true;
    private Texture2D cursor;

	// Use this for initialization
	void Start () {
		if (title == "" || title == null ) {
            title = gameObject.name;
        }
        cursor = (Texture2D)Resources.Load("interact", typeof(Texture2D));
    }
	
	// Update is called once per frame
	void OnMouseOver () {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        if (Input.GetMouseButtonDown(0)) {
            if (CharacterSwap.ins.currP.GetComponent<Interact>().Reachable(this.gameObject))
                RadialMenuSpawner.ins.SpawnMenu(this);
            else
                Debug.Log("Out of reach!");
        }
	}

    private void OnMouseExit() {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
