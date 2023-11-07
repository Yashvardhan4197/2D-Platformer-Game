using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{
    [SerializeField]private  string CurrentLevel;
    [SerializeField]private string NextLevel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player"){
            LevelManager.Instance.markLevelCompleted();
        }
    }
}
