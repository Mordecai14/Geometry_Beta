using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    public GameObject gameController;

    public int randomStage;
    private bool gameWater, gameFire, gameEarth, gameAir;
    public GameObject gWater, gFire, gEarth, gAir;
    public Image fadePanel;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animation>();

        gameController.GetComponent<GameController>();
        randomStage = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * (8.5f) * Time.deltaTime);
        /*if(transform.position.x <= -30)
        {
            Destroy(this.gameObject);
        }*/
        gameWater = gameController.GetComponent<GameController>().gameState == GameState.Water;
        gameFire = gameController.GetComponent<GameController>().gameState == GameState.Fire;
        gameEarth = gameController.GetComponent<GameController>().gameState == GameState.Earth;
        gameAir = gameController.GetComponent<GameController>().gameState == GameState.Air;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "_Portal")
        {
            Debug.LogError("Choca");
            Destroy(this.gameObject);
        }

        if (collision.tag == "Aire")
        {
            if (gameWater)
            {
                switch (randomStage)
                {
                    case 1:
                        gameController.GetComponent<GameController>().gameState = GameState.Fire;
                        gFire.SetActive(true);
                        break;

                    case 2:
                        gameController.GetComponent<GameController>().gameState = GameState.Earth;
                        gEarth.SetActive(true);
                        break;

                    case 3:
                        gameController.GetComponent<GameController>().gameState = GameState.Air;
                        gAir.SetActive(true);
                        break;

                    default:
                        Debug.Log("Entra en default!!!!");
                        break;
                }
            }

            if (gameFire)
            {
                switch (randomStage)
                {
                    case 1:
                        gameController.GetComponent<GameController>().gameState = GameState.Water;
                        gWater.SetActive(true);
                        break;

                    case 2:
                        gameController.GetComponent<GameController>().gameState = GameState.Earth;
                        gEarth.SetActive(true);
                        break;

                    case 3:
                        gameController.GetComponent<GameController>().gameState = GameState.Air;
                        gAir.SetActive(true);
                        break;

                    default:
                        Debug.Log("Entra en default!!!!");
                        break;
                }
            }

            if (gameEarth)
            {
                switch (randomStage)
                {
                    case 1:
                        gameController.GetComponent<GameController>().gameState = GameState.Fire;
                        gFire.SetActive(true);
                        break;

                    case 2:
                        gameController.GetComponent<GameController>().gameState = GameState.Water;
                        gWater.SetActive(true);
                        break;

                    case 3:
                        gameController.GetComponent<GameController>().gameState = GameState.Air;
                        gAir.SetActive(true);
                        break;

                    default:
                        Debug.Log("Entra en default!!!!");
                        break;
                }
            }

            if (gameAir)
            {
                switch (randomStage)
                {
                    case 1:
                        gameController.GetComponent<GameController>().gameState = GameState.Fire;
                        gFire.SetActive(true);
                        break;

                    case 2:
                        gameController.GetComponent<GameController>().gameState = GameState.Earth;
                        gEarth.SetActive(true);
                        break;

                    case 3:
                        gameController.GetComponent<GameController>().gameState = GameState.Water;
                        gWater.SetActive(true);
                        break;

                    default:
                        Debug.Log("PORTAL Entra en default!!!!");
                        break;
                }
            }
        }
    }
}