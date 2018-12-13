using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GuardAntiAttack : MonoBehaviour {
    public float detectRadius;
    private float nearestDistance;
    private GameObject nearestEnemy;
    Animation T_Animation;
    NavMeshAgent agent;
    Collider[] enemyCollider;
    GameObject guardPoint;
    public float attackRadius;
    private bool isEffectiveAttack;
    private bool hasEnemy;
    


    // Use this for initialization
    void Start () {
        T_Animation = gameObject.GetComponentInChildren<Animation>();
        nearestDistance = detectRadius;
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        guardPoint = GameObject.Find("TCellFortQuad");
        hasEnemy = false;
    }

    // Update is called once per frame
    void Update () {
        hasEnemy = false;
        enemyCollider = Physics.OverlapSphere(transform.position, detectRadius);
        foreach (Collider em in enemyCollider)
            {
                if (em.gameObject.tag == "Pathogen")
                {
                    hasEnemy = true;
                    float newDistance = Vector3.Distance(transform.position, em.transform.position);
                    if (newDistance < nearestDistance)
                    {
                        nearestDistance = newDistance;
                        nearestEnemy = em.gameObject;
                    }
                }
            }
        if (hasEnemy == false)
        {
           nearestEnemy = null;
           nearestDistance = detectRadius;

        }

        if (nearestEnemy != null)
        {
            agent.enabled = true;
            agent.destination = nearestEnemy.transform.position;
            transform.LookAt(nearestEnemy.transform);
            if (Vector3.Distance(transform.position, nearestEnemy.transform.position) < attackRadius)
            {
                T_Animation.Play("Forkattack");
                if (T_Animation["Forkattack"].time < T_Animation["Forkattack"].clip.length && T_Animation["Forkattack"].time > 0)
                {
                    isEffectiveAttack = true;
                }
                else
                {
                    isEffectiveAttack = false;
                }
            }
        }
        else
        {
            if (transform.position.x == guardPoint.transform.position.x && transform.position.z == guardPoint.transform.position.z)
            {
                agent.enabled = false;
            }
            else
            {
                agent.destination = guardPoint.transform.position;

            }
        }
        
        Debug.Log(nearestEnemy);
        Debug.Log(nearestDistance);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isEffectiveAttack == true && collision.gameObject.tag == "Pathogen")
        {
            Debug.Log("Damage!!!!!!!!!");
        }
    }

}
