using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField]
    Text VictoryText;
    [SerializeField]
    Text SecondPlaceText;
    [SerializeField]
    Text ThirdPlaceText;
    [SerializeField]
    Text FourthPlaceText;
    [SerializeField]
    Text Timer;
    [SerializeField]
    GameObject Player1;
    [SerializeField]
    GameObject Player2;
    [SerializeField]
    GameObject Player3;
    [SerializeField]
    GameObject Player4;

    [System.NonSerialized]
    public string FirstPlace;
    [System.NonSerialized]
    public string SecondPlace;
    [System.NonSerialized]
    public string ThirdPlace;
    [System.NonSerialized]
    public string FourthPlace;

    public int PlayersAlive;

    private float RoundTimer;

    [System.NonSerialized]
    public string GameState;

    private void Start()
    {
        GameState = "Playing";
        RoundTimer = 30.0f;
        Player3.gameObject.SetActive(false);
        Player4.gameObject.SetActive(false);
        VictoryText.gameObject.SetActive(false);
        SecondPlaceText.gameObject.SetActive(false);
        ThirdPlaceText.gameObject.SetActive(false);
        FourthPlaceText.gameObject.SetActive(false);
        PlayersAlive = GameData.GameData_PlayersAlive;
        Player1.gameObject.SetActive(true);
        Player2.gameObject.SetActive(true);
        if (PlayersAlive > 2)
        {
            Player3.gameObject.SetActive(true);
            if (PlayersAlive > 3)
            {
                Player4.gameObject.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (GameState == "Playing")
        {
            if (RoundTimer >= 0)
            {
                RoundTimer -= Time.deltaTime;
                int RoundedRoundTimer = Mathf.RoundToInt(RoundTimer);
                Timer.text = RoundedRoundTimer.ToString();
            }
            if (RoundTimer <= 0)
            {
                GameState = "GameOver";
                FirstPlace = "Player 4";
                SecondPlace = "Player 1";
                ThirdPlace = "Player 2";
                FourthPlace = "Player 3";
                VictoryText.text = (FirstPlace + " Won : 4 points");
                VictoryText.gameObject.SetActive(true);
                SecondPlaceText.text = (SecondPlace + " Came 2nd : 3 Points");
                SecondPlaceText.gameObject.SetActive(true);
                if (GameData.GameData_PlayersAlive > 2)
                {
                    ThirdPlaceText.text = (ThirdPlace + " Came 3rd : 2 Points");
                    ThirdPlaceText.gameObject.SetActive(true);
                    if (GameData.GameData_PlayersAlive > 3)
                    {
                        FourthPlaceText.text = (FourthPlace + " Came 4th : 1 Points");
                        FourthPlaceText.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
     
    public void CheckIfWon()
    {
        if (PlayersAlive == 1)
        {
            VictoryText.text = (FirstPlace + " Won : 4 points");
            VictoryText.gameObject.SetActive(true);
            SecondPlaceText.text = (SecondPlace + " Came 2nd : 3 Points");
            SecondPlaceText.gameObject.SetActive(true);
            if (GameData.GameData_PlayersAlive > 2)
            {
                ThirdPlaceText.text = (ThirdPlace + " Came 3rd : 2 Points");
                ThirdPlaceText.gameObject.SetActive(true);
                if(GameData.GameData_PlayersAlive > 3)
                {
                    FourthPlaceText.text = (FourthPlace + " Came 4th : 1 Points");
                    FourthPlaceText.gameObject.SetActive(true);
                }
            }
            GameState = "Victory Screen";
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CheckPlayerPlace(string player)
    {
        if (PlayersAlive == 2)
        {
            SecondPlace = player;
        }
        else if (PlayersAlive == 3)
        {
            ThirdPlace = player;
        }
        else if (PlayersAlive == 4)
        {
            FourthPlace = player;
        }
    }

}
