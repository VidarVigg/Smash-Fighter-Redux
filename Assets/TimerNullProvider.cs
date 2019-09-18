using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerNullProvider : ITimerService
{
    public void Time(float min, float max, float tick)
    {
        Debug.Log("I am a null provider");
    }
}
