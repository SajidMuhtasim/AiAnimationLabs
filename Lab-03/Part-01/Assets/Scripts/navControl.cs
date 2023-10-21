using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class navControl : MonoBehaviour
{
    public GameObject Target;
    private NavMeshAgent agent;
    private Animator animator;
    bool isWalking = true;
    float slidervalue;
    public Transform lookAtTarget;
   
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            agent.destination = Target.transform.position;
        }
        else
        {
            agent.destination = transform.position;
        }

        float agentSpeed = agent.speed;

        if (agentSpeed > 0.1f)
        {
            animator.SetFloat("Speed", agentSpeed); //changing walk speed based on nav mesh agent controller speed
        }
        else
        {
            animator.SetFloat("Speed", 1f); //returning animation speed back to default
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.name == "Dragon")
        {
            isWalking = false;
            animator.SetTrigger("ATTACK");

            if (lookAtTarget != null)
            {
                transform.LookAt(lookAtTarget);
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.name == "Dragon")
        {
            isWalking = true;
            animator.SetTrigger("WALK");
        }
    }
}
