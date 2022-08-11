using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public float damage = 50;
    public WeaponController wc;
    public GameObject hitPartical;
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy" && wc.IsAttacking)
        {
            other.GetComponent<Animator>().SetTrigger("Hit");
            Instantiate(hitPartical, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
            other.GetComponent<HitBox>().CollisionDetection(this);

        }
    }
   
}
