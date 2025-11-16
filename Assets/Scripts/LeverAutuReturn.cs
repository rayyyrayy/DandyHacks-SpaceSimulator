using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;


public class LeverAutoReturn : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    public float returnSpeed = 450f;
    public float thresholdAngle = 90f;
    public HingeJoint hinge;
    public ChangeMaterialColor cc;
    public AudioSource audioSouce;
    public UnityEvent pullDown;
    private bool isGrabbed = false;
    private Quaternion startRotation;
    private bool shouldReturn;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager=GameObject.Find("Game Manager").GetComponent<GameManager>();
        if (grabInteractable == null)
            grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        startRotation = transform.localRotation;

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
        grabInteractable.enabled=false;
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
    }

    private void OnRelease(SelectExitEventArgs args)
    {

        isGrabbed = false;

        float currentAngle;

        if (hinge != null)
        {
            currentAngle = Mathf.Abs(hinge.angle);
        }
        else
        {
            currentAngle = Quaternion.Angle(startRotation, transform.localRotation);
        }

        if (currentAngle >= thresholdAngle)
        {
            shouldReturn = true;      

        }
        else
        {
            shouldReturn = false;
        }
    }

    private void Update()
    {
        if (gameManager.countdownEnded==true)
        {
            grabInteractable.enabled=true;
        }
        if (shouldReturn && !isGrabbed)
        {
            transform.localRotation = Quaternion.RotateTowards(
                transform.localRotation,
                startRotation,
                returnSpeed * Time.deltaTime
            );
            pullDown.Invoke();

            audioSouce.Play();

            }

        if (Quaternion.Angle(transform.localRotation, startRotation) < 0.1f)
        {
            shouldReturn = false;
        }
    }
}
