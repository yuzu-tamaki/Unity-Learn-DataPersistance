using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBestScore : MonoBehaviour
{
    public Text bestScoreText;

    private bool dummy;
    
    // Start is called before the first frame update
    void Start()
    {
        MainManager.Instance.LoadHighScore();
        
        Debug.Log("High Score is " + MainManager.Instance.highScore);
        
        //DISPLAY HIGH SCORE AND PLAYER
        if (MainManager.Instance != null)
        {
            if (MainManager.Instance.highScore != 0)
            {
                DisplayHighScore();
            }
            else
            {
                DisplayName();
            }
            
        }
        else
        {
            bestScoreText.text = "Hello";
            //DisplayName();
        }
        
        //DISPLAY 
        /*if (MainManager.Instance != null)
        {
            
            //DisplayName(MainManager.Instance.PlayerName);
        }
        else
        {
            DisplayName("Ash Ketchum");
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplayHighScore()
    {
        bestScoreText.text = MainManager.Instance.playerName + ", can you beat the High Score " + MainManager.Instance.highScore + " by "+ MainManager.Instance.highScoreName + "?";
    }
    
    void DisplayName()
    {
        bestScoreText.text = MainManager.Instance.playerName + ", set a High Score!";
    }
}
