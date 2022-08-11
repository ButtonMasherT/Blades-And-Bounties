using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class Crouch : MonoBehaviour
{
    public CharacterController PlayerHeight;
    public float normalHeight, crouchHeight;
    private int animIDcrouch;
    // Start is called before the first frame update
    private Animator _animator;
    private CharacterController _controller;
    private StarterAssetsInputs _input;
    public GameObject Player;
    private bool _hasAnimator;

    Animator anim;
    // Update is called once per frame
    private void AssignAnimationIDs()
    {
        animIDcrouch = Animator.StringToHash("crouch");
    }

    private void Start()
    {
        _hasAnimator = TryGetComponent(out _animator);
        _controller = GetComponent<CharacterController>();
        _input = GetComponent<StarterAssetsInputs>();

        AssignAnimationIDs();
        _animator.SetBool(animIDcrouch, false);
    }
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Player.transform.Translate(new Vector3(0.0f, 0.35f, 0.0f));
            PlayerHeight.height = crouchHeight;
            _animator.SetBool(animIDcrouch, true);
        }   
     if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Player.transform.Translate(new Vector3(0.0f, -0.35f, 0.0f));
            PlayerHeight.height = normalHeight;
            _animator.SetBool(animIDcrouch, false);
        }
    }
    
}
