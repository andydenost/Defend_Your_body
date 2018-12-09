using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFortAntigen : MonoBehaviour {

    public float antiSpeed;
    private Transform target;
    public Transform Target
    {
        set
        {
            target = value;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * antiSpeed * Time.deltaTime);
	}
}
