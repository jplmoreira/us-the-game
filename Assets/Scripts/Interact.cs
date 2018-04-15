﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

	public float reach;
	public LayerMask mask;

	public bool Reachable(GameObject obj) {
		Vector3 dir = obj.transform.position - transform.position;
		RaycastHit2D hit = Physics2D.Raycast (transform.position, dir, reach, mask);
		if (hit.collider != null && hit.transform.tag == "Item") {
			return true;
		}
		return false;
	}
}