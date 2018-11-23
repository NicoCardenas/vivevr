using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {

    public GameObject explosion;
    private int goal;
    [SerializeField]
    private Text score;
    private float x, y, z;
    GameObject pt;
    private Score pantalla;

    int lanzamientos;
    public Text tiros;


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

        lanzamientos = 5;
        maxtiros();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mechas"))
        {
            pantalla.SetScore(pantalla.GetScore() + 3);
            score.text = "Puntaje: " + pantalla.GetScore().ToString();
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.CompareTag("Respawn"))
        {
            lanzamientos--;
            maxtiros();
        }
        if (other.CompareTag("Bocin"))
        {
            pantalla.SetScore(pantalla.GetScore() + 6);
            score.text = "Puntaje: " + pantalla.GetScore().ToString();
        }
    }
    private void maxtiros()
    {
        tiros.text = "Tiros: " + lanzamientos;
    }



}

