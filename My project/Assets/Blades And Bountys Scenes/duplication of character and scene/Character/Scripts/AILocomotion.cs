using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AILocomotion : MonoBehaviour
{
    DebugDrawLine drawLine;
    DebugDrawSphere drawSphere;
    Animator animator;
    NavMeshAgent agent;
    MeshSocket meshSocket;
    MeshSockets meshSockets;
    AILocomotion aI;
    WeaponIK weaponIK;
    AiShoot aiShoot;
    AiAgent aiAgent;
    
    // Start is called before the first frame update
    void Start()
    {   
        agent = GetComponent<NavMeshAgent>();
        aI = GetComponent<AILocomotion>();
        animator = GetComponent<Animator>();
        meshSocket = GetComponentInChildren<MeshSocket>();
        meshSockets = GetComponentInChildren<MeshSockets>();
        drawLine = GetComponent<DebugDrawLine>();
        drawSphere = GetComponent<DebugDrawSphere>();
        weaponIK = GetComponent<WeaponIK>();
        aiShoot = GetComponent<AiShoot>();
        aiAgent = GetComponent<AiAgent>();
     }
    
    // Update is called once per frame
    void Update()
    {
      
        if (agent.hasPath)
        {
            
            animator.SetFloat("Speed", agent.velocity.magnitude);
            animator.SetBool("Attack", true);            
              aiShoot.detected = true;
            weaponIK.isnotactive = false;
          
         
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
        
    }

    public void Disable()
    { weaponIK.isnotactive = true;
        agent.enabled = (false);
        animator.enabled = (false);
        meshSocket.enabled = (false);
        meshSockets.enabled = (false);
        drawLine.enabled = (false);
        drawSphere.enabled = (false);        
        aiShoot.detected = (false);
        

        
    }
}