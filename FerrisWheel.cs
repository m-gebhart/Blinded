/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisWheel : MonoBehaviour
{
    public static int snap;
    private float baseAngle = 0.0f;
    public static float currentAngle = 0.0f;

    void OnMouseDown()
    {
        if (GameManager.inRiddle == true && GameManager.riddleNumber == 2)
        {
            //Storing the angle between mouse and red axis
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            pos = Input.mousePosition - pos;
            baseAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
            baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
       }
    }

    void OnMouseDrag()
    {
        if (GameManager.inRiddle == true && GameManager.riddleNumber == 2)
       {
            //Keeping the same angle throughout mouse movement
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            pos = Input.mousePosition - pos;
            float ang = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - baseAngle;
            transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
            currentAngle = -transform.eulerAngles.z;
        }
    }

    void OnMouseUp()
    {
        if (GameManager.inRiddle == true && GameManager.riddleNumber == 2)
        {
            //Finding out what to snap to
            float rotation = transform.eulerAngles.z;
            snap = (int)Mathf.Round(rotation / 30);

            //Actual snapping
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 30 * snap);
            currentAngle = -transform.eulerAngles.z;
        }
    }
}

