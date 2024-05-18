using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour

{
    public Slider slider;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}