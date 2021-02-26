using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    public GameObject generalObj, panelTuto, next1, baners, panelAbstract, menuPanel;
    public Button[] buttons;
    private int urls;
    public AudioSource audioPlay;
    public AudioClip normalAudio;
    //public AudioClip clip;


    private void Awake()
    {
        //source = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
    }


   #region Exit Button
    public void Exit()
    {
        foreach(Button disableButtons in buttons)
        {
            disableButtons.enabled = false;
        }
        audioPlay.PlayOneShot(normalAudio);
        Application.Quit();
        //StartCoroutine(ExitGameC());
    }
    IEnumerator ExitGameC()
    {
        yield return new WaitWhile(() => audioPlay.isPlaying);
        Application.Quit();
    }
    #endregion
   #region Play Button
    public void PlayGame()
    {
        foreach (Button disableButtons in buttons)
        {
            disableButtons.enabled = false;
        }
        audioPlay.Play();
        StartCoroutine(LoadGame());
        

        //baners.GetComponent<AdMobAds>().bannerHome.Hide();
        //baners.GetComponent<AdMobAds>().bannerHome2.Hide();
    }
    IEnumerator LoadGame()
    {
        yield return new WaitWhile(() => audioPlay.isPlaying);
        Debug.LogWarning("va a cargar");
        SceneManager.LoadScene(1);
        //baners.GetComponent<AdMobAds>().bannerHome.Destroy();
        //baners.GetComponent<AdMobAds>().bannerHome2.Destroy();
        
    }
    #endregion
   #region Buttons
    public void Options()
    {
        foreach (Button disableButtons in buttons)
        {
            disableButtons.enabled = false;
        }
        audioPlay.PlayOneShot(normalAudio);
        generalObj.SetActive(false);
        panelTuto.SetActive(true);
    }
    public void Next()
    {
        foreach (Button disableButtons in buttons)
        {
            disableButtons.enabled = false;
        }
        audioPlay.PlayOneShot(normalAudio);
        next1.SetActive(true);
       panelTuto.SetActive(false);
    }
    public void Back()
    {
        foreach (Button disableButtons in buttons)
        {
            disableButtons.enabled = true;
        }
        audioPlay.PlayOneShot(normalAudio);
        next1.SetActive(false);
        generalObj.SetActive(true);
    }
    public void AbstractTeam()
    {
        foreach (Button disableButtons in buttons)
        {
            disableButtons.enabled = true;
        }
        audioPlay.PlayOneShot(normalAudio);
        menuPanel.SetActive(false);
        panelAbstract.SetActive(true);
    }
    public void CloseTeam()
    {
        audioPlay.PlayOneShot(normalAudio);
        menuPanel.SetActive(true);
        panelAbstract.SetActive(false);
    }
    public void AbstractURL()
    {
        Application.OpenURL("https://abstractstudios.com.mx/");
    }
    public void AbstractFace()
    {
        Application.OpenURL("https://www.facebook.com/AbstractStudiosMx");
    }
    public void AbstractTweet()
    {
        Application.OpenURL("https://twitter.com/AbstractStudio5");
    }
    public void AbstractIG()
    {
        Application.OpenURL("https://www.instagram.com/abstractstudiosmx/");
    }
    #endregion
}
