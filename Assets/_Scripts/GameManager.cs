using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    bool p1Trun = true;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject swapPanel;
    [SerializeField] TMP_Text swapPlayerTxt;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TMP_Text gameOverPlayerTxt;
    [SerializeField] GameObject quitMenu;
    public static GameManager Instance;
    public List<CannonController> playerList;

    int[] distArray = {9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 25, 26, 29, 32, 33, 37, 44, 49, 74, 104};

    public int playerDistance;
    public string swapPlayerText = "Switch to ";
    public string gameOverText = "Got blown up!";

    private void Awake()
    {
        Instance = GetComponent<GameManager>();
        foreach (CannonController c in FindObjectsOfType<CannonController>())
        {
            playerList.Add(c);
            c.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        playerDistance = distArray[UnityEngine.Random.Range(0, distArray.Length)]; //Mathf.Round(UnityEngine.Random.Range(200f, 550f) * 10f) / 10f;
        Debug.Log(playerDistance.ToString());
        menu.SetActive(true);
        swapPanel.SetActive(false);
        quitMenu.SetActive(false);
    }

    public void SwitchTurn() 
    { 
        if (p1Trun) 
        { 
            p1Trun = false; 
            swapPlayerTxt.text = swapPlayerText + playerList[1].playerName;
            swapPanel.SetActive(true);
            playerList[0].gameObject.SetActive(false);
        } else 
        {
            p1Trun = true;
            swapPlayerTxt.text = swapPlayerText + playerList[0].playerName;
            swapPanel.SetActive(true);
            playerList[1].gameObject.SetActive(false);
        }
    }
    public void SetReady()
    {
        playerList[1].gameObject.SetActive(!p1Trun);
        playerList[0].gameObject.SetActive(p1Trun);
        swapPanel.SetActive(false);
        
    }
    // Start is called before the first frame update
    public void StartGame()
    {
        p1Trun = true;
        playerList[0].gameObject.SetActive(true);
        playerList[1].gameObject.SetActive(false);
    }

    public void GameOver(string name)
    {
        gameOverPanel.SetActive(true);
        gameOverPlayerTxt.text = name + Environment.NewLine + gameOverText;
        menu.SetActive(false);
        swapPanel.SetActive(false);
        foreach (CannonController player in playerList)
        {
            player.gameObject.SetActive(false);
        }
    }
}
