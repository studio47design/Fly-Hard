using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }


    private int highScore;
    private string highScoreString;
    private string playerName;

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string highScoreString;
        public int highScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;
        data.highScoreString = highScoreString;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "highscore.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "highscore.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            highScoreString = data.highScoreString;
            highScore = data.highScore; 
        }
    }

    public void SetName(string name) => playerName = name;

    public string GetName() { return playerName; }

    public void SetHighScore(string scoreString, int score)
    {
        highScoreString = scoreString;
        highScore = score;
    }

    public int GetHighScore() { return highScore; }

    public string GetHighScoreString() { return highScoreString; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }
    
}
