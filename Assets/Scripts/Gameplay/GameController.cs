using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public enum GameState { Idle, Playing, End, Water, Fire, Air, Earth };

public class GameController : MonoBehaviour
{
    //Gamestate & Instance this
    public GameState gameState;
    public static GameController instance;

    //Elementos para el cambio de escenario
    public GameObject waterScene, fireScene, earthScene, airScene;
    public GameObject waterCamera, fireCamera, eartCamera, airCamera;
    public GameObject playerWater, playerFire, PlayerEarth, PlayerAir;
    public GameObject gwater, gFire, gEarth, gAir;

    //Player & components
    public GameObject masterPlayer;

    //Gameplay Elements
    public Image fadePanel;
    public GameObject star;
    public GameObject losePanel;
    
    //UI
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int score = 0;
    //public Animator anim;

    //playerPrefbs
    public int highScore = 0;
    string highScoreKey = "HighScore";

    //Music and sounds
    public AudioSource audioSource;
    public AudioSource masterSong;
    public AudioClip[] deathSongs;
    public AudioClip[] mainSongs;

    private int deathRandom;
    private int randomSong;
    private bool canSound = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        score = 0;
        losePanel.SetActive(false);
        playerFire.SetActive(false);
        playerWater.SetActive(false);
        PlayerEarth.SetActive(false);
        PlayerAir.SetActive(false);
        waterCamera.SetActive(false);
        waterScene.SetActive(false);
        fireScene.SetActive(false);
        fireCamera.SetActive(false);
        earthScene.SetActive(false);
        eartCamera.SetActive(false);
        airScene.SetActive(false);
        airCamera.SetActive(false);

        FirstZone();
        //StartCoroutine(FadeIn());
        //StartCoroutine(StarSpawn());
        StartCoroutine(ScoreManager());

        //anim = GetComponent<Animator>();

        deathRandom = Random.Range(1, 3);
        randomSong = Random.Range(1, 3);
        audioSource.clip = mainSongs[randomSong];
        audioSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameState();

        if (gameState == GameState.End)
        {
            if (score > PlayerPrefs.GetInt(highScoreKey))
                PlayerPrefs.SetInt(highScoreKey, score);

            //scoreText.text = "" + score;
            PlayerPrefs.SetInt("LastScore", score);
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt(highScoreKey);

           //GameSounds();
        }
    }

    //--------------------
    //-----------------Funciones-------------
    //------------------
    
    public void GameSounds()
    {
        canSound = true;
        if (canSound)
        {
            //int randomSongDeath = Random.Range(1, 3);
            audioSource.Stop();
            audioSource.PlayOneShot(deathSongs[deathRandom]);
            canSound = false;
        }
    }

    public void FirstZone()
    {
        int randomState = Random.Range(1, 5);

        switch (randomState)
        {
            case 1:
                gameState = GameState.Water;
                waterCamera.SetActive(true);
                waterScene.SetActive(true);
                //gWater.SetActive(true);

                playerWater.SetActive(true);

                Debug.Log("Entra en zona de AWA ");
                break;
            case 2:
                gameState = GameState.Fire;
                fireScene.SetActive(true);
                fireCamera.SetActive(true);
                //gFire.SetActive(true);

                playerFire.SetActive(true);

                Debug.Log("Entra en zona de Fuego ");
                break;
            case 3:
                gameState = GameState.Earth;
                earthScene.SetActive(true);
                eartCamera.SetActive(true);
               //gEarth.SetActive(true);

                PlayerEarth.SetActive(true);

                Debug.Log("Entra en zona de Tierra ");
                break;
            case 4:
                gameState = GameState.Air;
                airScene.SetActive(true);
                airCamera.SetActive(true);
                //gAir.SetActive(true);

                PlayerAir.SetActive(true);

                Debug.Log("Entra en zona de Aire ");
                break;
            default:
                gameState = GameState.Water;
                playerWater.SetActive(true);
                waterCamera.SetActive(true);
                waterScene.SetActive(true);
                //gWater.SetActive(true);
                //masterPlayer.GetComponent<PlayerController>().indexState = 1;
                Debug.Log("Entra pero en default ");
                break;
        }
    }

    #region Check Game state
    void CheckGameState()
    {
        if(gameState == GameState.Water)
        {
            playerFire.SetActive(false);
            playerWater.SetActive(true);
            PlayerEarth.SetActive(false);
            PlayerAir.SetActive(false);

            waterCamera.SetActive(true);
            waterScene.SetActive(true);
            fireScene.SetActive(false);
            fireCamera.SetActive(false);
            earthScene.SetActive(false);
            eartCamera.SetActive(false);
            airScene.SetActive(false);
            airCamera.SetActive(false);

        } else if(gameState == GameState.Fire)
        {
            playerFire.SetActive(true);
            playerWater.SetActive(false);
            PlayerEarth.SetActive(false);
            PlayerAir.SetActive(false);

            waterCamera.SetActive(false);
            waterScene.SetActive(false);
            fireScene.SetActive(true);
            fireCamera.SetActive(true);
            earthScene.SetActive(false);
            eartCamera.SetActive(false);
            airScene.SetActive(false);
            airCamera.SetActive(false);

        } else if(gameState == GameState.Earth)
        {
            playerFire.SetActive(false);
            playerWater.SetActive(false);
            PlayerEarth.SetActive(true);
            PlayerAir.SetActive(false);

            waterCamera.SetActive(false);
            waterScene.SetActive(false);
            fireScene.SetActive(false);
            fireCamera.SetActive(false);
            earthScene.SetActive(true);
            eartCamera.SetActive(true);
            airScene.SetActive(false);
            airCamera.SetActive(false);

        }
        else if (gameState == GameState.Air)
        {
            playerFire.SetActive(false);
            playerWater.SetActive(false);
            PlayerEarth.SetActive(false);
            PlayerAir.SetActive(true);

            waterCamera.SetActive(false);
            waterScene.SetActive(false);
            fireScene.SetActive(false);
            fireCamera.SetActive(false);
            earthScene.SetActive(false);
            eartCamera.SetActive(false);
            airScene.SetActive(true);
            airCamera.SetActive(true);

        }
        else if(gameState == GameState.End)
        {
            StopAllCoroutines();
            losePanel.SetActive(true);
            //Time.timeScale = 0;
        }
    }

    #endregion

    //--------------------
    //-----------------Courutinas-------------
    //--------------------

    #region coroutines
    IEnumerator ScoreManager()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.7f);
            score++;
            scoreText.text = "" + score;
        }
    }
    IEnumerator StarSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.02f);
            Instantiate(star);
        }
    }

    IEnumerator FadeIn()
    {
        fadePanel.enabled = true;
        float t = fadePanel.color.a;
        while (t > 0)
        {
            t -= Time.deltaTime;
            fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, t);

            yield return 0;
        }
        fadePanel.enabled = false;
        //fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, 255f);
    }
    #endregion
}
