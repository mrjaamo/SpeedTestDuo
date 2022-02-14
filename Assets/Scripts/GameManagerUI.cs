using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerUI : MonoBehaviour
{
    public TMP_Text Player1Text;
    public TMP_Text Player2Text;

    string CurrentColor;
    public int color;

    public int points = 0;

    int clickedColor;

    public bool Player1Plays = true;
    // Start is called before the first frame update
    void Start()
    {
        Player1Text = GameObject.Find("Player1Info").GetComponent<TMP_Text>();
        Player2Text = GameObject.Find("Player2Info").GetComponent<TMP_Text>();
        SwitchSide();
    }

    // Update is called once per frame
    void Update()
    {


    }


    void SwitchSide()
    {
        if (Player1Plays == true)
        {

            Player1Plays = false;
            color = Random.Range(6, 10);
        }

        else
        {
            Player1Plays = true;
            color = Random.Range(1, 5);
        }

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
            case 6:
                // color red
                CurrentColor = "Red";
                break;
            case 7:
                // color blue
                CurrentColor = "Blue";

                break;
            case 8:
                // color yellow
                CurrentColor = "Yellow";


                break;
            case 9:
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
            SwitchSide();
        }
     
    }

    void ShowColor()
    {
        if (Player1Plays == true)
        {
            Player1Text.text = points.ToString();
            Player2Text.text = CurrentColor;
        }

        if (Player1Plays == false)
        {
            Player1Text.text = CurrentColor;
            Player2Text.text = points.ToString();

        }
    }

}