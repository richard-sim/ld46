using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFloor : MonoBehaviour
{
    public GameLevelManager GameLevelManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            GameLevelManager.DestroyBall(other.gameObject);

            if (GameLevelManager.State == GameLevelManager.GameState.Playing)
            {
                GameCoordinator.Instance.Health--;
                if (GameCoordinator.Instance.Health == 0)
                {
                    GameLevelManager.ChangeState(GameLevelManager.GameState.Lost);
                }
            }
        }
    }
}
