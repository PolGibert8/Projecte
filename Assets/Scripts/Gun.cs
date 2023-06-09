﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public GameObject BulletPrefab;
    public Transform FirePoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldShoot())
        {
            Fire();
        }
    }

    public override void Fire()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }

    bool ShouldShoot()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
