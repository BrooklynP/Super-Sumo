using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
    [SerializeField]
    AudioController Audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Hit");

            collision.GetComponentInParent<PlayerController>().Hit(0, 0, 2);

            Audio.GetComponent<AudioController>().PlayBoing();
        }
    }
}
