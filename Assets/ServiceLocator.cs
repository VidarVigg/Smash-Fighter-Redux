using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{

    #region Fields
    [SerializeField] private static ITimerService timerService = null;
    #endregion

    #region Properties

    public static ITimerService TimerService
    {
        get { return timerService; }
        set
        {

            if (value == null)
            {
                timerService = new TimerNullProvider();
            }
            timerService = value;

        }
    }

    #endregion

    #region Methods

    public static void Initialize()
    {
        TimerService = new TimerNullProvider();
    }

    #endregion

}
