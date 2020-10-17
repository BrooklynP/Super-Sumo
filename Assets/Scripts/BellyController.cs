using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellyController : MonoBehaviour {

    private string PlayerNumber;
    private Animator animator;
    [SerializeField]
    AudioController Audio;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player")
        {
            PlayerNumber = GetComponentInParent<PlayerController>().PlayerNum;
            float HorizontalAxis = Input.GetAxis(PlayerNumber + "Horizontal");
            float VerticalAxis = Input.GetAxis(PlayerNumber + "Vertical");
            animator = GetComponentInParent<Animator>();
            animator.SetBool("IsAttacking", true);

            collision.GetComponentInParent<PlayerController>().Hit(HorizontalAxis, VerticalAxis, 1);

            Audio.GetComponent<AudioController>().PlayBoing();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator = GetComponentInParent<Animator>();
            animator.SetBool("IsAttacking", false);
        }
    }
}
