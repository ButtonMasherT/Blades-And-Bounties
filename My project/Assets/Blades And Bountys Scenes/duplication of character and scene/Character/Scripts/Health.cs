using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    AiShoot aiShoot;
    WeaponIK weaponIK;
    UIHealthBar healthBar;
    public float maxHealth;
    [HideInInspector]
    public float currentHealth;
    AiAgent agent;
    SkinnedMeshRenderer skinnedMeshRenderer;
   AILocomotion aI;
    // Start is called before the first frame update
    void Start()
    {
        aiShoot = GetComponent<AiShoot>();
        weaponIK = GetComponent<WeaponIK>();
        agent = GetComponent<AiAgent>();
        currentHealth = maxHealth;
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        aI = GetComponent<AILocomotion>();
        healthBar = GetComponentInChildren<UIHealthBar>();
        var rigidBodies = GetComponentsInChildren<Rigidbody>(); 
        foreach(var rigidBody in rigidBodies) {
           HitBox hitBox = rigidBody.gameObject.AddComponent<HitBox>();
            hitBox.health = this;
                
        }
    }
    public void TakeDamage(float amount) {
        currentHealth -= amount;
        healthBar.SetHealthBarPercentage(currentHealth / maxHealth);
        if (currentHealth <= 0.0f)
        {
            Die();
        }

      
    }

    private void Die()
    {     
        AiDeathState deathState = agent.stateMachine.GetState(AiStateId.Death) as AiDeathState;
        weaponIK.isnotactive = true;
        aiShoot.detected = false;
        agent.stateMachine.ChangeState(AiStateId.Death);
        
    }

    
}
