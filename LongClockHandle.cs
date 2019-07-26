/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongClockHandle : MonoBehaviour
{
    private float baseAngle = 0.0f;
    public static int snap;
    public static float currentAngle = 0.0f;
    public static int hour = 0;
    float angleBefore;
    public Riddle1Final riddle1finalScript;

    void OnMouseDown()
    {
        if (GameManager.inRiddle == true && GameManager.riddleNumber == 1)
        {
            if (Train.position == 1)
            {
                //Storing the angle between mouse and red axis
                Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                pos = Input.mousePosition - pos;
                baseAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
                baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
            }
        }
    }

    void OnMouseDrag()
    {
        if (GameManager.inRiddle == true && GameManager.riddleNumber == 1)
        {
            if (Train.position == 1)
            {
                angleBefore = transform.eulerAngles.z;
                //Keeping the same angle throughout mouse movement
                Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                pos = Input.mousePosition - pos;
                float ang = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - baseAngle;
                transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
                currentAngle = transform.eulerAngles.z;

                if (Mathf.Abs(currentAngle - angleBefore) > 180)
                {
                    if (transform.eulerAngles.z < 180)
                    {
                        hour++;
                        if (hour == 12)
                        {
                            hour = 0;
                        }
                    }
                    else
                    {
                        hour--;
                        if (hour == -1)
                        {
                            hour = 11;
                        }
                    }
                }

            }
        }
            
    }

    void OnMouseUp()
    {
        if (GameManager.inRiddle == true && GameManager.riddleNumber == 1)
        {
            if (Train.position == 1)
            {
                angleBefore = transform.eulerAngles.z;
                float rotation = transform.eulerAngles.z;
                snap = (int)Mathf.Round(rotation / 90);
                //Actual snapping
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90 * snap);
                currentAngle = transform.eulerAngles.z;


                if (Mathf.Abs(currentAngle - angleBefore) > 180)
                {
                    if (transform.eulerAngles.z < 180)
                    {
                        hour++;
                        if (hour == 12)
                        {
                            hour = 0;
                        }
                    }
                    else
                    {
                        hour--;
                        if (hour == -1)
                        {
                            hour = 11;
                        }
                    }
                }

                riddle1finalScript.Check();
            }
        }

    }
}
