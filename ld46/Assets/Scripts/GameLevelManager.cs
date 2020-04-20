using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameLevelManager : MonoBehaviour {
    public GameObject GameplayUI;

    public GameObject LevelCompleteUI;

    public GameObject GameWinUI;

    public GameObject GameLostUI;

    public GameObject PauseMenu;

    public GameObject BallParent;
    public GameObject BallPrefab;
    public float BallSpawnRandomness;
    
    private List<GameObject> _liveBalls = new List<GameObject>();

    public List<GameObject> LiveBalls => _liveBalls;

    public List<FlipperController> Flippers = new List<FlipperController>();

    public enum GameState {
        Playing,
        PlayPaused,
        LevelComplete,
        Won,
        Lost
    }

    private GameState _state = GameState.Playing;

    public GameState State {
        get { return _state; }
    }

    public void ChangeState(GameState newState) {
        Debug.Log($"ChangeState({_state} -> {newState})");

        switch (_state) {
            //case GameState.Intro:
            //    Debug.Assert(newState == GameState.Playing);
                
            //    IntroUI.SetActive(false);
            //    GameplayUI.SetActive(true);
                
            //    break;
            
            case GameState.Playing:
                if (newState == GameState.PlayPaused) {
                    PauseMenu.SetActive(true);
                } else if (newState == GameState.LevelComplete) {
                    LevelCompleteUI.SetActive(true);
                } else if (newState == GameState.Won) {
                    GameWinUI.SetActive(true);
                } else if (newState == GameState.Lost) {
                    GameLostUI.SetActive(true);
                }
                else {
                    Debug.LogError("Unhandled state: " + newState);
                }

                break;
            
            case GameState.PlayPaused:
                Debug.Assert(newState == GameState.Playing);

                PauseMenu.SetActive(false);

                break;
            
            case GameState.LevelComplete:
//                Debug.Break();
                Debug.Log("Level complete!");
                break;
            
            case GameState.Won:
//                Debug.Break();
                Debug.Log("Game won!");
                break;
            
            case GameState.Lost:
//                Debug.Break();
                Debug.Log("Game lost!");
                break;
        }

        _state = newState;
    }

    // Awake is called when the script instance is being loaded
    private void Awake() {
        //IntroUI.SetActive(true);
        GameplayUI.SetActive(true);
        LevelCompleteUI.SetActive(false);
        GameWinUI.SetActive(false);
        GameLostUI.SetActive(false);
        PauseMenu.SetActive(false);

        Flippers = new List<FlipperController>(FindObjectsOfType<FlipperController>());
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update() {
        if (_state == GameState.Playing)
        {
            if (_liveBalls.Count == 0)
            {
                Vector3 rnd = Random.onUnitSphere * BallSpawnRandomness;
                rnd.y = 0.0f;
                GameObject go = Instantiate<GameObject>(BallPrefab, BallParent.transform.position + rnd, Quaternion.identity,
                    BallParent.transform);
                _liveBalls.Add(go);
            }
        }
    }
    
    public void DestroyBall(GameObject goBall)
    {
        if (_liveBalls.Remove(goBall))
        {
            Destroy(goBall);
        }
        else
        {
            Debug.LogWarning($"Ball {goBall.name} not found in live ball list! Not destroyed.", goBall);
        }
    }
}
