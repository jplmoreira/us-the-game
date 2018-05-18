using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : Hittable {
    
    public AudioManager audioManager;

	public override void Hit() {
        
        audioManager.Play("Hit");
        
        StressBar.ins.decrement(20);
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
