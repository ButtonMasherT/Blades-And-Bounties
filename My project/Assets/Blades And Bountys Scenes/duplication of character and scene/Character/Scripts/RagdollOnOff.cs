using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollOnOff : MonoBehaviour
{
    public BoxCollider mainCollider;
    public GameObject thisGuysRig;
    public Animator thisGuysAnimater;
    public CapsuleCollider capsuleCollider;

    void Start()
    {
        GetRagdollBits();
        RagdollModeOff();
       
    }

  
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        { 
            RagdollModeOn();
        
        }
    }
    public Collider[] ragDollColliders;
    Rigidbody[] limbsRigidbodies; 
    void GetRagdollBits() 
    {
        ragDollColliders = thisGuysRig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = thisGuysRig.GetComponentsInChildren<Rigidbody>();
    }
    void RagdollModeOn()
    {  
        thisGuysAnimater.enabled = false;
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = true;
        }
        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
        }

        capsuleCollider.enabled = false;
        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }
    void RagdollModeOff()
    { 
    foreach(Collider col in ragDollColliders)
        {
            col.enabled = false; 
        }
    foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = true;
        }

        thisGuysAnimater.enabled = true;
        mainCollider.enabled = true;
        capsuleCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false; 
    }
}
