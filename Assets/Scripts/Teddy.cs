using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teddy : Interactable {

    public GameObject obj;
    public AudioManager audioManager;

	public void Interact_Search() {
        
        audioManager.Play("Search");
        
        GetComponent<Collider2D>().enabled = false;
        GameObject go = Instantiate(obj, null);
        go.transform.position = transform.position;
    }
}
