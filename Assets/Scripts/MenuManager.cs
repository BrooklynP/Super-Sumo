using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    Text AmountOfPlayersText;

    private void UpdatePlayerText()
    {
        AmountOfPlayersText.text = GameData.GameData_PlayersAlive.ToString() + " Players";
    }

    public void AddPlayer()
    {
        if (GameData.GameData_PlayersAlive < 4)
        {
            GameData.GameData_PlayersAlive += 1;
            UpdatePlayerText();
        }
    }
    public void RemovePlayer()
    {
        if (GameData.GameData_PlayersAlive > 2)
        {
            GameData.GameData_PlayersAlive -= 1;
            UpdatePlayerText();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

	// Use this for initialization
	void Start () {
        UpdatePlayerText();
    }
}
