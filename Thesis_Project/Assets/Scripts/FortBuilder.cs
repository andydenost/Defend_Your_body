using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortBuilder : MonoBehaviour {
    public Camera characterCamera;
    public GameObject fortCell;
    public GameObject BCellFort;
    public GameObject MCellFort;
    public Vector3 direction1;
    public Vector3 direction2;
    public Vector3 direction3;
    public Vector3 direction4;
    public Vector3 fortPos;
    public float maxDistanceBuild;

    private int fortIndex;
    Ray ray;
    RaycastHit hit;
	// Use this for initialization
	void Start () {
        direction1 = new Vector3(1,0,1);
        direction2 = new Vector3(1,0,-1);
        direction3 = new Vector3(-1,0,-1);
        direction4 = new Vector3(-1,0,1);

    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown("e"))
        {
            fortIndex = gameObject.GetComponent<SwitchCharacter>().CharcaterCount;
            ray = SightRayManager.Sight.ray;
            if (Physics.Raycast(ray, out hit))
            {
                if (Vector3.Distance(hit.transform.position,transform.position) < maxDistanceBuild)
                {
                    if (hit.collider.name == "Fort1")
                    {
                        fortPos = hit.collider.transform.position;

                        BuildFort(fortIndex, fortPos, direction1);
                    }
                    if (hit.collider.name == "Fort2")
                    {
                        fortPos = hit.collider.transform.position;

                        BuildFort(fortIndex, fortPos, direction2);
                    }
                    if (hit.collider.name == "Fort3")
                    {
                        fortPos = hit.collider.transform.position;

                        BuildFort(fortIndex, fortPos, direction3);
                    }
                    if (hit.collider.name == "Fort4")
                    {
                        fortPos = hit.collider.transform.position;

                        BuildFort(fortIndex, fortPos, direction4);
                    }
                }
            }
        }
  
	}

    void BuildFort(int index, Vector3 pos, Vector3 dir)
    {
        if (index == 0)
        {
            fortCell = BCellFort;
            pos.y = pos.y + 0.8f;
        }
        else if (index == 2)
        {
            fortCell = MCellFort;
            pos.y = pos.y + 1.5f;
        }
        Instantiate(fortCell, pos, Quaternion.LookRotation(dir,Vector3.up));
    }
}
