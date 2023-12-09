using UnityEngine;
using TMPro;

public class LifeController : MonoBehaviour
{
    private TextMeshProUGUI life;
    private int health=0;
    // Start is called before the first frame update
    void Awake()
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
    private void RefreshUI(){
        life.text="Health: "+health;
    }
}
