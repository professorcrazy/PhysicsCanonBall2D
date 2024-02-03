using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool p1Trun = true;
    [SerializeField] GameObject p1Panel;
    [SerializeField] GameObject p2Panel;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject quitMenu;

    private void Start()
    {
        menu.SetActive(true);
        p1Panel.SetActive(false);
        p2Panel.SetActive(false);
        quitMenu.SetActive(false);
    }

    public void SwitchTurn() 
    { 
        if (p1Trun) 
        { 
            p1Panel.SetActive(false);
            p2Panel.SetActive(true);
            p1Trun = false; 
        } else 
        {
            p1Panel.SetActive(true);
            p2Panel.SetActive(false);
            p1Trun = true;
        } 
    }
    // Start is called before the first frame update
    public void StartGame()
    {
        p1Trun = true;
        p1Panel.SetActive(true);
        p2Panel.SetActive(false);
    }
}
