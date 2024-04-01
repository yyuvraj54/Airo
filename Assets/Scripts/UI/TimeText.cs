using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeText : MonoBehaviour
{

    public TMP_Text timeText;
    public TMP_Text dateText;
    public TMP_Text dayText;

    void Update()
    {
        // Get the current system time
        System.DateTime currentTime = System.DateTime.Now;

        // Update the time text
        if (timeText != null)
        {
            timeText.text =  currentTime.ToString("HH:mm:ss");
        }

        // Update the date text
        if (dateText != null)
        {
            dateText.text =  currentTime.ToString("yyyy-MM-dd");
        }

        // Update the day text
        if (dayText != null)
        {
            dayText.text =  currentTime.DayOfWeek.ToString();
        }

    }   
}
