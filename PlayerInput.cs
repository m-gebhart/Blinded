/* Michael Gebhart
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static bool MoveToRight()
    {
        if (CameraScript.inputPossible && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
            return true;
        else
            return false;
    }

    public static bool MoveToLeft()
    {
        if (CameraScript.inputPossible && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
            return true;
        else
            return false;
    }
}
