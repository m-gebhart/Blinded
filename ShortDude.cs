/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortDude : MonoBehaviour
{
    public Animator animator;
    public float animationTime = 5.0f;
    float timer;
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("triggerMovement", false);
        timer += Time.deltaTime;
        if(timer > animationTime)
        {
            GetComponent<Animator>().Play("ShortMovement", -1, 0f);
            timer = 0;
        }

        if (Train.position == 3 && Riddle1Final.solved[0])
        {
            Destroy(gameObject);
        }
    }
}
