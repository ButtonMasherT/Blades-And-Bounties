using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiChasePlayerState : AiState
{ 
    AiAgent aiAgent;
    AILocomotion aI;
   
    public float maxTime = 1.0f;
    public float maxDistance = 1.0f; 
    float timer = 0.0f;
   public AiShoot aiShoot;
   public GameObject EnemyBullet;
    
    public AiStateId GetId()
    {
        return AiStateId.ChasePlayer;
    }
    
    public void Enter(AiAgent agent)
    {
    
    }
  
    public void Update(AiAgent agent)
    {
       

        if (!agent.enabled)
        {
            aI.Disable();
        }
        timer -= Time.deltaTime;
        if (!agent.navMeshAgent.hasPath)
        {
            agent.navMeshAgent.destination = agent.playerTransform.position;
           
        }
        if(timer < 0.0f)
        {
            
            Vector3 direction = (agent.playerTransform.position - agent.navMeshAgent.destination);
            direction.y = 0; 
           
            if(direction.sqrMagnitude > agent.config.maxDistance * agent.config.maxDistance)
            {
                if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {
                    agent.navMeshAgent.destination = agent.playerTransform.position;
                }
            }
            timer = agent.config.maxTime;
            
        }
       
    }
    
    public void Exit(AiAgent agent)
    {
        
    }

  

  

}