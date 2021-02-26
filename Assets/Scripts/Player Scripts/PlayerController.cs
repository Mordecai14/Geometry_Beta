using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public GameObject gameController;
    public float jumpForce, doubleJForce;
    public float jumpTime;
    public float localGravityScale;
    private float radio = 0.65f;
    public bool enSuelo = false;
    public bool go = true;
    public Transform comprobarSuelo;
    public LayerMask mascaraSuelo;
    //private Animator anim;
    //private float time = 1;
    //private float rand;
    // Variables para salto v2.0 Clic presionado
    public float jumpTimeCounter;
    public bool isJumping;
    public bool firstTime = true;
    //
    public Rigidbody2D rigidBodyPlayer;
    public SpriteRenderer playerSprite;

    //
    public int saltosCount;

    public Sprite[] skinsArray;
    public int randomSkin;
    public int indexState;
    //Particles and shaders
    public GameObject fadep;
    public GameObject blue, red, green, whithe;
    public GameObject normalEnemy, redEnemy, blueEnemy, greenEnemy;

    //Audio and songs
    public AudioSource audioSource;
    public AudioClip clip;
    public AudioClip clipDestroy;

    /*public float lifeTime = 5f;
    public float minimumVertexDistance = 0.1f;
    public Vector3 lineVelocity;
    LineRenderer line;
    List<Vector3> points;
    Queue<float> spawnTimes = new Queue<float>();*/

    //public Animator enemyFadeAnim;

    // Start is called before the first frame update

    private void Awake()
    {
        Time.timeScale = 1;
        /*line = GetComponent<LineRenderer>();
        line.useWorldSpace = true;
        points = new List<Vector3>() { transform.position };
        line.SetPosition(points.ToArray());*/
    }
    /*void AddPoint(Vector3 position)
    {
        points.Insert(1, position);
        spawnTimes.Enqueue(Time.time);
    }
    void RemovePoint()
    {
        spawnTimes.Dequeue();
        points.RemoveAt(points.Count - 1); //remove corresponding oldest point at the end
    }*/
    void Start()
    {
        //fadep.SetActive(false);
        //fadeEnemy = GetComponent<Animator>();
        CheckGameState();
        playerSprite = GetComponent<SpriteRenderer>();
        rigidBodyPlayer.gravityScale = localGravityScale;
        saltosCount = 0;

        randomSkin = Random.Range(0, 4);
        GetComponent<SpriteRenderer>().sprite = skinsArray[randomSkin];
        //Cambia el Tag conforme al skin
        if (randomSkin == 0)
        {
            GetComponent<PlayerController>().tag = "Aire";
        }
        else if (randomSkin == 1)
        {
            GetComponent<PlayerController>().tag = "Tierra";
        }
        else if (randomSkin == 2)
        {
            GetComponent<PlayerController>().tag = "Agua";
        }
        else if (randomSkin == 3)
        {
            GetComponent<PlayerController>().tag = "Fuego";
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*while (spawnTimes.Count > 0 && spawnTimes.Peek() + lifeTime < Time.time)
        {
            RemovePoint();
        }

        Vector3 diff = -lineVelocity * Time.deltaTime;
        for(int i = 1; i < points.Count; i++)
        {
            points[i] += diff;
        }
        //add new point
        if(points.Count < 2 || Vector3.Distance(transform.position, points[1]) > minimumVertexDistance)
        {
            AddPoint(transform.position);
        }
        points[0] = transform.position;

        //save
        line.positionCount = points.Count;
        line.SetPosition(points.ToArray());
        */
        CheckGameState();
        if (!IspointerOverUIObject())
        {
            //SingleJump();
            //DoubleJump();
        }

    }

    private void FixedUpdate()
    {
        //----Crea un circulo que detecta la mascara del suelo al tocarlo y lo pone 
        //en la variable de enSuelo
        enSuelo = Physics2D.OverlapCircle(comprobarSuelo.position, radio, mascaraSuelo);
        //anim.SetBool("Grounded", enSuelo);
    }

    //--------------------
    //-----------------Funciones-------------
    //--------------------
    private bool IspointerOverUIObject() //Revisa donde se esta haciendo click para no interactuar en gameplay con la interfaz
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        //Debug.Log(results.Count);
        if(results.Count <= 2)
        {
            SingleJump();
            DoubleJump();
        }
        return results.Count > 0;
    }
    public void SingleJump()
    {

        //Solo en zona de aire
        if(gameController.GetComponent<GameController>().gameState == GameState.Air)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                //rigidBodyPlayer.gravityScale = rigidBodyPlayer.gravityScale;
                rigidBodyPlayer.velocity = Vector2.up * jumpForce;
            }
        }

        //----Para hacer el salto con tiempo del clic presionado----//
        if (Input.GetKeyDown(KeyCode.Mouse0) && enSuelo)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rigidBodyPlayer.velocity = Vector2.up * jumpForce;

        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //anim.SetBool("Touch", go);
            rigidBodyPlayer.gravityScale = localGravityScale;
        }
        if (Input.GetKey(KeyCode.Mouse0) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rigidBodyPlayer.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isJumping = false;
        }
    }

    public void DoubleJump()
    {

        if (gameController.GetComponent<GameController>().gameState != GameState.Air) 
        {
            if (enSuelo == false && saltosCount > 0 && saltosCount < 2 && Input.GetKeyDown(KeyCode.Mouse0))
            {
                rigidBodyPlayer.velocity = Vector2.up * doubleJForce;
            }
            if (enSuelo == true)
            {
                saltosCount = 0;
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0) && enSuelo == false)
            {
                saltosCount++;
            }
        }
    }

    public void CheckGameState()
    {
        bool gameWater = gameController.GetComponent<GameController>().gameState == GameState.Water;
        bool gameFire = gameController.GetComponent<GameController>().gameState == GameState.Fire;
        bool gameEarth = gameController.GetComponent<GameController>().gameState == GameState.Earth;
        bool gameAir = gameController.GetComponent<GameController>().gameState == GameState.Air;
        

        if (gameWater)
        {
            //transform.position = new Vector2(-5.86f, -2.34f);
            
        }
        if (gameFire)
        {
            //transform.position = new Vector2(-5.86f, -15.53f);
        }
        if (gameEarth)
        {
           //transform.position = new Vector2(-5.86f, 9f);
        }
        if (gameAir)
        {
            //transform.position = new Vector2(-5.86f, 22f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Aire" &&  collision.gameObject.tag == "Portal")
        {
            Debug.LogError(collision.gameObject.tag);
            audioSource.PlayOneShot(clip);
        }
        /*else
        {
            audioSource.PlayOneShot(clipDestroy, 0.2f);
        }*/

        if(collision.gameObject.tag == "eAguaNodestroy" && gameObject.tag == "Fuego")
        {
            Instantiate(red, transform.position, Quaternion.identity);
            StartCoroutine(WaitToEnd());
        }
        else if(collision.gameObject.tag == "eAguaNodestroy" && gameObject.tag == "Tierra")
        {
            Instantiate(green, transform.position, Quaternion.identity);
            StartCoroutine(WaitToEnd());
        }
        else if (collision.gameObject.tag == "eAguaNodestroy" && gameObject.tag == "Aire")
        {
            Instantiate(whithe, transform.position, Quaternion.identity);
            StartCoroutine(WaitToEnd());
        }


        if (gameObject.tag == "Agua" && (collision.gameObject.tag == "eTierra" || collision.gameObject.tag == "eFuego" || collision.gameObject.tag == "eAire" || collision.tag == "GenericEnemy"))
        {
            Destroy(collision.gameObject);
            Instantiate(blue, transform.position, Quaternion.identity);
            StartCoroutine(WaitToEnd());
            //gameController.GetComponent<GameController>().gameState = GameState.End;
        }
        else if (gameObject.tag == "Tierra" && (collision.gameObject.tag == "eAgua" || collision.gameObject.tag == "eFuego" || collision.gameObject.tag == "eAire" || collision.tag == "GenericEnemy"))
        {
            Destroy(collision.gameObject);
            Instantiate(green, transform.position, Quaternion.identity);
            StartCoroutine(WaitToEnd());
            //gameController.GetComponent<GameController>().gameState = GameState.End;
        }
        else if (gameObject.tag == "Fuego" && (collision.gameObject.tag == "eAgua" || collision.gameObject.tag == "eTierra" || collision.gameObject.tag == "eAire" || collision.tag == "GenericEnemy"))
        {
            Destroy(collision.gameObject);
            Instantiate(red, transform.position, Quaternion.identity);
            StartCoroutine(WaitToEnd());
            //gameController.GetComponent<GameController>().gameState = GameState.End;
        }
        else if (gameObject.tag == "Aire" && (collision.gameObject.tag == "eAgua" || collision.gameObject.tag == "eTierra" || collision.gameObject.tag == "eFuego" || collision.tag == "GenericEnemy"))
        {
            Destroy(collision.gameObject);
            Instantiate(whithe, transform.position, Quaternion.identity);
            StartCoroutine(WaitToEnd());
            //gameController.GetComponent<GameController>().gameState = GameState.End;
        }
       

        if(gameObject.tag == "Agua" && collision.gameObject.tag == "eAgua")
        {
            Instantiate(blueEnemy, transform.position, Quaternion.identity);
            //Instantiate(fadeEnemy, transform.position, Quaternion.identity);
            //fadeEnemy.GetComponent<Animator>().Play("", 0);

            audioSource.PlayOneShot(clipDestroy, 0.2f);
            Destroy(collision.gameObject);
        }
        else if(gameObject.tag == "Tierra" && collision.gameObject.tag == "eTierra")
        {
            Instantiate(greenEnemy, transform.position, Quaternion.identity);
            //Instantiate(fadeEnemy, transform.position, Quaternion.identity);

            audioSource.PlayOneShot(clipDestroy, 0.2f);
            Destroy(collision.gameObject);
        }
        else if(gameObject.tag == "Fuego" && collision.gameObject.tag == "eFuego")
        {
            Instantiate(redEnemy, transform.position, Quaternion.identity);
            //Instantiate(fadeEnemy, transform.position, Quaternion.identity);

            audioSource.PlayOneShot(clipDestroy, 0.2f);
            Destroy(collision.gameObject);
        }
        else if(gameObject.tag == "Aire" && collision.gameObject.tag == "eAire")
        {
            //Instantiate(enemy, transform.position, Quaternion.identity);
            //Instantiate(fadeEnemy, transform.position, Quaternion.identity);

            audioSource.PlayOneShot(clipDestroy, 0.2f);
            Destroy(collision.gameObject);
        }
    }
    //----------------------------------------
    //-----------------Courutines-------------
    //--------------------------------------
    IEnumerator FadePortalBack()
    {

        yield return 0;
        fadep.SetActive(false);
        Debug.Log("Entra a la coroutina");
    }
    IEnumerator WaitToEnd()
    {
        //gameObject.SetActive(false);
        gameController.GetComponent<GameController>().GameSounds();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(0.35f);
        gameController.GetComponent<GameController>().gameState = GameState.End;
        Destroy(gameObject);
        Debug.Log("Fin del Juego");
    }
}
