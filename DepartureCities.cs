/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepartureCities : MonoBehaviour
{
    public Sprite darkland, thinny, wherever, shortsville, sadtown, lightland, hereweare, dumbroad, fatspark;

    public static int signState = 7;
    public Riddle1Final riddle1finalScript;

    private void Update()
    {
        if (GameManager.inRiddle == true && GameManager.riddleNumber == 1)
        {
            if (Riddle1Final.amountSolved == 3)
            {
                if (Train.position == 3)
                {
                    GetComponent<SpriteRenderer>().sprite = darkland;
                    signState = 1;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (GameManager.inRiddle == true && GameManager.riddleNumber == 1)
        {
            if (Riddle1Final.amountSolved != 3)
            {
                if (Train.position == 1)
                {
                    signState++;
                    if (signState > 9)
                        signState = 1;

                    switch (signState)
                    {
                        case 1:
                            GetComponent<SpriteRenderer>().sprite = darkland;
                            break;
                        case 2:
                            GetComponent<SpriteRenderer>().sprite = thinny;
                            break;
                        case 3:
                            GetComponent<SpriteRenderer>().sprite = wherever;
                            break;
                        case 4:
                            GetComponent<SpriteRenderer>().sprite = shortsville;
                            break;
                        case 5:
                            GetComponent<SpriteRenderer>().sprite = sadtown;
                            break;
                        case 6:
                            GetComponent<SpriteRenderer>().sprite = lightland;
                            break;
                        case 7:
                            GetComponent<SpriteRenderer>().sprite = hereweare;
                            break;
                        case 8:
                            GetComponent<SpriteRenderer>().sprite = dumbroad;
                            break;
                        case 9:
                            GetComponent<SpriteRenderer>().sprite = fatspark;
                            break;
                    }

                    riddle1finalScript.Check();
                }
            }
        } 
    }
}
