using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    int turnNumber;
    int score = 0;
    int colourNumber;
    int successAmount = -1;
    public bool RoleOrder = true;
    public bool correctButton;
    public Button[] myButton;
    public GameObject Blue;
    public GameObject Green;
    public GameObject Red;
    public GameObject Yellow;
    RectTransform objectRectTransform;
    Canvas canvas;

    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        myButton = canvas.GetComponentsInChildren<Button>();
        turnNumber = turnAmount(turnNumber);
        GameLoop();
        objectRectTransform = canvas.GetComponent<RectTransform>();
    }

    public void GameLoop()
    {
        colourNumber = colourPick();
        Destroy(GameObject.FindGameObjectWithTag("Colour"));
        StartCoroutine(ChangeColour());

        if (turnNumber == 0)
        {
            RoleOrder ^= true; // Switches bool value back and forth
            OrderSwitch();
            turnNumber = turnAmount(turnNumber);
        }
        else if (turnNumber >= 1)
        {
            turnNumber--;
        }
        Debug.Log(turnNumber);
    }
    public void OrderSwitch()
    {
        foreach (Button btn in myButton)
        {
            if (btn.IsInteractable())
            {
                btn.interactable = false;
            }
            else
            {
                btn.interactable = true;
            }
        }
    }
    public int turnAmount(int randomNumber)
    {
        int i = randomNumber;
        i = Random.Range(1, 7);
        return i;
    }
    public int colourPick()
    {
        int i = Random.Range(1, 5);
        return i;
    }
    public void btnPress()
    {
        int correctColour;
        int.TryParse(EventSystem.current.currentSelectedGameObject.name, out correctColour);
        Debug.Log("The one we have: " + correctColour);
        Debug.Log("The one we want: " + colourNumber);
        if (colourNumber == correctColour)
        {
            score = score + 10;
            successAmount++;
            Debug.Log(score);
            GameLoop();
        }
        else
        {
            score = score - 10;
        }
    }
    IEnumerator ChangeColour()
    {
        yield return new WaitForSeconds(0.2f); // Amount of time the screen will be blank between colours
        switch (colourNumber)
        {
            case 1:
                GameObject newYellow = Instantiate(Yellow, new Vector3(objectRectTransform.rect.width*0.5f, objectRectTransform.rect.height* 0.5f, 0), Quaternion.identity) as GameObject;
                newYellow.transform.SetParent(canvas.transform);
                break;
            case 2:
                GameObject newGreen = Instantiate(Green, new Vector3(objectRectTransform.rect.width * 0.5f, objectRectTransform.rect.height * 0.5f, 0), Quaternion.identity) as GameObject;
                newGreen.transform.SetParent(canvas.transform);
                break;
            case 3:
                GameObject newBlue = Instantiate(Blue, new Vector3(objectRectTransform.rect.width * 0.5f, objectRectTransform.rect.height * 0.5f, 0), Quaternion.identity) as GameObject;
                newBlue.transform.SetParent(canvas.transform);
                break;
            case 4:
                GameObject newRed = Instantiate(Red, new Vector3(objectRectTransform.rect.width * 0.5f, objectRectTransform.rect.height * 0.5f, 0), Quaternion.identity) as GameObject;
                newRed.transform.SetParent(canvas.transform);
                break;
        }
    }
}
