using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    [SerializeField] GameObject Shield;
    [SerializeField] GameObject ShieldUI;
    void Awake()
    {
        Shield.SetActive(false);
        ShieldUI.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerUIHandler>()!=null){
            ShieldActive();
            Destroy(gameObject);
        }
    }

    public void ShieldActive(){
        Shield.SetActive(true);
        ShieldUI.SetActive(true);
    }
}
