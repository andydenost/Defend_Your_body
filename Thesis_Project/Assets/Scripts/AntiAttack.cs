using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAttack : MonoBehaviour {

    Animation T_Animation;
	// Use this for initialization
	void Start () {
        T_Animation = gameObject.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
                
            if (T_Animation["Forkattack"].normalizedTime > 0.99f)
            {

                T_Animation["Forkattack"].speed = 0;
                Debug.Log("attack?");

            }
            else
            {
                T_Animation.Play("Forkattack");
                T_Animation["Forkattack"].speed = 1;
            }
            
        }else if (Input.GetMouseButtonUp(0))
        {
            T_Animation["Forkattack"].speed = -1;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
          
    }



}
