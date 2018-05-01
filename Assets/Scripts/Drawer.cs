using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Interactable {

    GameObject child = null;

    private void Awake() {
        if (transform.childCount > 0)
            child = transform.GetChild(0).gameObject;
    }

    public void Interact_Open() {
        Animator anim = GetComponent<Animator>();
        if (anim != null)
            anim.SetBool("Opened", true);
        GetComponent<Collider2D>().enabled = false;
        if (child != null)
            StartCoroutine(ActivateChild());
    }

    IEnumerator ActivateChild() {
        yield return new WaitForSeconds(0.25f);
        child.SetActive(true);
    }
}
