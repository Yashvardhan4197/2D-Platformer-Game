using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField]Animator anim;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<PlayerController>()!=null){
            PlayerController playerController=other.gameObject.GetComponent<PlayerController>();
            playerController.pickup();
            //play animation
            anim.SetBool("Picked?",true);
            Destroy(gameObject,0.15f);
        }
    }
}
