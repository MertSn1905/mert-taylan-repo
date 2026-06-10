using UnityEngine;
using UnityEngine.AddressableAssets; 

public class AddressableSpawner : MonoBehaviour
{
    [Header("Addressable Ayarlarý")]
    [Tooltip("The Eye of Sauron prefabýný buraya sürükleyin")]
    public AssetReference sauronEyePrefab;

    void Start()
    {
        
        Addressables.InstantiateAsync(sauronEyePrefab, transform.position, transform.rotation);
    }
}