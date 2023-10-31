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

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LoadLevel(){
        SceneManager.LoadScene(levelname);
    }
}
