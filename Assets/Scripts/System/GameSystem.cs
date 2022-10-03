using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public FinishComponent finish;
    public GameComponent game;
    public LevelComponent level;
    // Start is called before the first frame update
    void Start()
    {
        finish.gameObject.SetActive(false);
        GameComponent.OnGameStart?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if(level.players.Count == 0)
        {
            enabled = false;
            finish.scoreText.text = "SCORE: " + game.playerScore;
            finish.gameObject.SetActive(true);
        }
    }
}
