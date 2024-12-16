using UnityEngine;
using UnityEngine.EventSystems;

public class TrashCan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trash can has the "Draggable" tag
        if (other.CompareTag("Trash"))
        {
            // Destroy the object
            Destroy(other.gameObject);
            Debug.Log("Trash Destroyed: " + other.gameObject.name);
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    // Optional: For safety, you can also handle if the object lingers
    //    if (other.CompareTag("Trash"))
    //    {
    //        Destroy(other.gameObject);
    //    }
    //}
}
