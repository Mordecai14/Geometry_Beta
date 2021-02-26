using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float vel;
    private float destroyThis;

    // Start is called before the first frame update
    void Start()
    {
        destroyThis = -20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * (vel) * Time.deltaTime);
        if (transform.position.x <= destroyThis)
        {
            Destroy(this.gameObject);
        }
    }

    //---------------------------------------
    //-----------------Funciones-------------
    //---------------------------------------

    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "eAgua" && collision.gameObject.tag != "Agua")
        {
            print("Choca con AWA");
        }
        else if (gameObject.tag == "eTierra" && collision.gameObject.tag != "Tierra")
        {
            print("Choca con Tierra");
        }
        else if(gameObject.tag == "eFuego" && collision.gameObject.tag != "Fuego")
        {
            print("Choca con Fuego");
        }
        else if(gameObject.tag == "eAire" && collision.gameObject.tag != "Aire")
        {
            print("Choca con Aire");
        }
    }*/

    //----------------------------------------
    //-----------------Courutines-------------
    //----------------------------------------
}
