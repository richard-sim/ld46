using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Kicker : MonoBehaviour
{
    public float ReboundStrength;
    public float RandomnessStrength;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            float maxPenetration = Single.MinValue;
            foreach (ContactPoint contact in other.contacts)
            {
                if (contact.separation > maxPenetration)
                    maxPenetration = contact.separation;
            }
            
            Vector3 weightedNormal = Vector3.zero;
            foreach (ContactPoint contact in other.contacts)
            {
                weightedNormal += contact.normal * (-contact.separation / maxPenetration);
            }

            weightedNormal *= ReboundStrength;
            weightedNormal += UnityEngine.Random.onUnitSphere * RandomnessStrength;

            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(weightedNormal, ForceMode.Impulse);
            
            // Debug.Log($"Kicked {weightedNormal}", this);
        }
    }
}
