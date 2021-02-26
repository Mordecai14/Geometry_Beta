using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsGameController : MonoBehaviour
{
    public Button[] buttons;
    //public GameObject banner, banner2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void BackMenu()
    {
        foreach (Button disableButtons in buttons)
        {
            disableButtons.enabled = false;
        }
        SceneManager.LoadScene(0);
        //banner.GetComponent<AdmobAds_PL>().bannerLose.Destroy();
        //banner2.GetComponent<AdmobAds_PL>().bannerLose2.Destroy();
    }

    public void RestartGame()
    {
        foreach (Button disableButtons in buttons)
        {
            disableButtons.enabled = false;
        }
        SceneManager.LoadScene(1);
    }

    /*private void OnDisable()
    {
        foreach (Button disableButtons in buttons)
        {
            disableButtons.enabled = true;
        }
    }*/
}
