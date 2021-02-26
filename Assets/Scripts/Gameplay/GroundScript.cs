using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{

    public float scrollSpeed;
    private float destroyThis;
    public GameObject gameC;
    private SpriteRenderer spriteRender;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        destroyThis = -45.0f;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(gameObject.tag == "FirstGroundWater" || gameObject.tag == "FirstGroundFire" || gameObject.tag == "FirstGroundEarth" || gameObject.tag == "FirstGroundAir")
        {
            FirstGround();
        }
        else
        {
            GenericGround();
        }
       
    }

    public void FirstGround()
    {
        if(gameObject.tag == "FirstGroundWater")
        {

            if (transform.position.x >= destroyThis)
            {
                transform.Translate(Vector2.left * (scrollSpeed) * Time.deltaTime);
            }
            else
            {
                Debug.Log("Llega al final");
                gameObject.transform.position = new Vector2(8.25f, -4.3f);
                gameObject.SetActive(false);
            }
        }
        if (gameObject.tag == "FirstGroundFire")
        {

            if (transform.position.x >= destroyThis)
            {
                transform.Translate(Vector2.left * (scrollSpeed) * Time.deltaTime);
            }
            else
            {
                Debug.Log("Llega al final");
                gameObject.transform.position = new Vector2(8.8f, -17);
                gameObject.SetActive(false);
            }
        }
        if (gameObject.tag == "FirstGroundEarth")
        {

            if (transform.position.x >= destroyThis)
            {
                transform.Translate(Vector2.left * (scrollSpeed) * Time.deltaTime);
            }
            else
            {
                Debug.Log("Llega al final");
                gameObject.transform.position = new Vector2(9f, 7.3f);
                gameObject.SetActive(false);
            }
        }
        if (gameObject.tag == "FirstGroundAir")
        {

            if (transform.position.x >= destroyThis)
            {
                transform.Translate(Vector2.left * (scrollSpeed) * Time.deltaTime);
            }
            else
            {
                Debug.Log("Llega al final");
                gameObject.transform.position = new Vector2(9.81f, 20.38f);
                gameObject.SetActive(false);
            }
        }


        /*if (transform.position.x >= destroyThis)
        {
            transform.Translate(Vector2.left * (scrollSpeed) * Time.deltaTime);
        }
        else
        {
            Debug.Log("Llega al final");
            gameObject.SetActive(false);
            gameObject.transform.position = new Vector2(8.271f, -4.437f);
        }*/
    }

    public void GenericGround()
    {
        transform.Translate(Vector2.left * (scrollSpeed) * Time.deltaTime);
        if (transform.position.x <= destroyThis)
        {
            Destroy(this.gameObject);
        }
    }
}
