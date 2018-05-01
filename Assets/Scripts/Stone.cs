using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject, 2f);
        if (collision.transform.tag.Equals("Hittable")) {
            Animator anim = collision.gameObject.GetComponent<Animator>();
            if (anim != null)
                anim.SetBool("Hit", true);
            collision.gameObject.GetComponent<Hittable>().Hit();
        }
    }
}
