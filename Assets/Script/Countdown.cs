using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    // Countdown duration in seconds
    public int countdownDuration = 3;

    // Reference to the TextMeshPro UI element
    public TMP_Text countdownText;

    public GameObject CountdownPanel;

    private void Start()
    {
        // Start the countdown
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        int remainingTime = countdownDuration;

        while (remainingTime > 0)
        {
            // Update the UI
            countdownText.text = remainingTime.ToString();

            // Wait for 1 second
            yield return new WaitForSeconds(1f);

            // Decrement the time
            remainingTime--;
        }

        CountdownFinished();
    }

    private void CountdownFinished()
    {
        CountdownPanel.SetActive(false);
    }
}