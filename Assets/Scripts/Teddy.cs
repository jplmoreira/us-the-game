using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teddy : Interactable {

    public GameObject obj;

	public void Interact_Search() {
        GetComponent<Collider2D>().enabled = false;
        GameObject go = Instantiate(obj, null);
        go.transform.position = transform.position;
    }
}
