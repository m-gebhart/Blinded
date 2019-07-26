/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carousel : MonoBehaviour
{
    public float rotSpeed = 20;

    void OnMouseDrag()
    {
        if (GameManager.inRiddle == true && GameManager.riddleNumber == 2)
        {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
#pragma warning disable CS0618 //element is outdated
            transform.RotateAround(Vector3.up, -rotX);
#pragma warning restore CS0618 //element is outdated
        }
    }
}
