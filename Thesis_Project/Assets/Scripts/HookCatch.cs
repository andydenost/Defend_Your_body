using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookCatch : MonoBehaviour {

    public GameObject claw;
    public GameObject arm;
    private Vector3 catchDirection;
    public float clawSpeed;
    private float armLength;
    public float MaxLength;
    public int clawMoveState;//move forward or backward, 0 for forward, 1 for backward.
    private bool catchReady;
    private Vector3 curClawDirection;

	// Use this for initialization
	void Start () {
        catchReady = true;
        arm.SetActive(false);//make it without blackhole if the arm length is 0, so just make it disappear
    }
	
	// Update is called once per frame
	void Update () {
        catchDirection = Vector3.forward;//get players front direction.
        if (Input.GetMouseButtonDown(0) && catchReady == true)
        {
            catchReady = false;
        }
        if (catchReady == false)
        {
            arm.SetActive(true);
            clawMove(catchDirection, clawMoveState);
        }
        
	}

    void clawMove(Vector3 direction, int state)
    {
        if (state == 0)
        {
            claw.transform.Translate(direction * clawSpeed * Time.deltaTime);
            armLength = Vector3.Distance(this.transform.localPosition, claw.transform.localPosition);
            arm.transform.localPosition = new Vector3(0, 0, armLength / 2);
            Vector3 armScale = arm.transform.localScale;
            armScale.y = armLength / 2;
            arm.transform.localScale = armScale;
            if (armLength >= MaxLength)
            {
                clawMoveState = 1;
            }

        }
        else if(state == 1 )
        {

            claw.transform.Translate(-direction * clawSpeed * Time.deltaTime);
            armLength = Vector3.Distance(this.transform.localPosition, claw.transform.localPosition);
            arm.transform.localPosition = new Vector3(0, 0, armLength / 2);
            Vector3 armScale = arm.transform.localScale;
            armScale.y = armLength / 2;
            arm.transform.localScale = armScale;
            curClawDirection = claw.transform.localPosition - Vector3.zero;
            if (curClawDirection == Vector3.zero || curClawDirection.z < 0 )
            {
                armScale.y = 0;
                arm.transform.localScale = armScale;
                claw.transform.localPosition = Vector3.zero;
                clawMoveState = 0;
                Debug.Log("!!");
                catchReady = true;
                arm.SetActive(false);

            }
        }
        
    }

}
