using TMPro;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    public GameObject levelTrash; // Assign your parent GameObject in the Inspector
    public GameObject levelTrash1;
    public TMP_Text timerText;

    void Update()
    {
        // Check if there are no children left under levelTrash
        if (levelTrash.transform.childCount == 0 && levelTrash1.transform.childCount == 0)
        {
            Debug.Log("No objects left!");
            // Add additional logic here (e.g., load the next level, display a message, etc.)
        }
    }
}
