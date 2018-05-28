using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Hittable {

    public GameObject copperWire;

    public override void Hit() {
        GameObject item = Instantiate(copperWire);
        item.transform.position = transform.position;
        Destroy(gameObject);
    }
}
