using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{

    int turnNumber;
    int score = 0;
    int colourNumber;
    public bool RoleOrder = true;
    public bool correctButton;
    public Button[] myButton;
    public GameObject Blue;
    public GameObject Green;
    public GameObject Red;
    public GameObject Yellow;

    Canvas canvas;
    public enum buttonEnum
    {
        [Description("B1")]
        Blue1 = 1,
        [Description("G1")]
        Green1 = 2,
        [Description("R1")]
        Red1 = 3,
        [Description("Y1")]
        Yellow1 = 4,
        [Description("B2")]
        Blue2 = 5,
        [Description("G2")]
        Green2 = 6,
        [Description("R2")]
        Red2 = 7,
        [Description("Y2")]
        Yellow2 = 8
    };

    string[] colours = new string[] { "Blue", "Green", "Red", "Yellow" };

    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        myButton = canvas.GetComponentsInChildren<Button>();
    }


    void Update()
    {
        while (true)
        {
            GameLoop();
        }
    }

    public void OrderSwitch()
    {
        foreach (Button btn in myButton)
        {
            if (!btn.IsInteractable())
            {
                btn.interactable = true;
            }
            else
            {
                btn.interactable = false;
            }
        }
    }

    public void GameLoop()
    {
        colourNumber = colourPick();
        Destroy(GameObject.FindGameObjectWithTag("Colour"));

        switch (colourNumber)
        {
            case 1:
                Instantiate(Blue, new Vector3(0, 0, 0), Quaternion.identity);
                Blue.transform.SetParent(canvas.transform);
                break;
            case 2:
                Instantiate(Green, new Vector3(0, 0, 0), Quaternion.identity);
                Blue.transform.SetParent(canvas.transform);
                break;
            case 3:
                Instantiate(Red, new Vector3(0, 0, 0), Quaternion.identity);
                Blue.transform.SetParent(canvas.transform);
                break;
            case 4:
                Instantiate(Yellow, new Vector3(0, 0, 0), Quaternion.identity);
                Blue.transform.SetParent(canvas.transform);
                break;
        }


        turnNumber--;
        if (turnNumber == 0)
        {
            RoleOrder ^= true; // Switches bool value back and forth
            OrderSwitch();
            turnAmount(turnNumber);
        }

    }

    public int turnAmount(int randomNumber)
    {
        int i = randomNumber;
        randomNumber = Random.Range(1, 7);
        return i;
    }

    public int colourPick()
    {
        int i = Random.Range(1, 5);
        if (RoleOrder == false)
        {
            i = i + 4;
        }
        return i;
    }

    public void btnPress()
    {
        if (colourNumber == int.Parse(myButton.GetType().Name));
        switch (correctButton)
        {
            case true:
                score = score + 10;
                colourPick();
                break;
            case false:
                score = score - 10;
                break;
        }
    }
}
