using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkieTalkie : MonoBehaviour {

    public void charSwap() {
        Time.timeScale = 1f - Time.timeScale;
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
