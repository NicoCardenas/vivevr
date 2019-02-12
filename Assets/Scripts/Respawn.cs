using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {

    public GameObject explosion;
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text tiros;
    private float xinit, yinit, zinit;
    private GameObject pt;
    private Score pantalla;
    private Generator generator;
    private Lanzamientos lanzamientos;
    


    // Use this for initialization
    void Start()
    {
        pt = GameObject.FindGameObjectWithTag("canvas");
        score = GameObject.Find("Score").GetComponent<Text>();
        tiros = GameObject.Find("lanzamientos").GetComponent<Text>();
        pantalla = pt.GetComponent<Score>();
        lanzamientos = pt.GetComponent<Lanzamientos>();
        generator = pt.GetComponent<Generator>();

        
        score.text = "Puntaje: 0";
        xinit = this.transform.position.x;
        yinit = this.transform.position.y;
        zinit = this.transform.position.z;
                
        maxtiros();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mechas"))
        {
            pantalla.SetScore(pantalla.GetScore() + 3);
            score.text = "Puntos: " + pantalla.GetScore().ToString();
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            teleport(this.gameObject);
        }
        if (other.CompareTag("Respawn") || other.CompareTag("Ground"))
        {
            if (lanzamientos.GetLanzamientos() != 0)
            {
                lanzamientos.SubLanzamientos(1);
                teleport(gameObject);                
            }            
        }
        if (other.CompareTag("Bocin"))
        {
            pantalla.SetScore(pantalla.GetScore() + 6);
            score.text = "Puntaje: " + pantalla.GetScore().ToString();
            teleport(this.gameObject);
        }
        maxtiros();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && lanzamientos.GetLanzamientos() != 0)
        {
            teleport(gameObject);
            lanzamientos.SubLanzamientos(1);
        }
        else if (collision.gameObject.name.Equals("seccion 1") || collision.gameObject.name.Equals("seccion 2"))
            if (lanzamientos.GetLanzamientos() != 0)
            {
                lanzamientos.SubLanzamientos(1);
                teleport(gameObject);                
            }

        maxtiros();
    }

    private void maxtiros()
    {
        tiros.text = "Tejo x " + lanzamientos.GetLanzamientos();
    }

    private void teleport(GameObject obj)
    {
        Destroy(obj);
        generator.instance(xinit, yinit, zinit);        
    }
}

