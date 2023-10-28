using UnityEngine;
using TMPro;

public class LifeController : MonoBehaviour
{
    private TextMeshProUGUI life;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        life=GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void reduce(){
        health--;
        RefreshUI();
    }
    public void setHealth(int h){
        health=h;
        RefreshUI();
    }
    public void RefreshUI(){
        life.text="Health: "+health;
    }
}
