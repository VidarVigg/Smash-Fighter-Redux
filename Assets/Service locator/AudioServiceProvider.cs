using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioServiceProvider : MonoBehaviour, IAudioMasterService
{

    public Dictionary<SoundTypes, FMOD.Studio.EventInstance> sounds = new Dictionary<SoundTypes, FMOD.Studio.EventInstance>();

    [FMODUnity.EventRef]
    public string enemyIsHit;
    private FMOD.Studio.EventInstance enemyIsHitEV;

    [FMODUnity.EventRef]
    public string enemyDies;
    private FMOD.Studio.EventInstance enemyDiesEV;

    [FMODUnity.EventRef]
    public string playerDash;
    private FMOD.Studio.EventInstance playerDashEV;

    [FMODUnity.EventRef]
    public string playerIsHit;
    private FMOD.Studio.EventInstance playerIsHitEV;

    [FMODUnity.EventRef]
    public string playerDashRelease;
    private FMOD.Studio.EventInstance playerDashReleaseEV;

    [FMODUnity.EventRef]
    public string enemyShoot;
    private FMOD.Studio.EventInstance enemyShootEV;

    private void Awake()
    {
        enemyIsHitEV = FMODUnity.RuntimeManager.CreateInstance(enemyIsHit);
        enemyDiesEV = FMODUnity.RuntimeManager.CreateInstance(enemyDies);
        playerDashEV = FMODUnity.RuntimeManager.CreateInstance(playerDash);
        playerIsHitEV = FMODUnity.RuntimeManager.CreateInstance(playerIsHit);
        playerDashReleaseEV = FMODUnity.RuntimeManager.CreateInstance(playerDashRelease);
        enemyShootEV = FMODUnity.RuntimeManager.CreateInstance(enemyShoot);

        sounds.Add(SoundTypes.EnemyIsHit, enemyIsHitEV);
        sounds.Add(SoundTypes.EnemyDie, enemyDiesEV);
        sounds.Add(SoundTypes.PlayerDash, playerDashEV);
        sounds.Add(SoundTypes.PlayerIsHit, playerIsHitEV);
        sounds.Add(SoundTypes.PlayerDashRelease, playerDashReleaseEV);
        sounds.Add(SoundTypes.EnemyShoot, enemyShootEV);
    }

    public void PlaySound(SoundTypes sound)
    {
        sounds[sound].start();
    }

    public void StopSound(SoundTypes sound, FMOD.Studio.STOP_MODE stopMode)
    {
        sounds[sound].stop(stopMode);
    }
}
