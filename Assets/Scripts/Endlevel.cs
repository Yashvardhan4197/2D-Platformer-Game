using UnityEngine;
using UnityEngine.SceneManagement;

public class Endlevel : MonoBehaviour
{
    [SerializeField] private ReloadController reloadController;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player"){
            reloadController.PlayerDead();
        }
    }
}
