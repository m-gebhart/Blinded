/* Alexandru Negoescu, Michael Gebhart (Audio)
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddle3 : MonoBehaviour
{
    int currentStrip = 1;
    public Lamp lamp1, lamp2, lamp3, lamp4, lamp5, lamp6;

    public void Check(int i)
    {
        if(i == currentStrip)
        {
            if(i == 1)
            {
                lamp1.LightsOut();
                lamp2.LightsOut();
                lamp3.LightsOut();
                lamp4.LightsOut();
                lamp5.LightsOut();
                lamp6.LightsOut();
            }
            currentStrip++;
        }
        else
        {
            lamp1.LightsOut();
            lamp2.LightsOut();
            lamp3.LightsOut();
            lamp4.LightsOut();
            lamp5.LightsOut();
            lamp6.LightsOut();
            currentStrip = 1;
        }
        if(currentStrip == 7)
        {
            Cursor.visible = false;
            MusicManager musicScript = GameObject.Find("/Music").GetComponent<MusicManager>();
            musicScript.ChangeMusicTrack("Ending", false);
            GameManager.riddleNumber++;
        }
        switch (i)
        {
            case 1: lamp1.LightsOn();
                break;
            case 2:
                lamp2.LightsOn();
                break;
            case 3:
                lamp3.LightsOn();
                break;
            case 4:
                lamp4.LightsOn();
                break;
            case 5:
                lamp5.LightsOn();
                break;
            case 6:
                lamp6.LightsOn();
                break;
        }
    }
}
