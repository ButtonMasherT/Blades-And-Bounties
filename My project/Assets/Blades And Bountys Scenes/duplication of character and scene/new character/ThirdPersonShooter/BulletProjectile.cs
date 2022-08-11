using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour {
    public float damage = 10; // damage to hit target Tommy 28/04/22
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;


    private Rigidbody bulletRigidbody;

    private void Awake() {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        float speed = 130f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other) {
       
        if (other.GetComponent<BulletTarget>() != null) {
            // Hit target
           if (other.CompareTag("Enemy")) {other.GetComponent<Animator>().SetTrigger("Hit");}
              
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
            other.GetComponent<HitBox>().BulletProjectile(this);  // damage to hit target Tommy 28/04/22
            
           
        } else {
            // Hit something else
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

}