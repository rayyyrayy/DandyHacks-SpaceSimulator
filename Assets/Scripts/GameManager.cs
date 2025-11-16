using System.Collections;
using TMPro;
using Unity.VisualScripting;
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
    private bool countdownEnded=false;
    public AudioSource stabalizeMessage;
    public TextMeshProUGUI stabalizeCaption; 
    public bool buttonAction=false;
    public bool pulledLever=false;
    public AudioSource notbadPlayer;
    public AudioSource thrustMessage;
    public TextMeshProUGUI thrustCaption;
    public bool needThrust=false;

    public bool leverIsPulled=false;
    public TextMeshProUGUI emergencyOneCaption;
    public AudioSource emergencyOneMessage;

    public AudioSource mistakesMessage;
    public AudioSource losingYouMesssage;
    public TextMeshProUGUI mistakesCaption;
    public TextMeshProUGUI losingYouCaption;
    public TextMeshProUGUI levererrorCaption;
    public TextMeshProUGUI buttonErrorCaption;
    public TextMeshProUGUI shutdownCaption;
    public bool fixlever=false;
    public bool leverErrorPulled=false;
    public AudioSource buttonFailure;
    public ParticleSystem smokeparticle;
    public ParticleSystem sparkParticle;
    public AudioSource shutdownAudio;
    public GameObject parentPlayer;
    
    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartGame());
        StartCoroutine(MissionMessage());
        StartCoroutine(StartMission());
        StartCoroutine(StablizeShip());
        StartCoroutine(AdjustThruster());
        StartCoroutine(FirstEmergency());
        StartCoroutine(EmegencySequence());
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
        countdownEnded=true;

    }

    IEnumerator StablizeShip()
    {
        while (countdownEnded== false)
        {
            yield return null;
        }
        yield return new WaitForSeconds(1);
        stabalizeCaption.gameObject.SetActive(true);
        stabalizeMessage.Play();
        yield return new WaitForSeconds(5);
        stabalizeCaption.gameObject.SetActive(false);
        buttonAction=true;

    }

    IEnumerator AdjustThruster()
    {
        while (pulledLever==false)
        {
            yield return null;
        }
        yield return new WaitForSeconds(1);
        notbadPlayer.Play();
        yield return new WaitForSeconds(5);
        thrustCaption.gameObject.SetActive(true);
        thrustMessage.Play();
        yield return new WaitForSeconds(6);
        thrustCaption.gameObject.SetActive(false);
        needThrust=true;
    }

    IEnumerator FirstEmergency()
    {
        while (leverIsPulled==false)
        {
            yield return null;
        }
        yield return new WaitForSeconds(1);
        emergencyOneCaption.gameObject.SetActive(true);
        emergencyOneMessage.Play();
        yield return new WaitForSeconds(7);
        emergencyOneCaption.gameObject.SetActive(false);
        mistakesCaption.gameObject.SetActive(true);
        mistakesMessage.Play();
        yield return new WaitForSeconds(4);
        mistakesCaption.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        losingYouCaption.gameObject.SetActive(true);
        losingYouMesssage.Play();
        yield return new WaitForSeconds(3.5f);
        losingYouCaption.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        levererrorCaption.gameObject.SetActive(true);
        fixlever=true;
    }

    IEnumerator EmegencySequence()
    {
        while (leverErrorPulled==false)
        {
            yield return null;
        }
        buttonErrorCaption.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        buttonFailure.Play();
        smokeparticle.Play();
        yield return new WaitForSeconds(3);
        buttonErrorCaption.gameObject.SetActive(false);
        shutdownCaption.gameObject.SetActive(true);
        sparkParticle.Play();
        shutdownAudio.Play();

        
    }

   


}
