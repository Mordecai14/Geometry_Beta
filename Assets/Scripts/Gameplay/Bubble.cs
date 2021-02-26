using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    public Animator anim;
    Rigidbody2D rigidBodyPlayer;
    private float force = -3.6f;
    private float randPosX;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rigidBodyPlayer = gameObject.GetComponent<Rigidbody2D>();
        randPosX = Random.Range(20.52f, 27.5f);
;    }

    // Update is called once per frame
    void Update()
    {
       Destroy(gameObject, 8f);

        /*Vector3 pos =transform.position;
        //pos.x = 29.26654f;
        pos.y = Mathf.Sin(pos.x) * 10; // randPosX;
        transform.position = pos;*/
        transform.Rotate(new Vector3(0, 0, 3));

    }
    private void FixedUpdate()
    {
        rigidBodyPlayer.AddForce(new Vector2(force, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Aire" || collision.gameObject.tag == "Agua" || collision.gameObject.tag == "Tierra" || collision.gameObject.tag == "Fuego")
        {
            force = 0.0f;
            anim.SetBool("DestroyBubble", true);
            Destroy(this.gameObject, 1.3f);
            gameObject.transform.Rotate(new Vector3(0, 0, 0));

            foreach (Transform child in transform)
                GameObject.Destroy(child.gameObject, 0.8f);
        }
    }
}
