/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainWoman: MonoBehaviour
{
    public Animator animator;
    public float animationTime = 5.0f;
    float timer = 2.5f;
    public static bool leave;

    void Update()
    {
        if (!leave)
        {
            timer += Time.deltaTime;
            if (timer > animationTime)
            {
                animator.Play("Moving", 0, 0);
                timer = 0;
            }
        }

        if(leave)
        {
            animator.SetBool("triggerExit" , true);
        }

        if (Train.position == 3 && Riddle1Final.solved[1])
        {
            Destroy(gameObject);
        }
    }
}
