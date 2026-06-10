using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetLoader : MonoBehaviour
{
    
    public string assetAddress = "Assets/_Project/Prefabs/The Eye of Sauron.fbx";

    void Start()
    {
        // Oyun baþladýðý an Sauron'un Gözü'nü RAM'i yormadan dinamik olarak sahneye çaðýrýr
        Addressables.InstantiateAsync(assetAddress, transform.position, transform.rotation);
        Debug.Log("Sauron'un Gözü Addressables sistemi ile baþarýyla yüklendi!");
    }
}