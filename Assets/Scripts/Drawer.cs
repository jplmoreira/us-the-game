using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Interactable {

	public void Interact_Open() {
        Animator anim = GetComponent<Animator>();
        if (anim != null)
            anim.SetBool("Opened", true);
        GetComponent<Collider2D>().enabled = false;
    }
}
