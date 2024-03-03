using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueRectTransform;
    private float _maxValue;
    public GameObject GamePlayUI;
    public GameObject GameOverScreen;

    private void Start()
    {
        _maxValue = value;
        valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }    

    public void DealDamage(float damage)
    {
        value -= damage;
       
        if (value <= 0)
        {
            GamePlayUI.SetActive(false); 
            GameOverScreen.SetActive(true);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<FireCuster>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;


        }
        valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }

        
    
}



