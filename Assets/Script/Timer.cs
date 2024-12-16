using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class TimerController : MonoBehaviour
{
    public GameObject countdownPanel; // Reference to the CountdownPanel
    public TMP_Text timerText;        // Reference to the TextMeshPro Text to display the timer
    public TMP_Text pointText;
    public TMP_Text trashLeftText;
    string storeTimer = "";
    int minutes;
    int seconds;
    int milliseconds;

    private bool isTimerRunning = false;
    private float elapsedTime = 0f;

    public GameObject levelTrash; // Assign your parent GameObject in the Inspector
    public GameObject levelTrash1;
    public GameObject CongratsPanel;

    public TMP_Text CongratstimerText;        
    public TMP_Text CongratspointText;

    AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        // Check if CountdownPanel is inactive and the timer is not already running
        if (!countdownPanel.activeSelf && !isTimerRunning)
        {
            StartTimer();
        }

        // Update the timer if it's running
        if (isTimerRunning && !CongratsPanel.activeSelf)
        {
            UpdateTimer();
        }
    }

    void StartTimer()
    {
        isTimerRunning = true;
        elapsedTime = 0f; // Reset the timer
    }

    void UpdateTimer()
    {

        int trashLeft = levelTrash.transform.childCount + levelTrash1.transform.childCount;

        trashLeftText.text = "Trashes Left: " + trashLeft.ToString();

        if (levelTrash.transform.childCount == 0 && levelTrash1.transform.childCount == 0 && isTimerRunning)
        {
            audioManager.PlayCongrats(audioManager.CongratsSource);
            int highscore = PlayerPrefs.GetInt("PointsLvl1");

            string input = pointText.text;
            string pattern = @"\d+";
            Match match = Regex.Match(input, pattern);
            
            if (match.Success)
            {
                string number = match.Value;
                if (int.TryParse(number, out int points))
                {
                    Debug.Log("Saved PointsLvl1: " + points);

                    if (points >= highscore)
                    {
                        PlayerPrefs.SetInt("PointsLvl1", points);


                        storeTimer = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
                        // Example: "01:30:25" -> 1 minute, 30 seconds, 25 milliseconds

                        string[] timeParts = storeTimer.Split(':');
                        if (timeParts.Length == 3)
                        {
                            int parsedMinutes = int.Parse(timeParts[0]);
                            int parsedSeconds = int.Parse(timeParts[1]);
                            int parsedMilliseconds = int.Parse(timeParts[2]);

                            int totalMilliseconds = (parsedMinutes * 60 * 1000) + (parsedSeconds * 1000) + parsedMilliseconds;

                            // Retrieve the high score from PlayerPrefs
                            int highScoreMilliseconds = PlayerPrefs.GetInt("TimerLvl1", int.MaxValue);

                            // Compare with the high score
                            if (((totalMilliseconds < highScoreMilliseconds) && highScoreMilliseconds != 0) && points >= highscore)
                            {
                                PlayerPrefs.SetInt("TimerLvl1", totalMilliseconds);
                            }
                        }
                        else
                        {
                            Debug.LogError("Failed to parse storeTimer. Invalid format.");
                        }

                    }


                }
                else
                {
                    Debug.LogError("Failed to parse the number to an integer.");
                }
            }

            
            Debug.Log("No objects left!");
            // Add additional logic here (e.g., load the next level, display a message, etc.)
            isTimerRunning = false;
            CongratspointText.text = pointText.text;
            CongratstimerText.text = timerText.text;
            CongratsPanel.SetActive(true);

            

        } else{
            elapsedTime += Time.deltaTime; // Increment elapsed time

            // Convert elapsedTime to minutes, seconds, and milliseconds
            minutes = Mathf.FloorToInt(elapsedTime / 60f);
            seconds = Mathf.FloorToInt(elapsedTime % 60f);
            milliseconds = Mathf.FloorToInt((elapsedTime * 100f) % 100f);
            timerText.text = string.Format("Timer: {0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
            storeTimer = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);

        }
    }
}
