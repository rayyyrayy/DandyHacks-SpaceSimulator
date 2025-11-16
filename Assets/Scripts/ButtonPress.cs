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
    public AudioSource buttonClip;
    public Renderer buttonIndicator;

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
        pressButton.transform.localPosition= new Vector3 (-1.702574e-10f,-0.001701512f,0.01476345f);
        presser=other.gameObject;
        onPress.Invoke();
        isPressed=true;    
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject==presser)
        {
            pressButton.transform.localPosition= new Vector3 (-1.702574e-10f,-0.001701512f,0.02476345f);
            onRelease.Invoke();
            isPressed=false;
        }
        
    }

    public void buttonPressed()
    {
        buttonClip.Play();
        buttonIndicator.materials[2].color = Color.green;
    }
    
}