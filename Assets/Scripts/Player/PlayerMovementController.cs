using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
   public void Player_Transform(float Horizontal, float Vertical,float Speed)
    {
        //Player Movement-
        Vector3 position=transform.position;
        position.x=position.x+Horizontal*Speed*Time.deltaTime;
        transform.position=position;   

        //Sound
        if(Horizontal!=0){
            SoundManager.Instance.PlayWalkSound(Sound.PlayerWalk);
        }
    }


    public void Player_Jump(float Vertical,float jumping,int power,Rigidbody2D rb2d,bool checkGround,float radius, Transform ground, LayerMask isground)
    {
       //Jump
        if((Vertical>0||jumping>0)&&(checkGround==true))
        {
        rb2d.AddForce(new Vector2(0,power),ForceMode2D.Impulse);
        }

    }


    public void Player_Crouch(bool crouch,BoxCollider2D boxCollider)
    {
        if(crouch==true){
            boxCollider.size =new Vector2(1.04f,1.505f);
            boxCollider.offset=new Vector2(-0.117f,0.604f);
        }
        else if(crouch==false){
            boxCollider.size =new Vector2(0.92f,2.35f);
            boxCollider.offset=new Vector2(0.012f,1.03f);
        }
    }
}
