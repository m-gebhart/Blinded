/* Michael Gebhart
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string arriveSound;
    protected FMOD.Studio.EventInstance arriveState;

    [FMODUnity.EventRef]
    public string leaveSound;
    protected FMOD.Studio.EventInstance leaveState;

    protected bool arrivePlaying = false, leavePlaying = false;
    protected Rigidbody rb;

    protected void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected void StartTrainSound(FMOD.Studio.EventInstance trainState, string path)
    {
        trainState = MusicManager.Create3DSoundInstance(path, this.gameObject);
        trainState.start();
    }

    protected void StopTrainSound(FMOD.Studio.EventInstance trainState)
    {
        trainState.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        trainState.release();      
    }
}
