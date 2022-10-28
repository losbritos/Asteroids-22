using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;
    public int vidas;
    public int puntuacion;

    private void Awake()
    {
        instance = this;
    }

    
}

