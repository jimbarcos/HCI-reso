using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelScoreboard1 : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text pointsText;


    // Start is called before the first frame update
    void Start()
    {
        int Leveltime1 = PlayerPrefs.GetInt("TimerLvl1");
        int Levelpoints1 = PlayerPrefs.GetInt("PointsLvl1");
        
        if (Leveltime1 == 0 || Levelpoints1 == 0)
        {
            pointsText.text = "---";
            timerText.text = "--:--:--";
        }else
        {
            pointsText.text = Levelpoints1.ToString();

            // Convert Levelpoints1 (assumed to be in milliseconds) to minutes, seconds, and milliseconds
            int minutes = Leveltime1 / 60000; // 1 minute = 60,000 ms
            int seconds = (Leveltime1 / 1000) % 60; // Remaining seconds
            int milliseconds = Leveltime1 % 1000; // Remaining milliseconds

            // Format as mm:ss:ms
            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
