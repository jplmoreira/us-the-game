using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Interact))]
public class DrawWireArc : Editor {
    private void OnSceneGUI() {
        Handles.color = Color.red;
        Interact myObj = (Interact)target;
        Vector3 pos = new Vector3(myObj.transform.position.x, myObj.transform.position.y - 0.7f, myObj.transform.position.z);
        Handles.DrawWireArc(pos, Vector3.back, Vector3.right, 360f, myObj.reach);
    }
}
