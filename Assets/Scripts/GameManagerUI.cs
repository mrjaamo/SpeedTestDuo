using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerUI : MonoBehaviour
{
    public TMP_Text Player1Text;
    public TMP_Text Player2Text;

    public TMP_Text timerText;
    float timer = 2;

    string CurrentColor;
    public int color;

    public int points = 0;

    int turnNumber;
    int clickedColor;

    public bool Player1Plays = false;
    // Start is called before the first frame update
    void Start()
    {
        turnNumber = turnAmount(turnNumber);
        SwitchSide();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0)
        {
            timer = 0;
            // Game Over
        }
    }

    void GameOver()
    {
        Player1Text.text = "Finish!";
        Player2Text.text = "Finish!";
    }

    void GameOverScore()
    {
        Player1Text.text = points.ToString();
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