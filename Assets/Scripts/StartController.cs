
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    [SerializeField] private Button start_button;
    [SerializeField] private Button endLevel_button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        start_button.onClick.AddListener(startLevel);
        endLevel_button.onClick.AddListener(Endlevel);
    }

    private void startLevel(){
        SceneManager.LoadScene(1);
    }
    private void Endlevel(){
        Application.Quit();
    }
}
