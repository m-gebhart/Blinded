/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using UnityEngine;
using UnityEngine.UI;  // add to the top
using System.Collections;

public class WhiteScreenTransition : MonoBehaviour
{

    public CanvasGroup myCG;
    private bool flash = false;
    bool fadein;
    public float fadeFactor = 5;

    void Update()
    {
        if (flash)
        {
            if (fadein)
            {
                myCG.alpha = myCG.alpha + (Time.deltaTime / fadeFactor);
                if(myCG.alpha >= 1f)
                {
                    Train2.position++;
                    CameraScript.stay = false;
                    fadein = false;
                }
            }
            else
            {
                myCG.alpha = myCG.alpha - (Time.deltaTime / fadeFactor);
            }
            if (myCG.alpha <= 0)
            {
                myCG.alpha = 0;
                flash = false;
                CameraScript.transitioning = false;
            }
        }
    }

    public void Transition()
    {
        flash = true;
        fadein = true;
    }
}