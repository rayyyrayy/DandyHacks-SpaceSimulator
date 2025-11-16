using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    public TextMeshProUGUI introCaption;
    public AudioSource introMessage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(2);
        introMessage.Play();
        introCaption.gameObject.SetActive(true);
        yield return new WaitForSeconds(7);
        introCaption.gameObject.SetActive(false);
    }
}
