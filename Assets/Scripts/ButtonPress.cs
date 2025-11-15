using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class ButtonPress : MonoBehaviour
{
    public GameObject pressButton;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    bool isPressed=false;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
        pressButton.transform.localPosition= new Vector3 (0,0.003f,0);
        presser=other.gameObject;
        onPress.Invoke();
        isPressed=true;    
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject==presser)
        {
            pressButton.transform.localPosition= new Vector3 (0,0.015f,0);
            onRelease.Invoke();
            isPressed=false;
        }
        
    }

    public void playClip()
    {
        audioSource.Play();
    }
    
}