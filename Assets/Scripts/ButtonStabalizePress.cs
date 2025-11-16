using UnityEngine;
using UnityEngine.Events;

public class ButtonStabalizePress : MonoBehaviour
{
    public GameObject pressButton;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    bool isPressed=false;
    public AudioSource buttonClip;
    public Renderer buttonIndicator;
    [SerializeField] int matElement;
    private GameManager gameManager;
    bool isPressable=false;

    void Awake()
    {
        gameManager=GameObject.Find("Game Manager").GetComponent<GameManager>(); 
        buttonIndicator.materials[matElement].color = Color.green;
 
    }

    void Update()
    {
      if (gameManager.buttonAction==true)
        {
            isPressable=true;

        } 
        
        if (gameManager.pulledLever==false&gameManager.buttonAction==true)
        {
            buttonIndicator.materials[matElement].color = Color.red;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed&isPressable)
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
        buttonIndicator.materials[matElement].color = Color.green;
        gameManager.pulledLever=true;
    }
    
}
