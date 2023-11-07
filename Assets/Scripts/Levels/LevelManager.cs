using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance{get {return instance;} }
    [SerializeField] string[] Levels;
    void Awake()
    {
        if(instance==null){
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    void Start(){
        if(GetLevelStatus(Levels[0])==LevelStatus.locked){
            SetLevelStatus(Levels[0],LevelStatus.unlocked);
        }
    }

    public void markLevelCompleted(){
        Scene CurrentScene=SceneManager.GetActiveScene();
        SetLevelStatus(CurrentScene.name,LevelStatus.completed);
        // int CurrentSceneIndex=Array.FindIndex(Levels,Level=>Level==CurrentScene.name);
        // int NextSceneNumber=CurrentSceneIndex+1;
        // Scene NextLevel=SceneManager.GetSceneByBuildIndex(NextSceneNumber);
        // if(NextSceneNumber<Levels.Length){
        //     Debug.Log("LevelName Unlocked: "+NextLevel.buildIndex +"Status: "+GetLevelStatus(NextLevel.name));
        //     SetLevelStatus(NextLevel.name,LevelStatus.unlocked);
        //     SceneManager.LoadScene(NextLevel.name);
        // }


    }


    public LevelStatus GetLevelStatus(string level){
        LevelStatus levelName=(LevelStatus)PlayerPrefs.GetInt(level,0);
        return levelName;
    }
    public void SetLevelStatus(string level,LevelStatus levelStatus){
        PlayerPrefs.SetInt(level,(int)levelStatus);
    }
}
