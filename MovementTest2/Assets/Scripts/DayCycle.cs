using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCycle : MonoBehaviour
{
    private int DayCounter;
    public Text dayHolder;
    public UnityEvent OnDayChanged;


    private void Awake()
    {
        DayCounter = 0;
    }
    private void Update()
    {
        
    }

    private void ToNextDay()
    {
        DayCounter++;
        OnDayChanged?.Invoke();
    }

    private int CurrentDay()
    {
        return DayCounter;
    }

    public void DisplayCurrentDay()
    {
        dayHolder.text = DayCounter.ToString();
    }

    //Triggered by user choosing to end day
    public void EndCurrentDay()
    {
        // End Results of the current day
        Debug.Log("Ending day " + DayCounter);
        ToNextDay();
        Debug.Log("Proceeding to " + DayCounter);
    }
}
