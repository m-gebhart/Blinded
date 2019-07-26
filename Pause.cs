/* Michael Gebhart
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [Tooltip("Pitch's decrease of Music during Pause (from 0.0f/st to 1.0f/st)")]
    public float pitchValue;
    [HideInInspector]
    public bool paused = false;
    bool credits = false;
    public GameObject creditsText, creditsBg, leaveCreditsButton;

    public MusicManager musicScript;
    public Color defaultCol, selectCol;
    public Slider volSlider;

    public Text[] texts;

    void Start()
    {
        volSlider.value = MusicManager.volume;
        for (int txt = 0; txt < texts.Length; txt++)
        {
            texts[txt].color = defaultCol;
        }
        CreditsScreen(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused)
            Resume();
    }

    public void InPause()
    {
        Time.timeScale = 0f;
        paused = true;
        Cursor.visible = true;
        musicScript.playerState.setParameterValue("pitch", pitchValue);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        paused = false;
        if (!GameManager.inRiddle)
            Cursor.visible = false;
        musicScript.playerState.setParameterValue("pitch", 0f);
        texts[2].color = defaultCol; //getting Resume back to default
        this.gameObject.SetActive(false);
    }

    public void CheckVolume()
    {
        MusicManager.volume = volSlider.value;
        musicScript.playerState.setParameterValue("volume", volSlider.value);
    }

    public void Credits()
    {
        CreditsScreen(true);
    }

    public void LeaveCredits()
    {
        CreditsScreen(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartMouseOver(Text txt)
    {
        txt.color = selectCol;
    }

    public void ExitMouseOver(Text txt)
    {
        txt.color = defaultCol;
    }

    void CreditsScreen(bool crdts)
    {
        credits = crdts;
        creditsBg.SetActive(crdts);
        creditsText.SetActive(crdts);
        leaveCreditsButton.SetActive(crdts);
    }
}
