
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    [SerializeField] private Button start_button;
    [SerializeField] private Button endLevel_button;
    [SerializeField] GameObject levelsUI;
    // Start is called before the first frame update
    void Awake()
    {
        start_button.onClick.AddListener(startLevel);
        endLevel_button.onClick.AddListener(Endlevel);
        levelsUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void startLevel(){
        levelsUI.SetActive(true);
    }
    private void Endlevel(){
        Application.Quit();
    }
}
