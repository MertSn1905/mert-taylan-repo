using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float weaponRange = 100f;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            
            Vector3 rayOrigin = transform.position + Vector3.up * 1.5f;

            if (Physics.Raycast(rayOrigin, transform.forward, out hit, weaponRange))
            {
                Debug.Log("Vurduðumuz obje: " + hit.transform.name);

                
                TargetInteract target = hit.transform.GetComponent<TargetInteract>();
                if (target != null)
                {
                    target.Activate();
                }
            }
        }
    }
}