using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    //VARIABLES FOR CURRENT SESSIONS
    public string playerName;
    public int currentScore;
    
    //VARIABLES FOR HIGH SCORE SESSION
    //You have to specify this two so that compiler doesn't get angry and other scripts can read them
    public int highScore;
    public string highScoreName;

    private void Awake()
    {
        //if there are 2 MainManagers in scene, destroy this MainManager
        //Happens when the other scene you moved to tries to creates its own MainManager 
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        //But if this is the only one, don't destroy it
        Instance = this;
        
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    //DATA PERSISTANCE ACROSS SCENES PART
    [System.Serializable]
    public class SaveData
    {
        public int highScore;
        public string highScoreName;

    }

    public void SaveHighScore(int currentScore, string playerName)
    {
        //First, create a new instance of the save data 
        SaveData data = new SaveData();

        //Then specify what you want to store
        data.highScore = currentScore;
        data.highScoreName = playerName;

        //Next, transform that instance to JSON with JsonUtility.ToJson: 
        string json = JsonUtility.ToJson(data);

        //Finally, use the special method File.WriteAllText to write a string to a file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }

}
