using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class WeaponSwitcher : MonoBehaviour
{
     private CharacterController _controller;
    private StarterAssetsInputs _input;
    private GameObject _mainCamera;

    private const float _threshold = 0.01f;
    private bool _hasAnimator;
 
    Animator anim;
    private int animIDNone;
    private int animIDRifle;
    private int animIDKnife;
    public GameObject weapon01;
    public GameObject weapon02;
    public GameObject weapon03;
    [SerializeField] private Rig aimRig;
    private Animator _animator;
   
      private void AssignAnimationIDs()
    {
        animIDNone = Animator.StringToHash("None");
        animIDRifle = Animator.StringToHash("Rifle");
        animIDKnife = Animator.StringToHash("Knife");

    }


    // Start is called before the first frame update
    private void Start()
    {
        _hasAnimator = TryGetComponent(out _animator);
        _controller = GetComponent<CharacterController>();
        _input = GetComponent<StarterAssetsInputs>();
       

        AssignAnimationIDs();
      
        _animator.SetBool(animIDNone, true);
        _animator.SetBool(animIDKnife, false);
        _animator.SetBool(animIDRifle, false);
        weapon01.SetActive(true);
        weapon02.SetActive(false);
        weapon03.SetActive(false);
       
    }
    


    // Update is called once per frame
    void Update()
    {
      


        if (Input.GetKeyDown("1"))
        {

            _animator.SetBool(animIDNone, true);
            _animator.SetBool(animIDKnife, false);
            _animator.SetBool(animIDRifle, false);
            weapon01.SetActive(true);
            weapon02.SetActive(false);
            weapon03.SetActive(false);
            aimRig.weight = 0f;
            
            
        }
        if (Input.GetKeyDown("2"))
        {
            _animator.SetBool(animIDNone, false);
            _animator.SetBool(animIDKnife, false);
            _animator.SetBool(animIDRifle, true);
            weapon01.SetActive(false);
            weapon02.SetActive(true);
            weapon03.SetActive(false);
            aimRig.weight = 1f;

        }
        if (Input.GetKeyDown("3"))
        {
            _animator.SetBool(animIDNone, false);
            _animator.SetBool(animIDKnife, true);
            _animator.SetBool(animIDRifle, false);
            weapon01.SetActive(false);
            weapon02.SetActive(false);
            weapon03.SetActive(true);
            aimRig.weight = 0f;



        }

    }

}


