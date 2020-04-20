using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameLevelManager GameLevelManager;

    public bool WinGame = false;
    
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
            GameLevelManager.ChangeState(WinGame? GameLevelManager.GameState.Won : GameLevelManager.GameState.LevelComplete);
        }
    }
}
