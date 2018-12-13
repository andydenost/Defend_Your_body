﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PathogenScript : MonoBehaviour {

    //HP, ATK, ID
    public int HP;
    public PathogenInfo PI;
    Transform endPoint;
    NavMeshAgent agent;
    public List<Transform> targetlist;
    List<Transform> mylist;
    public float pathoSpeed;
    Animation VarusAnima;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = pathoSpeed;
        mylist = new List<Transform>();
        foreach (Transform t in targetlist)
        {
            mylist.Add(t);
        }
        //endPoint = GameObject.Find("SpineStage").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (mylist.Count == 0)
        {
            Debug.Log("I am in the end");
            Destroy(gameObject);
        }
        else
        {
            agent.destination = mylist[0].position;
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       if( collision.gameObject.tag == "Organs")
        {
            mylist.Remove(collision.gameObject.transform);
        }
    }
}