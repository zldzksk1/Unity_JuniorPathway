using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class PlayerDataManger : MonoBehaviour
{
    public static PlayerDataManger Instance;
    public string playerName;
    public int highestScore;

    [System.Serializable]
    class SaveData
    {
        public int highestScore;
    }

    // Start is called before the first frame update
    void Awake() 
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighestScore(); 
    }

    public void SaveHighestScore()
    {
        SaveData myData = new SaveData();
        myData.highestScore = highestScore;

        string json = JsonUtility.ToJson(myData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData myData = JsonUtility.FromJson<SaveData>(json);

            highestScore = myData.highestScore;
        }
    }
}
