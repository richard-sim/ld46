using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int life;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (otherGameObject.layer == LayerMask.NameToLayer("BaseLevel"))
        {
        }
        else if (otherGameObject.layer == LayerMask.NameToLayer("Props"))
        {
        }
        else if (otherGameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
        }
        else if (otherGameObject.layer == LayerMask.NameToLayer("Player"))
        {
        }
        else if (otherGameObject.layer == LayerMask.NameToLayer("Collectables"))
        {
        }
        else if (otherGameObject.layer == LayerMask.NameToLayer("PlayerProjectiles"))
        {
            DamageObject damageObj = otherGameObject.GetComponentInParent<DamageObject>();
            if (damageObj != null)
            {
                life = Mathf.Clamp(life - damageObj.Value, 0, life);
                if (life <= 0)
                {
                    Destroy(this.gameObject.transform.parent.gameObject);
                }
            }
        }
        else if (otherGameObject.layer == LayerMask.NameToLayer("EnemyProjectiles"))
        {
        }
    }
}
