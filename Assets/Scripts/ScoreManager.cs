using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public string BestScoreName;
    public int BestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedScore savedScore = JsonUtility.FromJson<SavedScore>(json);
            BestScore = savedScore.BestScore;
            BestScoreName = savedScore.BestScoreName;
        }
    }
    public void SaveData()
    {
        SavedScore savedScore = new SavedScore();
        savedScore.BestScore = BestScore;
        savedScore.BestScoreName = BestScoreName;

        string json = JsonUtility.ToJson(savedScore);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
[System.Serializable]
class SavedScore
{
    public string BestScoreName;
    public int BestScore;
}
