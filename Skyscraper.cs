/* Alexandru Negoescu, Michael Gebhart (Audio)
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skyscraper : MonoBehaviour
{
    public GameManager gameManager;

    private void OnMouseDown()
    {
        Girls.lampsOn = true;
        MusicManager musicScript = GameObject.Find("/Music").GetComponent<MusicManager>();
        musicScript.ChangeMusicTrack("Main", true);
        musicScript.playerState.setParameterValue("progress", 1f);
        gameManager.RiddleExit();
    }
}
