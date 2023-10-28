using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;
    private Vector3 lastKnowPos;
    
    public NavMeshAgent Agent {get => agent; }
    public GameObject Player { get => player; }
    public NavMeshAgent navMeshAgent;
    [Header("Sight Values")]
    public float sightDistance = 20f;
    public float fieldOfview = 85f;
    public float eyeHeight;
    public Vector3 LastKnowPos { get => lastKnowPos; set => lastKnowPos = value; }
    [SerializeField]    
    private string currentState;
    public bool canHop = true;
    public float hopCooldown = 2f;
    public float hopHeight = 2f;
    public string playerTag = "Player";
    public float moveSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
    }

    public bool CanSeePlayer()
    {
        if(player != null)
        {
            //is player close enough to be seen?
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);

                if (angleToPlayer >= -fieldOfview && angleToPlayer <= fieldOfview)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();

                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        if (hitInfo.transform.gameObject == player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    public void MoveTowardsPlayer(Vector3 direction)
    {
        //idk how to fix this I cant get it to work in the attack state
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    
}
