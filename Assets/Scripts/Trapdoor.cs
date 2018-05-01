using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : Hittable {

	public override void Hit() {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
