/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCart : MonoBehaviour
{
    float radius;
    float angle;
    public float number;
    Renderer rend;
    public int targetColor;
    int color = 0;
    bool correct;
    public bool fixedCart;
    public Material green, cyan, purple, orange, yellow, red;

    void Start()
    {
        rend = GetComponent<Renderer>();
        radius = Vector3.Distance(Carts.cartCenter,transform.localPosition);
    }

    void Update()
    {
        angle = (((30 * number) + (FerrisWheel.currentAngle) +270) / -180 * Mathf.PI);
        transform.localPosition = new Vector3((Mathf.Cos(angle) * radius) + 388 , Mathf.Sin(angle) * radius - 14.1204f, transform.localPosition.z);
    }

    void OnMouseDown()
    {

        if (!fixedCart)
        {
            color++;
            if (color > 6)
            {
                color = 1;
            }

            switch (color)
            {
                case 1:
                    rend.material = green;
                    break;
                case 2:
                    rend.material = cyan;
                    break;
                case 3:
                    rend.material = purple;
                    break;
                case 4:
                    rend.material = orange;
                    break;
                case 5:
                    rend.material = yellow;
                    break;
                case 6:
                    rend.material = red;
                    break;
            }

            if (color == targetColor && correct == false)
            {
                correct = true;
                Riddle2Final.solved++;
            }
            else if (color != targetColor && correct == true)
            {
                correct = false;
                Riddle2Final.solved--;
            }
        }
    }
}
