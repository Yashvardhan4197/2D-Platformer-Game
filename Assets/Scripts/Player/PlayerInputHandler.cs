using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] LayerMask isground;
    [SerializeField] Transform ground;
    [SerializeField] int jumpPower;
    [SerializeField]Animator animator;

    bool checkGround=false;
    [SerializeField]float radius;
    PlayerMovementController playerMovementController;
    PlayerAnimation playerAnimation;

    Rigidbody2D rb2d;
    void Awake()
    {
        playerMovementController=gameObject.GetComponent<PlayerMovementController>();  
        playerAnimation=gameObject.GetComponent<PlayerAnimation>();  
        rb2d=gameObject.GetComponent<Rigidbody2D>();    
    }
    void Update()
    {
    float Horizontal=Input.GetAxisRaw("Horizontal");
    float Vertical=Input.GetAxisRaw("Vertical");
    float jumping=Input.GetAxisRaw("Jump");
    bool crouch=Input.GetKey(KeyCode.LeftControl);
    checkGround=Physics2D.OverlapCircle(ground.position,radius,isground);
    playerMovementController.Player_Transform(Horizontal,Vertical,Speed);
    playerMovementController.Player_Jump(Vertical,jumping,jumpPower,rb2d,checkGround,radius,ground,isground);
    playerMovementController.Player_Crouch(crouch,gameObject.GetComponent<BoxCollider2D>());
    playerAnimation.PlayAnim(Horizontal,Vertical,jumping,checkGround,rb2d,animator);
    playerAnimation.Player_crouch(crouch,animator);
    }

}
