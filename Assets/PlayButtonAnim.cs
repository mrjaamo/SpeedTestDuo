using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonAnim : MonoBehaviour
{

    Animator animR;

    MeshRenderer meshRend;
    Material mat;

    public Color color;
    bool isOn = true;

    void Start()
    {
        animR = GetComponent<Animator>();
        meshRend = GetComponent <MeshRenderer>();
        mat = meshRend.material;
        meshRend.material = mat;
    }

    public void PressButton()
    {
        animR.SetTrigger("PressButton");

        mat.SetColor("_EmissionColor", color);
        Invoke("ToggleEmission", 0.20f);
    }

    public void ToggleEmission()
    {
        mat.SetColor("_EmissionColor", Color.black);
    }
}
