using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour {
    public GameLevelManager LevelManager;
    public PaddleController Player;
    
    public TMP_Text CurrentLevelText;
    public TMP_Text CurrentHealthText;
    public TMP_Text CurrentAmmoText;

    // Update is called once per frame
    void Update() {
        CurrentLevelText.text = $"Level {GameCoordinator.Instance.Level + 1}";

        if (GameCoordinator.Instance.Health > 0)
            CurrentHealthText.text = $"Balls: {GameCoordinator.Instance.Health}";
        else
            CurrentHealthText.text = $"All balls lost";

        CurrentAmmoText.text = $"Ammo: {GameCoordinator.Instance.Ammo}";

        //int timeRemaining = Player.PotionTime - Player.PotionTimeElapsed;
        //int potionMins = timeRemaining / 60;
        //int potionSecs = timeRemaining % 60;
        //PotionTimerText.text = $"{potionMins}:{potionSecs:D2}";

        //TradeBloodButton.interactable = (GameCoordinator.Instance.Health > Player.PotionCost);
    }
}
