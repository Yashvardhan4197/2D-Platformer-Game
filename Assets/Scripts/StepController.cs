using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEditor;
using UnityEngine;

public class StepController : MonoBehaviour
{
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;
    [SerializeField] int Speed;
    bool change;
    void Update()
    {
        if(change==true){
            transform.position=Vector2.MoveTowards(transform.position,pos1.position,Speed*Time.deltaTime);

            if(Vector2.Distance(transform.position,pos1.position)<1f){
                change=false;
            }
        }     
        if(change==false){
            transform.position=Vector2.MoveTowards(transform.position,pos2.position,Speed*Time.deltaTime);

            if(Vector2.Distance(transform.position,pos2.position)<1f){
                change=true;
            }
        }  
    }
}
