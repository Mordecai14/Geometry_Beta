using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public static GroundController instance;
    public GameObject gameC;
    public GameObject[] waterArray , fireArray, earthArray, airArray, bubbleArray;
    //public GameObject bubble;
    private bool fireOn, waterOn, earthOn, airOn;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        float rand = Random.Range(5.35f, 10.35f);
        float rand2 = Random.Range(3.35f, 8.35f);
        InvokeRepeating("Spawn", 1, 1.9f);
        InvokeRepeating("SpawnAir", 1, rand2);
    }

    // Update is called once per frame
    void Update()
    {
        waterOn = gameC.GetComponent<GameController>().gameState == GameState.Water;
        fireOn = gameC.GetComponent<GameController>().gameState == GameState.Fire;
        earthOn = gameC.GetComponent<GameController>().gameState == GameState.Earth;
        airOn = gameC.GetComponent<GameController>().gameState == GameState.Air;
    }


    //--------------------
    //-----------------Funciones-------------
    //------------------
    public void Spawn()
    {
        if (fireOn)
        {
            int rand = Random.Range(0, fireArray.Length);
            Vector3 pos = transform.position;
            transform.position = pos;
            Instantiate(fireArray[rand], new Vector2(29.26654f, -17.01f), Quaternion.identity);
        }
        else if (waterOn)
        {
            int rand = Random.Range(0, waterArray.Length);
            Vector3 pos = transform.position;
            transform.position = pos;
            Instantiate(waterArray[rand], transform.position, Quaternion.identity);
        }
        else if(earthOn)
        {
            int rand = Random.Range(0, earthArray.Length);
            Vector3 pos = transform.position;
            transform.position = pos;
            Instantiate(earthArray[rand], new Vector2(29.26654f, 7.28f), Quaternion.identity);
        }
    }

    public void SpawnAir()
    {
        if (airOn)
        {
            int randBubble = Random.Range(0, bubbleArray.Length);
            float randPos2 = Random.Range(20.52f, 27.5f);
            /*Vector3 pos = transform.position;
            transform.position = pos;*/
            Instantiate(bubbleArray[randBubble], new Vector2(29.26654f, randPos2), Quaternion.identity);
        }
    }

    //--------------------
    //-----------------Courutines-------------
    //------------------
}
