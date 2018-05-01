using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

	public float reach;
	public LayerMask mask;

    public bool Reachable(GameObject obj) {
        Transform currP = CharacterSwap.ins.currP.transform;
        Vector3 pos = new Vector3(currP.position.x, currP.position.y - 0.3f, currP.position.z);
        Vector3 dir = obj.transform.position - pos;
        dir.Normalize();
        RaycastHit2D hit = Physics2D.Raycast (pos, dir, reach, mask);
		if (hit.collider != null && hit.transform.tag == "Item") {
			return true;
		}
		return false;
	}
}
