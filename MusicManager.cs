/* Michael Gebhart
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [HideInInspector]
    public bool main, riddle, ending;
    [FMODUnity.EventRef]
    public string Riddle;
    [FMODUnity.EventRef]
    public string RiddleTrain;
    [FMODUnity.EventRef]
    public string Main;
    [FMODUnity.EventRef]
    public string Ending;

    [HideInInspector]
    public string currentTheme;
    public static float volume =1f;

    public FMOD.Studio.EventInstance playerState;

    public void StartEvent(string startingState)
    {
        playerState = StateCase(startingState);
        playerState.setParameterValue("volume", volume);
        playerState.start();
    }

    public void StopEvent(FMOD.Studio.EventInstance stoppingState)
    {
        stoppingState.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        stoppingState.release();
    }

    public void StartEnding()
    {
        playerState = FMODUnity.RuntimeManager.CreateInstance(Ending);
        playerState.setParameterValue("volume", volume);
        playerState.start();
    }

    public void ChangeMusicTrack(string newPlayerState, bool fadeOut)
    {
        FMOD.Studio.EventInstance oldPlayerState;
        oldPlayerState = playerState;
        if (GameManager.riddleNumber == 4 && newPlayerState == "Riddle")
            newPlayerState = "Main";
        StartEvent(newPlayerState);
        currentTheme = newPlayerState;
        if (fadeOut)
            oldPlayerState.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        else if (!fadeOut)
            oldPlayerState.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    FMOD.Studio.EventInstance StateCase(string eventState)
    {
        FMOD.Studio.EventInstance caseState;
        switch (eventState)
        {
            case "Riddle":
                caseState = FMODUnity.RuntimeManager.CreateInstance(Riddle); riddle = true; main = false; break;
            case "RiddleTrain":
                caseState = FMODUnity.RuntimeManager.CreateInstance(RiddleTrain); break;
            case "Main":
                caseState = FMODUnity.RuntimeManager.CreateInstance(Main); main = true; riddle = false;  break;
            case "Ending":
                caseState = FMODUnity.RuntimeManager.CreateInstance(Ending); main = false; riddle = false; break;
            default:
                caseState = playerState; break;
        }
        return caseState;
    }

    public static FMOD.Studio.EventInstance Create3DSoundInstance(string path, GameObject soundObject)
    {
        FMOD.Studio.EventInstance tempState;
        tempState = FMODUnity.RuntimeManager.CreateInstance(path);
        tempState.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(soundObject));
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(tempState, soundObject.GetComponent<Transform>(), soundObject.GetComponent<Rigidbody>());
        return tempState;
    }

    public static bool isEventPlaying(FMOD.Studio.EventInstance playEvent)
    {
        FMOD.Studio.PLAYBACK_STATE tempPlaybackState;
        playEvent.getPlaybackState(out tempPlaybackState);
        if (tempPlaybackState == FMOD.Studio.PLAYBACK_STATE.STOPPED)
            return false;
        else
            return true;
    }

    void Start()
    {
        volume = 1f;
    }
}