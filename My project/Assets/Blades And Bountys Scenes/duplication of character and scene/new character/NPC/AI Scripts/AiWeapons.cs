using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiWeapons : MonoBehaviour
{
    MeshSockets Sockets;
    Transform currentTarget;
    public GameObject currentWeapon;
    WeaponIK weaponIK;
    Animator animator;
   
    private void Start()
    {
        animator = GetComponent<Animator>();
        weaponIK = GetComponent<WeaponIK>();
    }
  
    public void Equip(GameObject weapon)
    {
        currentWeapon = weapon;
        Sockets.Attach(weapon.transform, MeshSockets.SocketId.Spine);
    }

    public void ActivateWeapon()
    {
        StartCoroutine(EquipWeapon());
    }

    IEnumerator EquipWeapon()
    {

        animator.SetBool("Equip", true);
        yield return new WaitForSeconds(0.5f);
        while(animator.GetCurrentAnimatorStateInfo(1).normalizedTime < 1.0f)
        {
            yield return null;
        }

        weaponIK.SetAimTransform(aim: currentWeapon.transform);
     
    }
    public void DropWeapon()
    {
        currentWeapon.GetComponent<BoxCollider>().enabled = true;
            currentWeapon.AddComponent<Rigidbody>();  
        currentWeapon.transform.SetParent(null);
            currentWeapon = null;  
    }
    public bool HasWeapon()
    {
        return currentWeapon != null;
    }
    public void SetTarget(Transform target)
    {
        weaponIK.SetTargetTransform(target);
        currentTarget = target;
    }
}
