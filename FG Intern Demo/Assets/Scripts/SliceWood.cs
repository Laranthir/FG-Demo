using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceWood : MonoBehaviour
{

    public GameObject destroyedVersion;

    private bool isColliding;
    private void OnCollisionEnter(Collision other)
    {
        if(isColliding) return;
        isColliding = true;
        
        if (other.gameObject.tag == "Saw")
        {
            if (other.GetContact(0).thisCollider.gameObject.name == "Hitbox")
            {
                Instantiate(destroyedVersion, transform.position, transform.rotation);
                Destroy(gameObject);
            }

        }
    }

    private void Update()
    {
        isColliding = false;
    }
}
