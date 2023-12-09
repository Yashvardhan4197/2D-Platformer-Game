using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchLevelUIController : MonoBehaviour
{
    [SerializeField]private Button MoveToLevel;
    [SerializeField]private Button GotoLobby;
    private string NextLevel;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        MoveToLevel.onClick.AddListener(ChangeLevel);
        GotoLobby.onClick.AddListener(GoBacktoLobby);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Completed(string NextLevel){
        gameObject.SetActive(true);
        this.NextLevel=NextLevel;
    }

    private void ChangeLevel(){
        //to Unlock NextLevel
        SceneManager.LoadScene(NextLevel);
        LevelManager.Instance.SetLevelStatus(NextLevel,LevelStatus.unlocked);
    }
    private void GoBacktoLobby(){
        SceneManager.LoadScene("Lobby");
    }
}
