using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSystem : MonoBehaviour
{
    public GameComponent game;
    public TMPro.TextMeshProUGUI timerText;
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
            game.timer = 10.99f;
            GameComponent.OnTimer?.Invoke();
        }

        timerText.text = string.Format("Time: 00:{0:00}", Mathf.FloorToInt(game.timer));
    }
}
