using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Transform cam;

    void Update()
    {
        gameObject.transform.position =  new Vector3(cam.transform.position.x, cam.transform.position.y + 1.5f, 0);

    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color =  gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color =  gradient.Evaluate(slider.normalizedValue);
    }
}
