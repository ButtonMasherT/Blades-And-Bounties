using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipAi : MonoBehaviour
{
    public GameObject currentWeapon;
    public void OnTriggerEnter(Collider other)
    {
      
        AiWeapons aiWeapons = other.gameObject.GetComponent<AiWeapons>();
        if (aiWeapons) 
        {
            AiWeapons weapons = other.gameObject.GetComponent<AiWeapons>();
            if (weapons != null)
            {
                GameObject newWeapon = Instantiate(currentWeapon);
                aiWeapons.Equip(newWeapon);
                Destroy(gameObject);
            }
            
            
        }
    }

    // Update is called once per frame
   // public void Update(AiAgent agent)
  //  {
    //    if (agent.weapons.HasWeapon())
      //  {
        //    agent.weapons.ActivateWeapon();
        //}
    //}
}
