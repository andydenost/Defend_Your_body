﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCell : MonoBehaviour {

    public GameObject goBullet;
    private GameObject bullet;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (GameManager.GM.BodyImmunity >= 1)
            {
                bullet = Instantiate(goBullet);
                bullet.transform.position = transform.position;
                GameManager.GM.BodyImmunity--;
            }
            
            //bullet.transform.parent = this.transform;
            //bullet.transform.SetParent(this.transform);
        }
    }
}
