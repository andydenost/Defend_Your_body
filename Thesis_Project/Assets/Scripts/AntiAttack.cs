using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAttack : MonoBehaviour {
    private bool isEffectiveAttack;
    Animation T_Animation;
	// Use this for initialization
	void Start () {
        T_Animation = gameObject.GetComponent<Animation>();
        isEffectiveAttack = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            T_Animation.Play("Forkattack");
            T_Animation["Forkattack"].speed = 1;
        }
        if (T_Animation["Forkattack"].time < T_Animation["Forkattack"].clip.length && T_Animation["Forkattack"].time>0)
        {
            isEffectiveAttack = true;
        }
        else
        {
            isEffectiveAttack = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (isEffectiveAttack == true && collision.gameObject.tag == "Pathogen")
        {
            Debug.Log("Damage!!!!!!!!!");
        }
    }
}

