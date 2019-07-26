/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public static int clockState = 4;

    public Material red, blue, green, yellow;

    private void OnMouseDown()
    {
        if (GameManager.inRiddle)
        {
            clockState++;
            if (clockState > 4)
                clockState = 1;

            switch (clockState)
            {
                case 1:
                    GetComponent<MeshRenderer>().material = red;
                    break;
                case 2:
                    GetComponent<MeshRenderer>().material = green;
                    break;
                case 3:
                    GetComponent<MeshRenderer>().material = blue;
                    break;
                case 4:
                    GetComponent<MeshRenderer>().material = yellow;
                    break;
            }
        }
    }
}
