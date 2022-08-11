using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiIdleState : AiState
{ 
    public AiStateId GetId()
    {
        return AiStateId.Idle;
    }
    
    public void Enter(AiAgent agent)
    {
       
    }

    public void Exit(AiAgent agent)
    {
       
    }

   

    public void Update(AiAgent agent)
    {
        Vector3 PlayerDirection = agent.playerTransform.position - agent.transform.position;
        if (PlayerDirection.magnitude > agent.config.maxSightDistance)
        {
            return;
        }
        Vector3 agentDirection = agent.transform.forward;
        PlayerDirection.Normalize();
        float dotProduct = Vector3.Dot(PlayerDirection, agentDirection);
        if (dotProduct > 0.0f)
        {
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
        }
    }
}

