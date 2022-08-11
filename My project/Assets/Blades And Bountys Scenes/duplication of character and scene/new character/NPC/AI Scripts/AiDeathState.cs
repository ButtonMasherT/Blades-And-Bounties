using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDeathState : AiState
{
    

    AILocomotion aI;
    public Vector3 direction;
    
    AiStateId AiState.GetId()
    {
        return AiStateId.Death;
    }
  
    void AiState.Enter(AiAgent agent)
    {
        const float V = 1f;
        direction.y = V;
       
        agent.ragdoll.ActivateRagdoll();
        agent.ui.gameObject.SetActive(false);
        agent.weapons.DropWeapon();
        aI.Disable();
        
     
        
    }

    void AiState.Update(AiAgent agent)
    {
         
    }
    
    void AiState.Exit(AiAgent agent)
    {
        
    }

   

}
