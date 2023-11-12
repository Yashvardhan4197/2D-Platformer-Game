using UnityEngine;

public class PlayerUIHandler : MonoBehaviour
{
    [SerializeField] ScoreController scoreController;
    [SerializeField] LifeController lifeController;
    [SerializeField] ReloadController reloadController;
    private Rigidbody2D rb2d;
    [SerializeField] Camera main_Camera;
    [SerializeField] Animator animator;
    [SerializeField] int health;
    public void pickup()
    {
         //scoreIncrement+=1;
        scoreController.Scoreincrement(10);
         
    }
    void Start()
    {
     rb2d=gameObject.GetComponent<Rigidbody2D>();   
     lifeController.setHealth(health);
    }

    public void reduceHealth(){
        health--;
        lifeController.reduce();
        if(health<=0){
            rb2d.constraints=RigidbodyConstraints2D.FreezePosition;
            main_Camera.transform.parent=null;
            animator.Play("Player_Death");
            rb2d.constraints=RigidbodyConstraints2D.FreezePosition;
            reloadController.PlayerDead();
            this.enabled=false;
        }
    }
}
