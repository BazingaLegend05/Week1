using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    Transform cameraTransform;
    float range = 100f;
    [SerializeField]
    float rawDamage = 10f;


    void Update()
    {
        if (!MenuController.IsGamePaused)
        {
            if (Time.deltaTime > 0)
            {
                FireWeapon();
            }
        }
    }
    void FireWeapon()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            cameraTransform = Camera.main.transform;
            Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
            RaycastHit raycastHit;
            int passThroughLayerMask = LayerMask.GetMask("Player");
            if (Physics.Raycast(ray, out raycastHit, range, ~passThroughLayerMask))
            {
                if (raycastHit.transform != null)
                {
                    raycastHit.collider.SendMessageUpwards("Hit", rawDamage, SendMessageOptions.DontRequireReceiver);
                    Debug.Log("Player shot at enemy");
                }
            }
            else
            {
                Debug.Log("NO RAYCAST");
            }
        }
    }
}
