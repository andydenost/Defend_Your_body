using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawScript : MonoBehaviour {

    public GameObject macrophage;

    public bool pathogenCathing = false;

    private float distance;

    public GameObject pathogen;
	// Use this for initialization

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pathogen")
        {
            pathogen = collision.gameObject;
            pathogenCathing = true;
            pathogen.transform.parent = transform;
            pathogen.layer = 9;
        }
        macrophage.GetComponent<HookCatch>().clawMoveState = 1;

    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, macrophage.transform.position);
        if (distance == 0 && pathogenCathing==true)
        {
            Destroy(pathogen);
            pathogenCathing = false;
        }
    }
}
