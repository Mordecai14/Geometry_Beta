using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    public Sprite[] spriteArray;
    public GameObject playerWater, playerFire, playerEarth, playerAir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void SetPlayerOne()
    {

        playerWater.GetComponent<SpriteRenderer>().sprite = spriteArray[0];
        playerWater.GetComponent<PlayerController>().tag = "Aire";

        playerFire.GetComponent<SpriteRenderer>().sprite = spriteArray[0];
        playerFire.GetComponent<PlayerController>().tag = "Aire";

        playerEarth.GetComponent<SpriteRenderer>().sprite = spriteArray[0];
        playerEarth.GetComponent<PlayerController>().tag = "Aire";

        playerAir.GetComponent<SpriteRenderer>().sprite = spriteArray[0];
        playerAir.GetComponent<PlayerController>().tag = "Aire";
    }
    public void SetPlayerTwo()
    {

        playerWater.GetComponent<SpriteRenderer>().sprite = spriteArray[1];
        playerWater.GetComponent<PlayerController>().tag = "Tierra";

        playerFire.GetComponent<SpriteRenderer>().sprite = spriteArray[1];
        playerFire.GetComponent<PlayerController>().tag = "Tierra";

        playerEarth.GetComponent<SpriteRenderer>().sprite = spriteArray[1];
        playerEarth.GetComponent<PlayerController>().tag = "Tierra";

        playerAir.GetComponent<SpriteRenderer>().sprite = spriteArray[1];
        playerAir.GetComponent<PlayerController>().tag = "Tierra";
    }
    public void SetPlayerThree()
    {

        playerWater.GetComponent<SpriteRenderer>().sprite = spriteArray[2];
        playerWater.GetComponent<PlayerController>().tag = "Agua";

        playerFire.GetComponent<SpriteRenderer>().sprite = spriteArray[2];
        playerFire.GetComponent<PlayerController>().tag = "Agua";

        playerEarth.GetComponent<SpriteRenderer>().sprite = spriteArray[2];
        playerEarth.GetComponent<PlayerController>().tag = "Agua";

        playerAir.GetComponent<SpriteRenderer>().sprite = spriteArray[2];
        playerAir.GetComponent<PlayerController>().tag = "Agua";
    }
    public void SetPlayerFour()
    {

        playerWater.GetComponent<SpriteRenderer>().sprite = spriteArray[3];
        playerWater.GetComponent<PlayerController>().tag = "Fuego";

        playerFire.GetComponent<SpriteRenderer>().sprite = spriteArray[3];
        playerFire.GetComponent<PlayerController>().tag = "Fuego";

        playerEarth.GetComponent<SpriteRenderer>().sprite = spriteArray[3];
        playerEarth.GetComponent<PlayerController>().tag = "Fuego";

        playerAir.GetComponent<SpriteRenderer>().sprite = spriteArray[3];
        playerAir.GetComponent<PlayerController>().tag = "Fuego";
    }
}
