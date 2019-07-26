/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteStrip : MonoBehaviour
{
    public Riddle3 riddle3;

    public int number;

    private void OnMouseDown()
    {
        riddle3.Check(number);
    }
}
