/* Alexandru Negoescu, Michael Gebhart (Audio)
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : TrainSound
{
    public static int position = 1;
    private int lastPos;
    public float leaveTime = 10, resetTime = 3;
    float timer;

    void Update()
    {
        switch (position)
        {
            case 1:
                transform.position = new Vector3(-50, transform.position.y,transform.position.z);
                break;
            case 2:
                if (!arrivePlaying)
                { StartTrainSound(arriveState, arriveSound); arrivePlaying = true; }
                transform.position = Vector3.Lerp(transform.position, new Vector3(-9.5f, transform.position.y, transform.position.z), 0.03f);
                timer+= Time.deltaTime;
                if(timer > leaveTime)
                {
                    timer = 0;
                    position++;
                    StopTrainSound(arriveState);
                    arrivePlaying = false;
                }
                break;
            case 3:
                if (!leavePlaying)
                { StartTrainSound(leaveState, leaveSound); leavePlaying = true; }
                timer += Time.deltaTime;
                if (timer > resetTime)
                {
                    timer = 0;
                    position = 1;
                    StopTrainSound(leaveState);
                    leavePlaying = false;
                }
                transform.position = Vector3.Lerp(transform.position, new Vector3(50f, transform.position.y, transform.position.z), 0.01f);
                break;
        }    
    }
}
