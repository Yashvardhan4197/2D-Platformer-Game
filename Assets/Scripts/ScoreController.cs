using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreUI;
    private int score=0;
    void Awake()
    {
        scoreUI=GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        score=0;
        RefreshUI();
    }
     public void Scoreincrement(int increment){
        score+=increment;
        RefreshUI();
     }

     public void RefreshUI(){
        scoreUI.text="Score: "+score;
     }
}
