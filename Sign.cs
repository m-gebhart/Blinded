/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public static int signState = 1;

    public Material red, blue, green, yellow;

    private void OnMouseDown()
    {
        if(GameManager.inRiddle == true)
        {
            signState++;
            if (signState > 4)
            {
                signState = 1;
            }

            switch (signState)
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
