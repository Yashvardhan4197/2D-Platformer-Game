using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    
    public Animator animator;
    public BoxCollider2D boxCollider;
    void Start()
    {
    }
    void Update()
    {
        float speed=Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed",Mathf.Abs(speed));
        Vector3 scale=transform.localScale;
        if(speed<0)
        {
            if(scale.x>0)
            {
            scale.x=-1f*scale.x;
            }
        }else if(speed>0)
        {
            scale.x=Mathf.Abs(scale.x);
        }
        transform.localScale=scale;

        //Crouch while pressing ctrl
        bool crouch=Input.GetKey(KeyCode.LeftControl);
        bool jump=false;
        float jc=Input.GetAxisRaw("Vertical");
        if(crouch==true||jc<0){
            if(jc<0)
            {
                crouch=true;
            }
            animator.SetBool("Crouch",crouch);
            boxCollider.size =new Vector2(1.04f,1.505f);
            boxCollider.offset=new Vector2(-0.117f,0.604f);
        }else if(crouch==false){
            animator.SetBool("Crouch",crouch);
            boxCollider.size =new Vector2(0.92f,2.35f);
            boxCollider.offset=new Vector2(0.012f,1.03f);
        }

        if(jc>0)
        {
            jump=true;
            animator.SetBool("Jump",jump);
        }
        if(jc<=0)
        {
            jump=false;
            animator.SetBool("Jump",jump);
        }

        

    }
}
