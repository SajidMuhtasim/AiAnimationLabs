using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            //code to jump towards player but I couldnt implement it
        }
        else //lost sight of player
        {
            losePlayerTimer += Time.deltaTime;

            if (losePlayerTimer  > 1) //5 sec window for player to jump on top of the head 
            {
                //change to search state
                stateMachine.ChangeState(new SearchState());
            }
        }
    }

   

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
