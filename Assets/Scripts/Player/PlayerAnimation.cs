using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public void PlayAnim(float Horizontal,float Vertical,int doubleJumpCount,float jumping,bool checkGround,Rigidbody2D rb2d,Animator animator){
        if(Input.GetKeyDown(KeyCode.Space)){
                if(rb2d.velocity.y>0f){
                    animator.SetBool("Jump",true);
                }
                else{
                    animator.SetBool("Fall",true);
                }
       }
       else if(Vertical<=0){
        
        animator.SetBool("Jump",false);
        animator.SetBool("Fall",false);
       }





    animator.SetFloat("Speed",Mathf.Abs(Horizontal));
        Vector3 scale=transform.localScale;
        if(Horizontal>0)
        {
            scale.x=Mathf.Abs(scale.x);
        }
        else if(Horizontal<0)
        {
            if(scale.x>0)
            {
                scale.x*=(-1);
            }
        }
        transform.localScale=scale;

    }

    public void Player_crouch(bool crouch,Animator animator){
        animator.SetBool("Crouch",crouch);
    }


}
