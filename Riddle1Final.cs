/* Alexandru Negoescu, Michael Gebhart (Audio)
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddle1Final : MonoBehaviour
{
    public MusicManager musicScript;
    public GameManager gameManagerScript;
    
    public static bool[] solved;
    public static int amountSolved = 0;
    /*for Audio*/
    bool progressing = false;

    void Start()
    {
        solved = new bool[4];
        musicScript = GameObject.Find("/Music").GetComponent<MusicManager>();
    }

    public void Check()
    {
        
        if (amountSolved < 3)
        {
            if (LongClockHandle.hour == 3 && DepartureCities.signState == 4 && LongClockHandle.snap == 3)
            {
                if (solved[0] == false)
                {
                    solved[0] = true;
                    Train.position = 2;
                    amountSolved++;
                }
            }
            else if (LongClockHandle.hour == 3 && DepartureCities.signState == 9 && LongClockHandle.snap == 1)
            {
                if (solved[1] == false)
                {
                    solved[1] = true;
                    FatWoman.leave = true;
                    Train.position = 2;
                    amountSolved++;
                }
            }
            else if (LongClockHandle.hour == 2 && DepartureCities.signState == 2 && LongClockHandle.snap == 1)
            {
                if (solved[2] == false)
                {
                    solved[2] = true;
                    Train.position = 2;
                    amountSolved++;
                }
            }
        }
        else
        {
            if (LongClockHandle.hour == 2 && DepartureCities.signState == 1 && LongClockHandle.snap == 3)
            {
                Train.position = 2;
                solved[3] = true;
                gameManagerScript.RiddleExit();
                musicScript.ChangeMusicTrack("RiddleTrain", true);
                CameraScript.transitioning = true;
            }
        }

        if (amountSolved == 1 && !progressing)
        {
            musicScript.playerState.setParameterValue("progress", (float)1);
            progressing = true;
        }

        if (amountSolved == 3)
            musicScript.playerState.setParameterValue("outro", (float)1);
    }
}
