using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public GameObject obj;

    public void instance(float x, float y, float z)
    {
        Instantiate(obj, new Vector3(x, y, z), Quaternion.Euler(new Vector3(270f, 0f, 0f)));
    }
}
