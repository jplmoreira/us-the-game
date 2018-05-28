using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour {

    
    
	// Update is called once per frame
	void Update () {
        var foundedObjects = FindObjectsOfType<AudioManager>();
                
        AudioManager audioManager = foundedObjects[0];
        
        if(audioManager.isPlayingThisSound("AimSlingshot")){

        }else{
            audioManager.Play("AimSlingshot");
        }
        
        
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.position;
        diff.Normalize();
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        float degOffset = 0;
        if (transform.parent.transform.localScale.x < 0)
            degOffset = 180f;
        rotZ += degOffset;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
}
