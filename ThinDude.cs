/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinDude : MonoBehaviour
{
    void Update()
    {
        if (Train.position == 3 && Riddle1Final.solved[2])
        {
            Destroy(gameObject);
        }
    }
}