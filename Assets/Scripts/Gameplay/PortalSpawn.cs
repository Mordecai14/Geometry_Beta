using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawn : MonoBehaviour
{
    public static PortalSpawn instance;
    public GameObject portal;
    public GameObject gameC;
    public Sprite[] spriteArray;
    private int randomSkin;

    public int randomSpawn;

    public bool fireOn, waterOn, earthOn, airOn;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<SpriteRenderer>().sprite = spriteArray[0];
        randomSpawn = Random.Range(20, 30);
        InvokeRepeating("Spawn", 10, randomSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        waterOn = gameC.GetComponent<GameController>().gameState == GameState.Water;
        fireOn = gameC.GetComponent<GameController>().gameState == GameState.Fire;
        earthOn = gameC.GetComponent<GameController>().gameState == GameState.Earth;
        airOn = gameC.GetComponent<GameController>().gameState == GameState.Air;
    }

    void Spawn()
    {
        if (waterOn)
        {
            Vector3 pos = transform.position;
            transform.position = pos;
            //portal.GetComponent<SpriteRenderer>().sprite = spriteArray[0];
            Animator anim = Instantiate(portal, new Vector2(29.26654f, 1f), Quaternion.identity).GetComponent<Animator>();
            anim.SetBool("Water", true);
            anim.SetBool("Fire", false);
            anim.SetBool("Earth", false);
            anim.SetBool("Air", false);
            GetNewTime();
        }
        if (fireOn)
        {
            Vector3 pos = transform.position;
            transform.position = pos;
            //portal.GetComponent<SpriteRenderer>().sprite = spriteArray[1];
            Animator anim = Instantiate(portal, new Vector2(29.26654f, -12.01f), Quaternion.identity).GetComponent<Animator>();
            anim.SetBool("Water", false);
            anim.SetBool("Fire", true);
            anim.SetBool("Earth", false);
            anim.SetBool("Air", false);
            GetNewTime();
        }
        if (earthOn)
        {
            Vector3 pos = transform.position;
            transform.position = pos;
            //portal.GetComponent<SpriteRenderer>().sprite = spriteArray[2];
            Animator anim = Instantiate(portal, new Vector2(29.26654f, 12.28f), Quaternion.identity).GetComponent<Animator>();
            anim.SetBool("Water", false);
            anim.SetBool("Fire", false);
            anim.SetBool("Earth", true);
            anim.SetBool("Air", false);
            GetNewTime();
        }
        if (airOn)
        {
            Vector3 pos = transform.position;
            transform.position = pos;
            //portal.GetComponent<SpriteRenderer>().sprite = spriteArray[3];

            Animator anim = Instantiate(portal, new Vector2(29.26654f, 25.52f), Quaternion.identity).GetComponent<Animator>();
            anim.SetBool("Water", false);
            anim.SetBool("Fire", false);
            anim.SetBool("Earth", false);
            anim.SetBool("Air", true);
            GetNewTime();
        }
    }

    void GetNewTime()
    {
        randomSpawn = Random.Range(10, 21);
    }
}
