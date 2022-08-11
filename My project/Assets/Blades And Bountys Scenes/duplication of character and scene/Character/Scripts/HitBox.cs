using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Health health;
    private CollisionDetection collisionDetection;
   
    public HitBox(CollisionDetection collisionDetection)
    {
        this.collisionDetection = collisionDetection;
    }

    public void BulletProjectile(BulletProjectile bullet) => health.TakeDamage(bullet.damage);
    public void CollisionDetection(CollisionDetection Knife) => health.TakeDamage(Knife.damage);

}
