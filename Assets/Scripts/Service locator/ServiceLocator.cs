using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{

    public static IAudioMasterService audioService = null;

    public static IAudioMasterService AudioService
    {
        get { return audioService; }
        set
        {
            if(audioService == null)
            {
                audioService = new NullAudioServiceProvider();
            }
            audioService = value;
        }
    }

    internal static void Initialize()
    {
        audioService = new NullAudioServiceProvider();
    }
}
