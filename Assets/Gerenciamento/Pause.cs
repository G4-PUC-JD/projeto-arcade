using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool JogoPausado = false;
    public GameObject TelaPause;
    public GameObject MenuVolume;
    public GameObject MenuSair;
    void Start ()
    {
        TelaPause.SetActive(false);
        MenuVolume.SetActive(false);
        MenuSair.SetActive(false);
    }
    
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JogoPausado)
            {
                ContinuarJogo();
            } else{
                Pausar ();
            }
        }
    }
    void ContinuarJogo ()
    {
        TelaPause.SetActive(false);
        MenuVolume.SetActive(false);
        MenuSair.SetActive(false);
        Time.timeScale = 1f;
        JogoPausado = false;
    }
    void Pausar ()
    {
        TelaPause.SetActive(true);
        Time.timeScale = 0f;
        JogoPausado = true;
    }
}
