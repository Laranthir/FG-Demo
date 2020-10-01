using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public CameraShake cameraShake;
    [SerializeField] private GameObject spark = null;
    private Touch touch;
    private float speedModifier;
    void Start()
    {
        speedModifier = 0.00075f;
    }
    void Update()
    {
        //Rotate blades
        transform.Rotate (0,0,50*Time.deltaTime); 
        
        //Blade controller script
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                gameObject.transform.parent.position = new Vector3(transform.position.x, transform.position.y,
                    transform.position.z + touch.deltaPosition.x * speedModifier);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        spark.SetActive(true);
        if (other.gameObject.tag == "Log")
        {
            if (other.GetContact(0).otherCollider.gameObject.name == "Hitbox")
                StartCoroutine(cameraShake.Shake(.15f, .4f));
        }
    }
    private void OnCollisionExit(Collision other)
    {
        spark.SetActive(false);
    }
}