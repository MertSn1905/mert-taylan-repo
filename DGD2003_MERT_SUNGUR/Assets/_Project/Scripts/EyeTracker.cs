using UnityEngine;

public class EyeTracker : MonoBehaviour
{
    void Update()
    {
     
        Vector3 mousePosition = Input.mousePosition;

        
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;

        
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        
        transform.LookAt(targetPosition);
    }
}
