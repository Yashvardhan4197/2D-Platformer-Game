using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchLevel : MonoBehaviour
{
    [SerializeField]private  string CurrentLevel;
    [SerializeField]private string NextLevel;
    
    [SerializeField]SwitchLevelUIController switchLevelUIController;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player"){
            LevelManager.Instance.markLevelCompleted();
            switchLevelUIController.Completed(NextLevel);

            SoundManager.Instance.PlaySound(Sound.ChangeLevel);
        }
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
