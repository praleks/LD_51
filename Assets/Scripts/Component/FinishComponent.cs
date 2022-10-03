using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishComponent : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
