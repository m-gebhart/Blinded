/* Alexandru Negoescu, Michael Gebhart (PauseUI and Audio)
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool inRiddle = false;
    public static int riddleNumber = 1;
    public CameraScript cameraS;
    public GameObject PauseUI;
    public MusicManager musicScript;
    Pause pauseScript;

    void Start()
    {
        pauseScript = PauseUI.GetComponent<Pause>();
        musicScript = GameObject.Find("/Music").GetComponent<MusicManager>();
        musicScript.StartEvent("Main");
        musicScript.main = true;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseScript.paused)
        {
            PauseUI.SetActive(true);
            pauseScript.InPause();
        }
    }

    public void Riddle()
    {   
        inRiddle = true;
        musicScript.ChangeMusicTrack("Riddle", true);
        Cursor.visible = true;
        cameraS.ManualAdjust();
    }

    public void RiddleExit()
    {
        Cursor.visible = false;
        inRiddle = false;
        riddleNumber++;
    }
}
