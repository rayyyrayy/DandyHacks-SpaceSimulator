using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    public TextMeshProUGUI introCaption;
    public AudioSource introMessage;
    private bool missionMessageStarted=false;
    public AudioSource missionMessage;
    public TextMeshProUGUI missionMessageCaption;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartGame());
        StartCoroutine(MissionMessage());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2);
        introMessage.Play();
        introCaption.gameObject.SetActive(true);
        yield return new WaitForSeconds(7);
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

    }
}
