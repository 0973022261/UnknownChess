using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour {

    public const int VIBRATIONON = 1;
    public const int VIBRATIONOFF = 0;

    GameObject intro_background;
    GameObject teamName_text;
    GameObject audio_background;
    GameObject ChessGameName;

    GameObject buttonbackground;
    GameObject gamestartButtonClickedScene;
    GameObject settingButtonClickedScene;

    GameObject soundButton;
    GameObject vibrateButton;
    GameObject buttonClickSound;

    bool vibrationOnOff = false;
    bool vibrationcheck = false;
    bool soundbuttoncheck = false;

    // Use this for initialization
    void Start()
    {
        audio_background = GameObject.Find("audio_background");
        teamName_text = GameObject.Find("teamName_text");
        intro_background = GameObject.Find("intro_background");
        ChessGameName = GameObject.Find("ChessGameName");

        buttonbackground = GameObject.Find("buttonbackground");
        gamestartButtonClickedScene = GameObject.Find("gamestartButtonClickedScene");
        settingButtonClickedScene = GameObject.Find("settingButtonClickedScene");

        buttonClickSound = GameObject.Find("buttonClickSound");
        soundButton = GameObject.Find("soundButton");
        vibrateButton = GameObject.Find("vibrateButton");
        audio_background.GetComponent<AudioSource>().enabled = false;

        StartCoroutine("Intro");
    }

    IEnumerator Intro()
    {
        teamName_text.GetComponent<Text>().text = "COUT";
        yield return new WaitForSeconds(2.0f);
        teamName_text.GetComponent<Text>().text = "Created by\n인형민\n박환석\n여대현\n김민호";
        yield return new WaitForSeconds(2.0f);

        intro_background.transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1.0f);
        ChessGameName.GetComponent<Animator>().enabled = true;
        audio_background.GetComponent<AudioSource>().enabled = true;
        yield return new WaitForSeconds(1.0f);
        StartCoroutine("second");
    }

    IEnumerator second()
    {
        buttonbackground.transform.localScale = new Vector3(1, 1, 1);
        gamestartButtonClickedScene.transform.localScale = new Vector3(0, 0, 0);
        settingButtonClickedScene.transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1.0f);
    }

    public void gameStartbuttonClick()
    {
        StartCoroutine("buttonclickSound");
        buttonbackground.transform.localScale = new Vector3(0, 0, 0);
        gamestartButtonClickedScene.transform.localScale = new Vector3(1, 1, 1);
        settingButtonClickedScene.transform.localScale = new Vector3(0, 0, 0);
    }
    public void settingButtonClick()
    {
        StartCoroutine("buttonclickSound");
        buttonbackground.transform.localScale = new Vector3(0, 0, 0);
        gamestartButtonClickedScene.transform.localScale = new Vector3(0, 0, 0);
        settingButtonClickedScene.transform.localScale = new Vector3(1, 1, 1);
    }
    public void quitButtonClick()
    {
        StartCoroutine("buttonclickSound");
        Application.Quit();
    }

    public void pvpButtonClick()
    {
        StartCoroutine("buttonclickSound");
        //Chess game scene
        SceneManager.LoadScene(1);

    }
    public void backButtonClick()
    {
        buttonbackground.transform.localScale = new Vector3(1, 1, 1);
        gamestartButtonClickedScene.transform.localScale = new Vector3(0, 0, 0);
        settingButtonClickedScene.transform.localScale = new Vector3(0, 0, 0);
        StartCoroutine("buttonclickSound");
    }
    // not yet bluetooth module..
    public void pvcButton()
    {
        StartCoroutine("buttonclickSound");
    }

    public void soundButtonClick()
    {
        if (!soundbuttoncheck)
        {
            audio_background.GetComponent<AudioSource>().enabled = false;
            soundButton.GetComponentInChildren<Text>().text = "Sound : OFF";
            soundbuttoncheck = !soundbuttoncheck;
        }
        else
        {
            audio_background.GetComponent<AudioSource>().enabled = true;
            soundButton.GetComponentInChildren<Text>().text = "Sound : ON";
            soundbuttoncheck = !soundbuttoncheck;
        }
        StartCoroutine("buttonclickSound");
    }
    public void vibrateButtonClick()
    {
        if (PlayerPrefs.GetInt("vibrate") != 1)
        {
            PlayerPrefs.SetInt("vibrate", 1);
            vibrateButton.GetComponentInChildren<Text>().text = "vibrate : OFF";
        }else
        {
            PlayerPrefs.SetInt("vibrate", 0);
            vibrateButton.GetComponentInChildren<Text>().text = "vibrate : ON";
        }
        StartCoroutine("buttonclickSound");
    }
    IEnumerator buttonclickSound()
    {

        switch (PlayerPrefs.GetInt("vibrate"))
        {
            case 0:
                Handheld.Vibrate();
          
                break;
            case 1:
                buttonClickSound.GetComponent<AudioSource>().enabled = true;
                yield return new WaitForSeconds(0.1f);
                buttonClickSound.GetComponent<AudioSource>().enabled = false;
                break;
            default:
                break;
        }
    }
}
