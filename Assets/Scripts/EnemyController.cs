using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject pointA;
    [SerializeField] GameObject pointB;
    [SerializeField] int speed;
    private Animator animator;

    private Rigidbody2D rb2d;
    private bool change=true;
    private Vector3 positionEnemy;

    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        positionEnemy.x=pointB.transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement(){
        if(change==true){ 
            if(positionEnemy.x<pointB.transform.localPosition.x){
            positionEnemy.x+=speed*Time.deltaTime;
            animator.SetBool("walk",true);
            Vector3 tempscale=transform.localScale;
            if(transform.localScale.x<0){
                Mathf.Abs(tempscale.x);

            }
            transform.localScale=tempscale;

            }
        }
        if(change==false){
            if(positionEnemy.x>pointA.transform.localPosition.x){
                //Debug.Log("Left");
                positionEnemy.x-=speed*Time.deltaTime;
                animator.SetBool("walk",true);
            }
        }
        transform.localPosition=positionEnemy;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject==pointB){
            change=false;
            Vector3 dir=transform.localScale;
            if(dir.x>0){
                dir.x=(-1)*dir.x;
            }
            transform.localScale=dir;
            animator.SetBool("Attack",false);

        }
        else if(other.gameObject==pointA){
            change=true;
            Vector3 dir=transform.localScale;
            dir.x=Mathf.Abs(dir.x);
            transform.localScale=dir;
            animator.SetBool("Attack",false);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
            if(other.gameObject.GetComponent<PlayerController>()!=null){
                Debug.Log("Player");
                animator.SetBool("Attack",true);
            }
    }
}
