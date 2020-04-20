using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLostMenu : MonoBehaviour
{
    public void OnRetryClicked() {
        LevelLoader.Instance.LoadLevel(GameCoordinator.Instance.LevelName,
            () => {
                GameCoordinator.Instance.ResetGame();
            });
    }

    public void OnMainMenuClicked() {
        LevelLoader.Instance.LoadLevel("StartMenu",
            () => {
                GameCoordinator.Instance.ResetGame();
            });
    }
}
