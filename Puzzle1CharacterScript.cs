/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1CharacterScript : MonoBehaviour
{
    public WhiteScreenTransition whiteScreen;
    bool reposition;

    void Update()
    {
        if (Train.position == 3 && Riddle1Final.solved[3])
        {

            whiteScreen.Transition();
            transform.position = new Vector3(85.88f, -50.54f, -3.76f);
        }

        if(Train2.position == 2 && !reposition)
        {
            transform.position = new Vector3(85.88f, -4.36f, -3.76f);
            reposition = true;
        }
        else if (Train2.position == 1 && !reposition)
        {
            transform.position = new Vector3(85.88f, -50.54f, -3.76f);
        }
    }
}
