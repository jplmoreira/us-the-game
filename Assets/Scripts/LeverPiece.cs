using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPiece : Hittable {

    public GameObject leverPiece;

    public override void Hit() {
        GameObject item = Instantiate(leverPiece);
        item.transform.position = transform.position;
        Destroy(gameObject);
    }
}
