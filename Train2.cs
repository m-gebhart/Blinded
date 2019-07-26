/* Alexandru Negoescu, Michael Gebhart (Audio)
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train2 : TrainSound
{
    public static int position = 0;
    GameObject michaelsShop;
    public float leaveTime = 5, resetTime = 1;
    float timer;
    MusicManager musicScript;
    bool mainTheme = false;


    public void Start()
    {
        base.Start();
        michaelsShop = GameObject.Find("/Scene 2 Exit Platform/transition1");
        musicScript = GameObject.Find("/Music").GetComponent<MusicManager>();
    }

    void Update()
    {
            switch (position)
            { 
                case 1:
                if (!arrivePlaying)
                { StartTrainSound(arriveState, arriveSound); arrivePlaying = true; }
                transform.position = Vector3.Lerp(transform.position, new Vector3(75.12f, transform.position.y, transform.position.z), 0.03f);
                    timer += Time.deltaTime;
                    if (timer > leaveTime)
                    {
                        timer = 0;
                        position++;
                    StopTrainSound(arriveState);
                    arrivePlaying = false;
                }  
                break;

                case 2:
                if (!leavePlaying)
                { StartTrainSound(leaveState, leaveSound); leavePlaying = true; }
                timer += Time.deltaTime;
                    if (timer > resetTime)
                        {
                            michaelsShop.GetComponent<SpriteRenderer>().sortingLayerName = "Buildings1"; //avoid graphical glitches
                    StopTrainSound(leaveState);
                    leavePlaying = false;
                    Destroy(gameObject);
                        }
                        transform.position = Vector3.Lerp(transform.position, new Vector3(160f, transform.position.y, transform.position.z), 0.005f);
                break;
            }

        if (transform.position.x > 55 && !mainTheme)
        {
            musicScript.ChangeMusicTrack("Main", true);
            mainTheme = true;
        }
    }
}
