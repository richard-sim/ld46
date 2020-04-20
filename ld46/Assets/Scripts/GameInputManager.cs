using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputManager : MonoBehaviour
{
    public GameLevelManager LevelManager;

    void Update()
    {
        if (LevelManager.State == GameLevelManager.GameState.Playing)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                LevelManager.ChangeState(GameLevelManager.GameState.PlayPaused);
            }

//        } else if (LevelManager.State == GameLevelManager.GameState.InStore) {
//            if (Input.GetButtonDown("Cancel")) {
//                LevelManager.ChangeState(GameLevelManager.GameState.Playing);
//            }
//        } else if (LevelManager.State == GameLevelManager.GameState.Attacking) {
//            if (Input.GetButtonDown("Cancel")) {
////                Player.CancelAttack();
//            }
        }
    }
}
