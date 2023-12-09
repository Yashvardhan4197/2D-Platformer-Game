using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField]Animator anim;
    public int gap;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //PlayerController playerController=other.gameObject.GetComponent<PlayerController>();
        PlayerUIHandler playerUIHandler=other.gameObject.GetComponent<PlayerUIHandler>();
        if(playerUIHandler!=null){
            playerUIHandler.pickup();
            //play animation
            anim.SetBool("Picked?",true);
            Vector3 position=transform.localPosition;
            position.y=position.y+gap;
            transform.localPosition=position;
            Destroy(gameObject,0.2f);
            anim.SetBool("TimePick",true);

            SoundManager.Instance.PlaySound(Sound.keyPick);
        }
    }
}
