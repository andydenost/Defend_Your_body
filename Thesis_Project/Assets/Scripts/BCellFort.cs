using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCellFort : MonoBehaviour {

    public float detectorRadius;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectorRadius);
        foreach(Collider hc in hitColliders)
        {
            if (hc.name == "Player")
            {
                if (Vector3.Angle(transform.forward, hc.transform.position-transform.position)<=45)
                {
                    Debug.Log("I find you!");

                }
            }
        }
    }
}
