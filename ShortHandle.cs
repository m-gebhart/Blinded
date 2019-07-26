/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortHandle : MonoBehaviour
{
    void Update()
    {
        transform.eulerAngles = new Vector3(0,0, (LongClockHandle.currentAngle / 12) + (LongClockHandle.hour * 30));
    }
}
