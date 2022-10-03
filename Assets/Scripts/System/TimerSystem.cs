using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSystem : MonoBehaviour
{
    public GameComponent game;
    public Sprite[] timerSprites;
    public Sprite[] timerSprites2;
    public Image timerImage;
    public Image timerImage2;
    public TMPro.TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        game.timer -= Time.deltaTime;
        if(game.timer <=0f)
        {
            game.timer = 9.99f;
            GameComponent.OnTimer?.Invoke();
        }

        scoreText.text = "SCORE: " + game.playerScore;
        timerImage.sprite = timerSprites[Mathf.FloorToInt(game.timer)];
        timerImage2.sprite = timerSprites2[Mathf.FloorToInt(game.timer)];
    }
}
