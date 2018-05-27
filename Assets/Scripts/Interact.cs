using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

	public float reach;
	public LayerMask layerMask;

    public bool Reachable(GameObject obj) {
        Transform currP = CharacterSwap.ins.currP.transform;
        Vector3 pos = new Vector3(currP.position.x, currP.position.y - 0.3f, currP.position.z);
		Vector3 dir = obj.transform.position - pos;
		dir.Normalize();
		RaycastHit2D[] hits = Physics2D.RaycastAll (pos, dir, reach, layerMask);
		foreach (RaycastHit2D hit in hits) {
			string title = obj.gameObject.GetComponent<Interactable> ().title;
			if (hit.transform.tag.Equals("Floor")) {
				return false;
			} else if (hit.transform.gameObject.GetComponent<Interactable> ().title.Equals (title)) {
				return true;
			}
		}
		return false;
	}
}
