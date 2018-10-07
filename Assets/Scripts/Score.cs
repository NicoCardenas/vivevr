using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    [SerializeField]
    private int goal = 0;

    public int GetScore()
    {
        return goal;
    }

    public void SetScore(int puntaje)
    {
        this.goal = puntaje;
    }

}
