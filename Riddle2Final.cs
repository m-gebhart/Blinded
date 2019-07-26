/* Alexandru Negoescu, Michael Gebhart (Audio)
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddle2Final : MonoBehaviour
{
    public static int solved;
    public GameManager gameManager;
    public float mainDelay = 5f;
    MusicManager musicScript;
    bool mainThemePlaying = false;
    bool exited;
    
    void Start()
    {
        musicScript = GameObject.Find("/Music").GetComponent<MusicManager>();
    }

    void Update()
    {
        if(solved == 10)
        {
            GameObject.Find("couple_0").GetComponent<Animator>().SetBool("phones",true);
            CarnivalStars.turnOff = true;
            //EndRiddle
            if (!mainThemePlaying)
            {
                musicScript.ChangeMusicTrack("RiddleTrain", true);
                StartCoroutine(SetToMain());
                mainThemePlaying = true;
            }

            if (!exited)
            {
                exited = true;
                gameManager.RiddleExit();
            }
            
        }
        else if (solved == 1)
            musicScript.playerState.setParameterValue("progress", 1f);
        else if (solved == 6)
            musicScript.playerState.setParameterValue("outro", 1f);
    }

    IEnumerator SetToMain()
    {
        yield return new WaitForSeconds(mainDelay);
        musicScript.ChangeMusicTrack("Main", true);
    }
}
