 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RingController : MonoBehaviour {

    [SerializeField]
    GameObject Manager;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.SetActive(false);

            string PlayerNumber = collision.GetComponent<PlayerController>().PlayerNum;
            if (PlayerNumber == "P1")
            {
                Manager.GetComponent<GameManager>().CheckPlayerPlace("Player 1");
            }
            else if (PlayerNumber == "P2")
            {
                Manager.GetComponent<GameManager>().CheckPlayerPlace("Player 2");
            }
            else if (PlayerNumber == "P3")
            {
                Manager.GetComponent<GameManager>().CheckPlayerPlace("Player 3");
            }
            else if (PlayerNumber == "P4")
            {
                Manager.GetComponent<GameManager>().CheckPlayerPlace("Player 4");
            }

            Manager.GetComponent<GameManager>().PlayersAlive -= 1;
        }
    }
}
