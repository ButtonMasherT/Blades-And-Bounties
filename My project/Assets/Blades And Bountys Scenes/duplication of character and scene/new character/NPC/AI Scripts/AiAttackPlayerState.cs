using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AiAttackPlayerState : AiState
{   
 

    AILocomotion aI;
    Animator anim;

   
    public AiStateId GetId()
    {
        return AiStateId.AttackPlayer;
    }

    public void Enter(AiAgent agent)
    {
       
        agent.weapons.ActivateWeapon();
        agent.weapons.SetTarget(agent.playerTransform);
        agent.navMeshAgent.stoppingDistance = 3.0f;
        
    }
    public void Update(AiAgent agent)
    {
        agent.navMeshAgent.destination = agent.playerTransform.position; 
       
    } 
    
  

    public void Exit(AiAgent agent)
    {
        agent.navMeshAgent.stoppingDistance = 0.0f;
    }



   

}
    

