using UnityEngine;
using UnityEngine.Events;

public class TargetInteract : MonoBehaviour
{
    public UnityEvent onVuruldu;
    public GameObject patlamaEfekti; // Hafýzadan veya Addressables'tan gelecek efekt prefab'ý

    public void Activate()
    {
        // Küre yok olmadan hemen önce efekti kendi pozisyonunda yaratýr
        if (patlamaEfekti != null)
        {
            Instantiate(patlamaEfekti, transform.position, transform.rotation);
        }

        // Oyunun baþladýðýndan beri geçen süreyi (skor olarak) JSON'a kaydeder
        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.SaveGame(Time.timeSinceLevelLoad);
        }

        // Küreyi kapatacak olan eventi tetikler
        onVuruldu.Invoke();
    }
}