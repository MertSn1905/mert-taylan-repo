using UnityEngine;
using System.IO; 


[System.Serializable]
public class SaveData
{
    public string playerName;
    public float bestTime;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance; 
    public SaveData currentData = new SaveData();
    private string savePath;

    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }

        
        savePath = Path.Combine(Application.persistentDataPath, "mordor_save.json");
        LoadGame();
    }

    
    public void SaveGame(float finishedTime)
    {
        
        if (currentData.bestTime == 0 || finishedTime < currentData.bestTime)
        {
            currentData.playerName = "Mert Sungur";
            currentData.bestTime = finishedTime;

            
            string json = JsonUtility.ToJson(currentData, true);

            
            File.WriteAllText(savePath, json);
            Debug.Log("Oyun Baþarýyla Kaydedildi! Yol: " + savePath);
        }
    }

    
    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            
            string json = File.ReadAllText(savePath);

            
            currentData = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Eski Kayýt Yüklendi! En Ýyi Süre: " + currentData.bestTime);
        }
        else
        {
            Debug.Log("Kayýt dosyasý bulunamadý, yeni temiz profil açýldý.");
        }
    }
}