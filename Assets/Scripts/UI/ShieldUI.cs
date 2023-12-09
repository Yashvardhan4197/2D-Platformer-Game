using TMPro;
using UnityEngine;

public class ShieldUI : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] DestroyShield destroyShield;


    
    void Start()
    {
        textMeshProUGUI=GetComponent<TextMeshProUGUI>();
        RefreshUI();
    }
    public void countReduceUI(){
        if(destroyShield.count<=0){
            gameObject.SetActive(false);
        }
        RefreshUI();
    }

    private void RefreshUI(){
        textMeshProUGUI.text="Shield: "+destroyShield.count;
    }
}
