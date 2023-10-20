using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    
    public Animator animator;
    public float Speed;
    public BoxCollider2D boxCollider;
    public int jump;
    private Rigidbody2D rb2d;

//Checks if ground is there or not
    private bool checkGround;
    //Sets radius for the layermask
    public float radius;
    //Area of the ground
    public Transform ground;
    //Defines what is ground
    public LayerMask isground;

    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Input
        float Horizontal=Input.GetAxisRaw("Horizontal");
        float Vertical=Input.GetAxisRaw("Vertical");
        float jumping=Input.GetAxisRaw("Jump");
        //Call Animations
        Player_Anim(Horizontal,Vertical);
        //Transform
        Player_Transform(Horizontal,Vertical);
        Player_Jump(Vertical,jumping);
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


    void Player_Jump(float Vertical,float jumping)
    {
        checkGround=Physics2D.OverlapCircle(ground.position,radius,isground);
        if((Vertical>0||jumping>0) && checkGround==true){
        animator.SetBool("Jump",true);
       }
       else if(Vertical<=0){
        animator.SetBool("Jump",false);
       }
       //Jump
        if((Vertical>0||jumping>0)&&(checkGround==true))
        {
        rb2d.AddForce(new Vector2(0,jump),ForceMode2D.Impulse);
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
