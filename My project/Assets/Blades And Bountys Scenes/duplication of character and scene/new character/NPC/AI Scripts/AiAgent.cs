using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{ 
    public WeaponIK weaponIK;
    public AiStateMachine stateMachine;
    public AiStateId initialState;
    public NavMeshAgent navMeshAgent;
    public AiAgentConfig config;
    public Ragdoll ragdoll;
    public SkinnedMeshRenderer mesh;
    public UIHealthBar ui;
    public Transform playerTransform;
    public AISensor sensor;
    public AiWeapons weapons;
    // Start is called before the first frame update
    void Start()
    {
        weaponIK = GetComponent<WeaponIK>();
        ragdoll = GetComponent<Ragdoll>();
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        ui = GetComponentInChildren<UIHealthBar>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        weapons = GetComponent<AiWeapons>();
        sensor = GetComponent<AISensor>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;


        stateMachine = new AiStateMachine(this);
        stateMachine.RegisterState(new AiChasePlayerState());
        stateMachine.RegisterState(new AiDeathState());
        stateMachine.RegisterState(new AiIdleState());
        stateMachine.RegisterState(new AiAttackPlayerState());
       
        
        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }
}
