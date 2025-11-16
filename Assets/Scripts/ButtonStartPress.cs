using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class ButtonStartPress : MonoBehaviour
{
    public GameObject Everything;
    public float speed = 10000.0f;
    public float duration = 5.0f;

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
    }

    void Update()
    {
      if (gameManager.startMissionStartedMessage==true)
        {
            isPressable=true;
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

        StartCoroutine(MoveUpCoroutine());

        buttonIndicator.materials[matElement].color = Color.green;
        gameManager.startMissionStarted=true;
    }

    private IEnumerator MoveUpCoroutine()
    {
        float elapsedTime = 0;
        Vector3 initialPosition = Everything.transform.position;

        yield return new WaitForSeconds(6);

        while (elapsedTime < duration)
        {
            Everything.transform.position += new Vector3(0, -1 * speed * Time.deltaTime, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}    