using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoordinator : MonoBehaviour
{
    private static GameCoordinator _instance;
    
    private int _level = 0;
    private int _health = 0;
    private int _ammo = 0;

    public int Level {
        get { return _level; }
    }

    public string LevelName {
        get { return $"level-{_level:D2}"; }
    }

    public int Health {
        get { return _health; }
        set { _health = value; }
    }

    public int Ammo {
        get { return _ammo; }
        set { _ammo = value; }
    }

    public static GameCoordinator Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameCoordinator-" + DateTime.Now.ToString());
                _instance = go.AddComponent<GameCoordinator>();
            }
            return _instance;
        }
    }

    public void ResetGame() {
        Debug.Log("Game reset.");
        
        _level = 0;
        _health = 3;
        _ammo = 0;
    }

    public void LoadNextLevel() {
        _level = _level + 1;
        
        LevelLoader.Instance.LoadLevel(LevelName);
    }

    public void LoadLevel(int level) {
        _level = level;
        
        LevelLoader.Instance.LoadLevel(LevelName);
    }

    private void Awake() {
        if ((_instance != null) && (_instance.GetInstanceID() != this.GetInstanceID())) {
            Debug.LogWarning($"Second GameCoordinator instance detected. Original: '{_instance.gameObject.name}', new: '{this.gameObject.name}'", this);

            _level = _instance._level;
            _health = _instance._health;
            _ammo = _instance._ammo;
            
            Destroy(_instance.gameObject);
            _instance = null;
        }
        
        DontDestroyOnLoad(this.gameObject);

        _instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        ResetGame();
    }

    // Update is called once per frame
    void Update() {
    }
}
