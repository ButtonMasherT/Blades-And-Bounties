using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ragdoll : MonoBehaviour
{
    public Rigidbody[] rigidBodies;
    Animator animator;
    NavMeshAgent agent;
    readonly AILocomotion[] aILocomotions;
    public CapsuleCollider capsuleCollider;
    
    // Start is called before the first frame update
        void Start()
    {
        rigidBodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        agent = navMeshAgent;
        DeactivateRagdoll();
       
        
        
    }

    // Update is called once per frame
    public void DeactivateRagdoll() {
        foreach(var rigidBody in rigidBodies) { 
            rigidBody.isKinematic = true;
        }
        animator.enabled = true;
    }

    public void ActivateRagdoll()
    {
        foreach (var rigidBody in rigidBodies)
        {
            rigidBody.isKinematic = false;

        }
        animator.enabled = false;
        agent.enabled = false;
        capsuleCollider.enabled = false;
        
    }
  
    
}
