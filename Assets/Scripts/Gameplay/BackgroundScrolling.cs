using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float scrollSpeed, startPosition;
    private float lenght;

    // Start is called before the first frame update
    void Start()
    {
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        if(gameObject.layer == 9 || gameObject.layer == 10) //Checa en que layer esta para darle mas o menos posicion de regreso
        {
            if (transform.position.x <= 0 - lenght)
            {
                transform.position = new Vector3(startPosition, transform.position.y, 6.42f);
            }
        }
        else
        {
            if (transform.position.x <= -10 - lenght)
            {
                transform.position = new Vector2(startPosition, transform.position.y);
            }
        }
    }
}
