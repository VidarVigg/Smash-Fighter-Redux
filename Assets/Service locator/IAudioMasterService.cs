using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudioMasterService
{
    void PlaySound(SoundTypes sound);
    void StopSound(SoundTypes sound, FMOD.Studio.STOP_MODE stopMode);
}
