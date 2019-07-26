/* Michael Gebhart, Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    public bool playOnDEV = true; //possiblity to skip openinc cinematic, if unchecked

    public GameObject player;
    private Vector3 center; //Position of camera

    //certain distances (Limit from center) forming the space the player can move in without pushing the camera
    public float leftLimit, rightLimit, upLimit, downLimit;

    //limits setting at the level's borders, camera shouldn't move any further even if the borders are hit by player
    public float ultimateLeftLimit, ultimateRightLimit, ultimateUpperLimit, ultimateLowerLimit;

    public bool isFixed = false; //camera is fixed in occurences of riddles; called and changed by triggers in the world
    public static bool isMoving, inputPossible = false;
    public static bool transitioning;
    public static bool stay = true;

    UnityEngine.Video.VideoClip videoClip;
    private float endTime = 30f; //standard duration of opening cinematic

    void Awake()
    {
        var videoPlayer = gameObject.GetComponent<UnityEngine.Video.VideoPlayer>();
        endTime /= videoPlayer.playbackSpeed;
        if (playOnDEV)
            videoPlayer.Play();
        else
            endTime = 0.0001f;
        StartCoroutine(EndVideo(videoPlayer));
    }
    
    IEnumerator EndVideo(UnityEngine.Video.VideoPlayer vp)
    {
        yield return new WaitForSeconds(endTime);
        inputPossible = true;
        vp.Stop();
    }

    void Start()
    {
        center = new Vector3(-20.88f, -1.8f, -14.5f);
        transform.position = center;
    }

    void LateUpdate()
    {
        if (!isFixed)
            CheckCameraPosition();

        if (player.transform.position.x < 255f)
            Camera.main.farClipPlane = 200f;
    }

    void CheckCameraPosition()
    {
        if(GameManager.inRiddle)
        {
            switch (GameManager.riddleNumber)
            {
                case 1:
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(-0.58f, -2.57f, -12.00f), 0.1f);
                    break;
                case 2:
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(148.97f, 1.07f, -14.25f), 0.1f);
                    break;
                case 3:
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(212.66f, -0.4f, -11.31f), 0.1f);
                    break;
                case 4:
                    
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(328, -0.4f, -14.2f), 0.1f);
                    break;
                case 5:
                    EndFade.flash = true;
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(328, -0.4f, 28.7f), 0.1f);
                    break;
            }
        }
        else if (transitioning)
        {
                if (stay != true)
                {
                    center = new Vector3(player.transform.position.x, -1.35f, -10.39f);
                    transform.position = center;
                }
        }
        else
        {
            if (center != transform.position && player.transform.position.x > ultimateLeftLimit)
            {
                isMoving = true;
                transform.position = Vector3.MoveTowards(transform.position, center, 0.1f);
            }
            else
            {
                isMoving = false;

                if (player.transform.position.x < transform.position.x - leftLimit) //moving to the left and pushing cam to left
                {
                    center = new Vector3(player.transform.position.x + leftLimit, transform.position.y, transform.position.z);
                    if (center.x > ultimateLeftLimit)
                        transform.position = center;
                }
                else if (player.transform.position.x > transform.position.x + rightLimit) //moving to the right and pushing cam to right
                {
                    center = new Vector3(player.transform.position.x - rightLimit, transform.position.y, transform.position.z);
                    if (center.x < ultimateRightLimit)
                        transform.position = center;
                }
            }
        }
    }
    
    public void ManualAdjust()
    {
        if (player.transform.position.x < transform.position.x - leftLimit) //moving to the left and pushing cam to left
        {
            center = new Vector3(player.transform.position.x + leftLimit, transform.position.y, transform.position.z);
        }
        else if (player.transform.position.x > transform.position.x + rightLimit) //moving to the right and pushing cam to right
        {
            center = new Vector3(player.transform.position.x - rightLimit, transform.position.y, transform.position.z);
        }

        if (player.transform.position.y > transform.position.y + upLimit) //moving upwards
        {
            center = new Vector3(transform.position.x, player.transform.position.y - upLimit, transform.position.z);
        }
        else if (player.transform.position.y < transform.position.y - downLimit) //moving down
        {
            center = new Vector3(transform.position.x, player.transform.position.y + downLimit, transform.position.z);
        }
    }
}