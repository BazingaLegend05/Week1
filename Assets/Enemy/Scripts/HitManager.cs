using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HitManager : MonoBehaviour
{
    [SerializeField]
    float hitPoints = 25;
    [SerializeField]
    int pointValue = 5;
    void Hit(float rawDamage)
    {
        hitPoints -= rawDamage;
        if (hitPoints <= 0)
        {
            Invoke("SelfTerminate", 0f);
        }
    }
    void SelfTerminate()
    {
        GameManager.IncrementScore(pointValue);
        Debug.Log("Enemy Dead");
        Destroy(gameObject);
    }
}
