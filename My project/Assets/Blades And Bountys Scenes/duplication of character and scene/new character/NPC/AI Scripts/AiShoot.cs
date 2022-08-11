using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShoot : MonoBehaviour
{



    public float damage = 10; // damage to hit target Tommy 28/04/22
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    public Rigidbody bulletRigidbody;
    public GameObject player;

    public bool detected;
    public GameObject target;
    public Transform enemy;
    public GameObject bullet;
    public Transform shootPoint;
    public float shootSpeed = 10f;
    public float timeToShoot = 1.2f;
    float originalTime;


    void Start()
    {
        originalTime = timeToShoot;
        float speed = 80f;
        bulletRigidbody.velocity = transform.forward * speed;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            detected = true;
            target = other.gameObject;
        }

    }
    public void Update()
    {
        if (detected)
        {
            enemy.LookAt(target.transform);
        }
    }
    private void FixedUpdate()
    {
        if (detected)
        {
            timeToShoot -= Time.deltaTime;
            if (timeToShoot < 0)
            {
                ShootPlayer();
                timeToShoot = originalTime;
            }
        }
    }

    private void ShootPlayer()
    {

        GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody rig = currentBullet.GetComponent<Rigidbody>();
        currentBullet.transform.LookAt(player.transform);
        rig.AddForce(currentBullet.transform.forward * shootSpeed, ForceMode.VelocityChange);
       
      




    }
}


