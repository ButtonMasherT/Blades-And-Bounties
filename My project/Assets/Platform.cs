using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
   //getting the player object to be public in the inspecter window so i can assign it
    public GameObject Player;
    
   //when the player object collides with the platform it gets parented to it so when the platform moves the player moves with it
    private void OnTriggerEnter(Collider other)
    {
        //checking if the object that collided with the platform is the player or not
         if (other.CompareTag("Player")) 
        {  
            //parenting the objects so the player will stay on it when the platform moves 
            Player.transform.parent = transform;
        }
       
    }
    //when the player object is no longer colliding with the platform it will stop moving with it
    private void OnTriggerExit(Collider other)
    {
        //unparenting the objects when the player exits the platform collider
        Player.transform.parent = null;
       
    }
   
}
   
