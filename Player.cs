/* Michael Gebhart (Animation and Audio), Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* using an own Input class (PlayerInput) instead of using Unity's build-in system
 * */
public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public float rotSpeed = 100;
    public GameManager gameManagerScript;
    public static bool moveable;
    public Animator animator;

    [FMODUnity.EventRef]
    public string walkingSound;
    FMOD.Studio.EventInstance walkingState;
    bool walkingSoundPlaying = false;

    [FMODUnity.EventRef]
    public string hackingSound;
    FMOD.Studio.EventInstance hackingState;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(GameManager.inRiddle == false && CameraScript.isMoving == false && CameraScript.transitioning == false)
        {
            if (PlayerInput.MoveToRight())
            {
                animator.SetBool("isMoving", true);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -90, 0), rotSpeed);
                rb.velocity = new Vector3(speed, 0, 0);

                if (!walkingSoundPlaying)
                {
                    walkingState = MusicManager.Create3DSoundInstance(walkingSound, this.gameObject);
                    walkingState.start();
                    walkingSoundPlaying = true;
                }
            }
            else if (PlayerInput.MoveToLeft())
            {
                animator.SetBool("isMoving", true);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 90, 0), rotSpeed);
                rb.velocity = new Vector3(-speed, 0, 0);

                if (!walkingSoundPlaying)
                {
                    walkingState = MusicManager.Create3DSoundInstance(walkingSound, this.gameObject);
                    walkingState.start();
                    walkingSoundPlaying = true;
                }
            }
            else
            {
                StopMoving();
                rb.velocity = new Vector3(0, 0, 0);
            }
        }

        if (GameManager.inRiddle && !animator.GetBool("isHacking"))
        {
            StopMoving();
            StartCoroutine(PlayHackingSound());
            animator.SetBool("isHacking", true);
        }
        else if (!GameManager.inRiddle && animator.GetBool("isHacking"))
        {
            animator.SetBool("isHacking", false);
        }

        if (GameManager.inRiddle == true)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

    }

    private void OnTriggerEnter (Collider Collision)
    {
        gameManagerScript.Riddle();
        Destroy(Collision.gameObject);
    }

    void StopMoving()
    {
        walkingState.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        walkingState.release();
        walkingSoundPlaying = false;
        animator.SetBool("isMoving", false);
    }


    IEnumerator PlayHackingSound()
    {
        hackingState = MusicManager.Create3DSoundInstance(hackingSound, this.gameObject);
        yield return new WaitForSeconds(1.5f);
        hackingState.start();
        yield return new WaitForSeconds(2f);
        hackingState.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        hackingState.release();
    }
}