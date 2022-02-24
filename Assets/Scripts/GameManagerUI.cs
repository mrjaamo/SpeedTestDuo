using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GameManagerUI : MonoBehaviour
{
    public TMP_Text Player1Text;
    public TMP_Text Player2Text;

    float timer = 60;

    string CurrentColor;
    public int color;

    public int points = 0;

    int turnNumber;
    int clickedColor;

    public Button[] myButton;
    public GameObject gameObject;
    public GameObject mainMenuButton;

    bool gameIsRunning = true;

    public bool Player1Plays = false;
    // Start is called before the first frame update
    void Start()
    {
        myButton = gameObject.GetComponentsInChildren<Button>();
        turnNumber = turnAmount(turnNumber);
        SwitchSide();
        mainMenuButton.SetActive(false);
    }

    void Update()
    {
        if (gameIsRunning)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else if (timer <= 0)
            {
                gameIsRunning = false;
                timer = 0;

                GameOver();
            }
        }
    }

    void GameOver()
    {

        foreach (Button btn in myButton)
        {
            if (btn.IsActive())
            {
                btn.enabled= false;
            }
            else
            {
                btn.enabled = true;
            }
        }

        mainMenuButton.SetActive(true);
        Player1Text.text = "Finish!";
        Player2Text.text = points.ToString();
    }


    void SwitchSide()
    {
        color = Random.Range(1, 9);
        SetColor();
    }

    void SetColor()
    {
        switch (color)
        {
            case 1:
                // color red
                CurrentColor = "Red";
                break;
            case 2:
                // color blue
                CurrentColor = "Blue";

                break;
            case 3:
                // color yellow
                CurrentColor = "Yellow";


                break;
            case 4:
                // color green
                CurrentColor = "Green";
                break;
            case 5:
                // color red
                CurrentColor = "Red";
                break;
            case 6:
                // color blue
                CurrentColor = "Blue";

                break;
            case 7:
                // color yellow
                CurrentColor = "Yellow";


                break;
            case 8:
                // color green
                CurrentColor = "Green";

                break;
            default:
                // code block
                CurrentColor = "";
                break;
        }
        ShowColor();
    }

    public void ClickColor(int Clickedcolor)
    {
        if (Clickedcolor != color)
        {
            points--;
            ShowColor();
        }

        if (Clickedcolor == color)
        {
            points++;
            if (turnNumber == 0)
            {
                SwitchSide();
                turnNumber = turnAmount(turnNumber);
            }
            else if (turnNumber >= 1)
            {
                turnNumber--;
            }

            SwitchSide();
            ShowColor();

            Debug.Log(turnNumber);
        }
     
    }

    void ShowColor()
    {
        if (color <= 4)
        {
            Player1Text.text = points.ToString();
            Player2Text.text = CurrentColor;
        }

        if (color > 4)
        {
            Player1Text.text = CurrentColor;
            Player2Text.text = points.ToString();
        }
    }

    public int turnAmount(int randomNumber)
    {
        int i = randomNumber;
        i = Random.Range(1, 7);
        return i;
    }
}