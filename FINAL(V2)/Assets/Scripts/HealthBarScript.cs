using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    
    public Slider slider;
	//public Gradient gradient;
	public Image fill;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = GameManager.instance.playerHealth;
        slider.value = GameManager.instance.playerHealth;

        //fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = GameManager.instance.playerHealth;

        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
