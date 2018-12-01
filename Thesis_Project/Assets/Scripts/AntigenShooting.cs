using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntigenShooting : MonoBehaviour {

        private Vector3 shootingDirection;
        public float antiSpeed;
        public GameObject player;
        public float rotateSpeed;
        
        // Use this for initialization
        void Start()
        {
            shootingDirection = GameObject.Find("Player").transform.forward;
            this.GetComponent<Rigidbody>().AddForce(shootingDirection * antiSpeed);

        }

        // Update is called once per frame
        void Update()
        {
        this.transform.Rotate(0,rotateSpeed*Time.deltaTime,0,Space.Self);
        }
}


