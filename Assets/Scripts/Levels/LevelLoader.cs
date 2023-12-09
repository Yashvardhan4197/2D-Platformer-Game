using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] string levelname;
    [SerializeField] Button level;
    // Start is called before the first frame update
    void Awake()
    {
        level.onClick.AddListener(LoadLevel);
    }
    void Start(){
        
    }
    private void LoadLevel(){
        LevelStatus levelStatus=LevelManager.Instance.GetLevelStatus(levelname);
        switch(levelStatus){
            case LevelStatus.locked:{
                Debug.Log("Locked_Level");
                SoundManager.Instance.PlaySound(Sound.ButtonClick);
                break;}
            case LevelStatus.unlocked:{
                SceneManager.LoadScene(levelname);
                SoundManager.Instance.PlaySound(Sound.ButtonClick);
                break;}
             case LevelStatus.completed:{
                SceneManager.LoadScene(levelname);
                SoundManager.Instance.PlaySound(Sound.ButtonClick);
                break;
             }
        
        }
    }
}
