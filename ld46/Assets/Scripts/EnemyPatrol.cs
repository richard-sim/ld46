using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject patrol;

    private NavMeshAgent m_Enemy;
    private int m_CurrentTarget;
    private int m_PatrolDirection = 1;

    // Start is called before the first frame update
    void Start()
    {
        m_Enemy = gameObject.GetComponentInParent<NavMeshAgent>();
        m_CurrentTarget = 0;
        m_PatrolDirection = 1;

        if (m_Enemy != null)
        {
            if (patrol.transform.childCount > 0)
            {
                m_Enemy.Warp(patrol.transform.GetChild(m_CurrentTarget).position);
                //Debug.Log($"Warping {m_Enemy.gameObject.name} to {patrol.transform.GetChild(m_CurrentTarget).position}");
            }
        }
    }

    bool NeedNewPath()
    {
        if (m_Enemy != null)
        {
            if (!m_Enemy.pathPending)
            {
                if (m_Enemy.remainingDistance <= m_Enemy.stoppingDistance)
                {
                    if (!m_Enemy.hasPath || (m_Enemy.velocity.sqrMagnitude < Mathf.Epsilon))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((m_Enemy != null) && (patrol != null))
        {
            if (patrol.transform.childCount > 1)
            {
                if (NeedNewPath())
                {
                    int lastTarget = m_CurrentTarget;

                    if ((m_CurrentTarget == 0) || (m_CurrentTarget == patrol.transform.childCount - 1))
                    {
                        m_PatrolDirection = -m_PatrolDirection;
                    }

                    m_CurrentTarget =
                        UnityEngine.Mathf.Clamp(m_CurrentTarget + m_PatrolDirection, 0, patrol.transform.childCount - 1);

                    if (lastTarget != m_CurrentTarget)
                    {
                        m_Enemy.SetDestination(patrol.transform.GetChild(m_CurrentTarget).position);
                        //Debug.Log($"Navigating {m_Enemy.gameObject.name} to {patrol.transform.GetChild(m_CurrentTarget).position}");
                    }
                }
            }
        }
    }
}
