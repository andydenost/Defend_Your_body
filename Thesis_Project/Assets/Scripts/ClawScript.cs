using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawScript : MonoBehaviour {

    public GameObject macrophage;

    public bool pathogenCathing = false;

    private float distance;

    public List<GameObject> pathogen;
	// Use this for initialization

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pathogen")
        {
            pathogen.Add(collision.gameObject);
            pathogenCathing = true;
            collision.gameObject.transform.parent = transform;
            collision.gameObject.layer = 12;
        }
        macrophage.GetComponent<HookCatch>().clawMoveState = 1;

    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, macrophage.transform.position);
        //Debug.Log("d "+distance);

        if (distance < 0.01 && pathogenCathing==true)
        {
            Debug.Log("?");
            foreach (GameObject p in pathogen.ToArray())
            {
                pathogen.Remove(p);
                Destroy(p);  
            }
            
            pathogenCathing = false;
        }
    }
}
