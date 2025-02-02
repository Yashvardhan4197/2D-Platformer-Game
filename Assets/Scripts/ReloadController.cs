using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReloadController : MonoBehaviour
{
    [SerializeField] private Button reload;
    [SerializeField] private Button quit;
    void Awake()
    {
        gameObject.SetActive(false);
        reload.onClick.AddListener(reloadLevel);
        quit.onClick.AddListener(quitLevel);
        
    }
     void Update()
    {
    }

    public void PlayerDead(){
        gameObject.SetActive(true);
    }

    private void reloadLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void quitLevel(){
        SceneManager.LoadScene(0);
    }
}
