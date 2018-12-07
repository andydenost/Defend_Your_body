using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntigenShooting : MonoBehaviour {

        private Vector3 shootingDirection;
        public float antiSpeed;
        public GameObject player;
        public float rotateSpeed;
        public Vector3 playerSpeed;
        
        // Use this for initialization
        void Start()
        {
            player = GameObject.Find("Player");
            shootingDirection = player.transform.forward;
            playerSpeed = player.GetComponent<PlayerControler>().playerVelocity;
           // Debug.Log("ps"+playerSpeed);
            gameObject.GetComponent<Rigidbody>().velocity = playerSpeed;
           // Debug.Log(gameObject.GetComponent<Rigidbody>().velocity);
            gameObject.GetComponent<Rigidbody>().AddForce(shootingDirection * antiSpeed);
           // Debug.Log(gameObject.GetComponent<Rigidbody>().velocity);
    }

    // Update is called once per frame
    void Update()
        {
            antiMove();
        }

       void antiMove()
        {
        gameObject.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.Self);

    }
}



