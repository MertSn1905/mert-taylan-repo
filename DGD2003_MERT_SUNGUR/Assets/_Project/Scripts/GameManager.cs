using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Yazýlar için gerekli kütüphane

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI resultText;

    public void WinGame()
    {
        gameOverPanel.SetActive(true);
        resultText.text = "YOU WIN!";
        resultText.color = Color.green; // Kazanma rengi
        EndGameSetup();
    }

    public void LoseGame()
    {
        gameOverPanel.SetActive(true);
        resultText.text = "YOU LOSE!";
        resultText.color = Color.red; // Kaybetme rengi
        EndGameSetup();
    }

    private void EndGameSetup()
    {
        Time.timeScale = 0f; // Oyunu (zamaný) durdurur
        Cursor.lockState = CursorLockMode.None; // Mouse'u serbest býrakýr
        Cursor.visible = true; // Mouse imlecini ekranda gösterir
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Zamaný tekrar normale döndür
        SceneManager.LoadScene(0); // 0 numaralý sahneyi (MainMenu) yükle
    }
}