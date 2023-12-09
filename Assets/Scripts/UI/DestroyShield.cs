using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShield : MonoBehaviour
{
    public int count=3;
    [SerializeField] ShieldUI shieldUI;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<EnemyController>()!=null&&count>0){
            count--;
            shieldUI.countReduceUI();
        }
        if(count<=0){
            gameObject.SetActive(false);
        }
    }
    
}
