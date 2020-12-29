﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private new Rigidbody rigidbody;


    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 50)).x, -17, 0));
    }

}
