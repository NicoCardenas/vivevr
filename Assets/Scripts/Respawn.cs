using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {

    public GameObject explosion;
    private int goal;
    [SerializeField]
    private Text score;
    private float xinit, yinit, zinit;
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
        score.text = "Puntos: " + goal.ToString();
        xinit = this.transform.position.x;
        yinit = this.transform.position.y;
        zinit = this.transform.position.z;
        Debug.Log("Initial position: " + xinit + " " + yinit + " " + zinit);

        lanzamientos = 5;
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
            if (lanzamientos != 0)           
                lanzamientos--;                        
            maxtiros();               
        }
        if (other.CompareTag("Bocin"))
        {
            pantalla.SetScore(pantalla.GetScore() + 6);
            score.text = "Puntaje: " + pantalla.GetScore().ToString();
            teleport(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && lanzamientos != 0)
        {
            teleport(gameObject);
            if (lanzamientos != 0)
                lanzamientos--;
            maxtiros();
        }            
        else if (collision.gameObject.name.Equals("seccion 1") || collision.gameObject.name.Equals("seccion 2"))
            teleport(gameObject);
    }

    private void maxtiros()
    {
        tiros.text = "Tejo x " + lanzamientos;
    }

    private void teleport(GameObject obj)
    {
        //Debug.Log("<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        //rb.ResetInertiaTensor();        
        obj.transform.rotation.SetEulerRotation(270f, 0f,0f);
        rb.velocity.Set(0f, 0f, 0f);
        rb.angularVelocity.Set(0f, 0f, 0f);
        rb.AddForce(Vector3.zero);
        //obj.transform.position.Set(xinit, yinit, zinit);
        rb.MovePosition(new Vector3(xinit, yinit, zinit));
    }
}

