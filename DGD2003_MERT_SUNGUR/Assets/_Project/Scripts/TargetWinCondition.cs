using UnityEngine;

public class TargetWinCondition : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<CharacterController>() != null)
        {
            Debug.Log("CONGRATULATIONS! YOU PASSED THE SCHOOL AND GRADUATED.");
        }
    }
}