using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class NullAudioServiceProvider : MonoBehaviour, IAudioMasterService
{
    public void PlaySound(SoundTypes sound)
    {
        throw new System.NotImplementedException();
    }

    public void StopSound(SoundTypes sound, FMOD.Studio.STOP_MODE stopMode)
    {
        throw new System.NotImplementedException();
    }
}
