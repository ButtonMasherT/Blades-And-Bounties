using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;


public class ThirdPersonShooterController : MonoBehaviour {
    [SerializeField] private Rig aimRig;
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    bool isAim = false;
    public WeaponSwitcher weaponSwitcher; 
    private ThirdPersonController thirdPersonController; // private changed to public
    private StarterAssetsInputs starterAssetsInputs; // private changed to public
    private Animator animator; //private changed to public
    
    public void Awake()
    {// private changed to public
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }
 
    private void Update() {
       if(Time.timeScale >= 0.5f) { 
        Vector3 mouseWorldPosition = Vector3.zero;

        

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask)) {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        
        }
        
        if (starterAssetsInputs.aim) {
            isAim = true;
         

            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 13f));
           
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else {
            isAim = false;
            aimRig.weight = 0f;

            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 13f));
        }
        
        if (starterAssetsInputs.shoot && isAim)
        {
          
            /*
            // Hit Scan Shoot
            if (hitTransform != null) {
                // Hit something
                if (hitTransform.GetComponent<BulletTarget>() != null) {
                    // Hit target
                    Instantiate(vfxHitGreen, mouseWorldPosition, Quaternion.identity);
                } else {
                    // Hit something else
                    Instantiate(vfxHitRed, mouseWorldPosition, Quaternion.identity);
                }
            }

            
            //*/
            //*
            if (weaponSwitcher.weapon02.activeSelf)
            { 
                aimRig.weight = 1f;
                //Projectile Shoot
                Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
                //*/
                starterAssetsInputs.shoot = false;
               
            }
        }
        //else if (starterAssetsInputs.shoot && !isAim) ; 

}
    }

}