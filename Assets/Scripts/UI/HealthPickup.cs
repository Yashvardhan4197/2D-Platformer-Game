using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerUIHandler>()!=null){
            PlayerUIHandler playerUIHandler=other.gameObject.GetComponent<PlayerUIHandler>();
            playerUIHandler.IncreaseHealth();

            Destroy(gameObject);
        }
    }
}
