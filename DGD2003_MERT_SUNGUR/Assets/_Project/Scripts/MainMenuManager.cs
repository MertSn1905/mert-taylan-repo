using UnityEngine;
using UnityEngine.SceneManagement; // Sahne geçiþleri için
using UnityEngine.UI; // UI elemanlarý için

public class MainMenuManager : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        
        if (volumeSlider != null)
        {
            volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        }
    }

    // Play butonuna basýldýðýnda çalýþacak fonksiyon
    public void PlayGame()
    {
        // 1 indeksli sahneyi (Ana Oyun Sahnesi) yükler
        SceneManager.LoadScene(1);
    }

    // Slider her oynatýldýðýnda çalýþacak ve deðeri kaydedecek fonksiyon
    public void SaveVolume(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save(); // Veriyi diske kalýcý olarak yazar
        Debug.Log("Ses Ayarý PlayerPrefs ile Kaydedildi: " + value);
    }
}