using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzamientos : MonoBehaviour {

    [SerializeField]
    private int tiros = 5;

    public int GetLanzamientos()
    {
        return tiros;
    }

    public void SetLanzamientos(int X)
    {
        this.tiros = X;
    }
}
