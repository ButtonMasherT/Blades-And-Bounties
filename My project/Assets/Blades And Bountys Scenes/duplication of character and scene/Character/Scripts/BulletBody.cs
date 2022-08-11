using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBody : MonoBehaviour { 
    public float damage = 10; // damage to hit target Tommy 28/04/22
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
  public GameObject enemyBullet;
  public BoxCollider bulletBody;

    private void Start()
    {
        enemyBullet = GetComponent<GameObject>();
       bulletBody = GetComponent<BoxCollider>();
        
    }
    private void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
          
        if (other.tag == "Player")
        { 
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);  
            //Damage Player Here...
           
        }
     
        else
        {
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
          
        }
            Destroy(gameObject);
      
    }
}
