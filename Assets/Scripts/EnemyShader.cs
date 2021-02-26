using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShader : MonoBehaviour
{

    private Animator enemyFadeAnim;

    // Start is called before the first frame update
    void Start()
    {
        enemyFadeAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Tierra"  && gameObject.tag == "eTierra")
        {
            //Debug.LogError("Choca con tierrrraaaaaaaaaaa");
            //Instantiate(fadeEnemy, transform.position, Quaternion.identity);
            //enemyFadeAnim.enabled = true;
            //enemyFadeAnim.Play("Fade", 0);
        }

            
    }
}
    
