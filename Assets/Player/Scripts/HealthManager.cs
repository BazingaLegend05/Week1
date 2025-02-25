using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    [SerializeField] 
    float maxHitPoints = 100f;
    public float hitPoints;

    public Slider healthSlider;
    void Start()
    {
        hitPoints = maxHitPoints;
        SetHealthSlider();
    }
    public void Hit(float rawDamage)
    {
        hitPoints -= rawDamage;
        SetHealthSlider();
        Debug.Log("OUCH: " + hitPoints.ToString());
        if (hitPoints <= 0)
        {
            Debug.Log("TODO: GAME OVER - YOU DIED");
        }
    }
    void SetHealthSlider()
    {
        if (healthSlider != null)
        {
            healthSlider.value = NormalisedHitPoints();
        }
    }
    float NormalisedHitPoints()
    {
        return hitPoints / maxHitPoints;
    }
    public void MedKit(float rawHealth)
    {
        hitPoints += rawHealth;
        if (hitPoints > maxHitPoints)
        {
            hitPoints = maxHitPoints;
        }
        Debug.Log("YAY: " + hitPoints.ToString());
        SetHealthSlider() ;
    }
}
