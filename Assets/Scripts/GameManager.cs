using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    public TextMeshProUGUI introCaption;
    public AudioSource introMessage;
    public bool missionMessageStarted=false;
    public AudioSource missionMessage;
    public TextMeshProUGUI missionMessageCaption;
    public AudioSource playerNervous;
    public bool startMissionStarted=false;

    public bool startMissionStartedMessage=false;
    private bool missionMessageStartedEnded=false;
    public AudioSource startMissionmessage;

    public TextMeshProUGUI startMissionCaption;
    public AudioSource playerOhResponse;
    public TextMeshProUGUI countdownCaption;
    public AudioSource countdownMessage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartGame());
        StartCoroutine(MissionMessage());
        StartCoroutine(StartMission());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2);
        introMessage.Play();
        introCaption.gameObject.SetActive(true);
        yield return new WaitForSeconds(6);
        introCaption.gameObject.SetActive(false);
        missionMessageStarted=true;
    }

    IEnumerator MissionMessage()
    {
        while (missionMessageStarted == false)
        {
            yield return null; 
        }
        yield return new WaitForSeconds(1);
        missionMessage.Play();
        missionMessageCaption.gameObject.SetActive(true);
        yield return new WaitForSeconds(7);
        missionMessageCaption.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        playerNervous.Play();
        missionMessageStartedEnded=true;
        
    }

    IEnumerator StartMission()
    {
        while (missionMessageStartedEnded == false)
        {
            yield return null; 
        }
        yield return new WaitForSeconds(5);
        startMissionmessage.Play();
        startMissionCaption.gameObject.SetActive(true);
        yield return new WaitForSeconds(6.5f);
        startMissionCaption.gameObject.SetActive(false);
        yield return new WaitForSeconds(.5f);
        playerOhResponse.Play();
        yield return new WaitForSeconds(2);
        startMissionStartedMessage=true;
        
        while (startMissionStarted == false)
        {
            yield return null; 
        }
        yield return new WaitForSeconds(.5f);
        countdownMessage.Play();
        countdownCaption.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        countdownCaption.gameObject.SetActive(false);
    }


}
