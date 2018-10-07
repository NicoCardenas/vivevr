using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {

    private int goal;
    [SerializeField]
    private Text score;
    private float x, y, z;
    GameObject pt;
    private Score pantalla;



    // Use this for initialization
    void Start()
    {
        pt = GameObject.FindGameObjectWithTag("canvas");
        pantalla = pt.GetComponent<Score>();
        goal = 0;
        score.text = "Puntaje:" + goal.ToString();
        x = this.transform.position.x;
        y = this.transform.position.y;
        z = this.transform.position.z;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Points"))
        {
            pantalla.SetScore(pantalla.GetScore() + 1);
            score.text = "Puntaje: " + pantalla.GetScore().ToString();
            transform.position = new Vector3(x, y, z);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))     
        {
            transform.position = new Vector3(x, y, z);
        }
    }
}
