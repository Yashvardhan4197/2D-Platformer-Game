using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    
    public Animator animator;
    void Start()
    {
        Debug.Log("Start");
    }
    void Update()
    {
        float speed=Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed",Mathf.Abs(speed));
        Vector3 scale=transform.localScale;
        if(speed<0)
        {
            if(scale.x>0)
            {
            scale.x=-1f*scale.x;
            }
        }else if(speed>0)
        {
            scale.x=Mathf.Abs(scale.x);
        }
        transform.localScale=scale;
    }
}
