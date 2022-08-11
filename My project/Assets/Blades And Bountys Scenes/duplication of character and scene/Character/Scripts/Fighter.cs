using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
   
    private Animator anim;
    public float cooldownTime = 0.8f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    void Update()
    {

       /* if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            anim.SetTrigger("hit1");
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            anim.SetBool("hit2", false);
        }*/
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit3"))
        {
           // anim.SetBool("hit3", false);
            noOfClicks = 0;
        }
       

        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

        //cooldown time
        if (Time.time > nextFireTime)
        {
            // Check for mouse input
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();

            }
        }
    }

    void OnClick()
    {
        //so it looks at how many clicks have been made and if one animation has finished playing starts another one.
        lastClickedTime = Time.time;
        noOfClicks++;
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
        switch (noOfClicks) 
        {
            case 1:
                anim.SetTrigger("hit1");
                break;
            case 2:
                anim.SetTrigger("hit2");
                break;
            case 3:
                anim.SetTrigger("hit3");
                break;
        }
            

        //{
        //    anim.SetTrigger("hit1");
        //}
        //noOfClicks = Mathf.Clamp( noOfClicks, 0, 3);

        //if (noOfClicks == 2 /*&& anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1")*/)
        //{
        //    //anim.SetBool("hit1", false);
        //    anim.SetTrigger("hit2");
        //}
        //if (noOfClicks == 3 /*&& anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2")*/)
        //{
        //    //anim.SetBool("hit2", false);
        //    anim.SetTrigger("hit3");
        //}
    }
}