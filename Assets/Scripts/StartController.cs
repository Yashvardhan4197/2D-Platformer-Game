
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    [SerializeField] private Button start_button;
    [SerializeField] private Button endLevel_button;
    [SerializeField] private Button goback;
    [SerializeField] GameObject levelsUI;
    // Start is called before the first frame update
    void Awake()
    {
        start_button.onClick.AddListener(startLevel);
        endLevel_button.onClick.AddListener(Endlevel);
        goback.onClick.AddListener(GoBack);
        levelsUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void startLevel(){
        levelsUI.SetActive(true);
        SoundManager.Instance.PlaySound(Sound.ButtonClick);
    }
    private void Endlevel(){
        Application.Quit();
        SoundManager.Instance.PlaySound(Sound.ButtonClick);
    }
    private void GoBack(){
        levelsUI.SetActive(false);
        SoundManager.Instance.PlaySound(Sound.ButtonClick);
    }
}
