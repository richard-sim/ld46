using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float maxLifetime;

    private float m_StartTime;

    // Start is called before the first frame update
    void Start()
    {
        m_StartTime = Time.fixedTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Time.fixedTime - m_StartTime) > maxLifetime)
        {
            Destroy(this.gameObject);
        }
    }

    // Only called when one of the objects' RigidBody is non-kinematic!
    private void OnCollisionEnter(Collision collision)
    {
        //ContactPoint contact = collision.contacts[0];
        //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        //Vector3 pos = contact.point;
        //Instantiate(explosionPrefab, pos, rot);
        //Destroy(gameObject);

        ProcessCollision(collision.gameObject);
    }

    // Called regardless of if there are non-kinematic RigidBody's involved
    private void OnTriggerEnter(Collider other)
    {
        ProcessCollision(other.gameObject);
    }

    // Called regardless of if there are non-kinematic RigidBody's involved
    private void ProcessCollision(GameObject otherGameObject)
    {
        bool shouldDestroy = false;

        if (otherGameObject.layer == LayerMask.NameToLayer("BaseLevel"))
        {
            shouldDestroy = true;
        }
        else if (otherGameObject.layer == LayerMask.NameToLayer("Props"))
        {
        }
        else if (otherGameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            shouldDestroy = true;
        }
        else if (otherGameObject.layer == LayerMask.NameToLayer("Player"))
        {
            shouldDestroy = true;
        }
        else if (otherGameObject.layer == LayerMask.NameToLayer("Collectables"))
        {
        }
        else if (otherGameObject.layer == LayerMask.NameToLayer("PlayerProjectiles"))
        {
        }
        else if (otherGameObject.layer == LayerMask.NameToLayer("EnemyProjectiles"))
        {
        }

        if (shouldDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}
