
/* Alexandru Negoescu, Michael Gebhart (UI)
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndFade : MonoBehaviour
{
    public CanvasGroup myCG;
    public static bool flash = false;
    public float fadeFactor = 4;

    public float textInTime = 0.5f, textTime = 4f;
    public Text text; //last text display on screen

    void Start()
    {
        text.enabled = false;
    }

    void Update()
    {
        if (flash)
        {
                myCG.alpha = myCG.alpha + (Time.deltaTime / fadeFactor);
                if (myCG.alpha >= 1f)
                    StartCoroutine(TheEnd());
        }
    }

    IEnumerator TheEnd()
    {
        yield return new WaitForSeconds(textInTime);
        text.enabled = true;
        yield return new WaitForSeconds(textTime);
        Application.Quit();
    }

}
