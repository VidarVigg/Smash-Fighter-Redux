using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimerService
{
    void Time(float min, float max, float tick);
}
