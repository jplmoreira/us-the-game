﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject, 2f);
    }
}
