using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    
    public Animator animator;
    public float Speed;
    public BoxCollider2D boxCollider;
    public int jump;

    private Rigidbody2D rb;
    void Start()
    {
        rb=gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float Horizontal=Input.GetAxisRaw("Horizontal");
        float Vertical=Input.GetAxisRaw("Jump");
        Player_Anim(Horizontal,Vertical);
        Player_Transform(Horizontal,Vertical);
        //Crouch while pressing ctrl
        bool crouch=Input.GetKey(KeyCode.LeftControl);
        Player_Crouch(crouch);

        

    }

    private void Player_Transform(float Horizontal, float Vertical)
    {
        //Player Movement-
        Vector3 position=transform.position;
        position.x=position.x+Horizontal*Speed*Time.deltaTime;
        transform.position=position;

    }


    private void Player_Anim(float Horizontal,float Vertical)
    {
        animator.SetFloat("Speed",Mathf.Abs(Horizontal));
        Vector3 scale=transform.localScale;
        if(Horizontal<0)
        {
            if(scale.x>0)
            {
            scale.x=-1f*scale.x;
            }
        }
        else if(Horizontal>0)
        {
            scale.x=Mathf.Abs(scale.x);
        }
        transform.localScale=scale;


//Jump-Animation
        if(Vertical>0)
        {
        animator.SetBool("Jump",true);
        }
        if(Vertical==0)
        {
            animator.SetBool("Jump",false);
        }
    }
    void Player_Crouch(bool crouch)
    {
        if(crouch==true){
            boxCollider.size =new Vector2(1.04f,1.505f);
            boxCollider.offset=new Vector2(-0.117f,0.604f);
            animator.SetBool("Crouch",crouch);
        }
        else if(crouch==false){
            animator.SetBool("Crouch",crouch);
            boxCollider.size =new Vector2(0.92f,2.35f);
            boxCollider.offset=new Vector2(0.012f,1.03f);
        }
    }
   
}
