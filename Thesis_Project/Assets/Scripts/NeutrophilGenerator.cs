using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutrophilGenerator : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    public GameObject Neutrophil;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        ray = SightRayManager.Sight.ray;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Stage")
            {
                if (Input.GetKeyDown("q"))
                {
                    Vector3 neuPos = hit.point;
                    neuPos.y = neuPos.y + 0.5f;
                    Instantiate(Neutrophil, neuPos, transform.rotation);
                }
            }
        }
	}
}
