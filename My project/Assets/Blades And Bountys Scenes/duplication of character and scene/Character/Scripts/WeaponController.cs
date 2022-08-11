using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private const string Name = "Knife";
    WeaponSwitcher weaponSwitcher;
    public GameObject weapon03;
    public bool CanAttack = true;
    public float AttackCoolDown = 0.5f;
    public bool IsAttacking = false;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                Weapon03Attack();
            }
        }
    }

    public void Weapon03Attack()
    {


        CanAttack = false;
        IsAttacking = true;

        Animator anim = weapon03.GetComponent<Animator>();
       
        anim.SetTrigger(Name);
        StartCoroutine(ResetAttackCoolDown());


    }
    IEnumerator ResetAttackCoolDown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCoolDown);
        CanAttack = true;
    }
    IEnumerator ResetAttackBool()
    {

        yield return new WaitForSeconds(0.3f);
        IsAttacking = false;
    }
}

