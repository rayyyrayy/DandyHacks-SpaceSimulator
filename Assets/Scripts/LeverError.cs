using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class LeverError : MonoBehaviour
{
    // Public Variables
    [Tooltip("The XRGrabInteractable component.")]
    public XRGrabInteractable grabInteractable;
    public float returnSpeed = 450f;
    public float thresholdAngle = 90f;
    public HingeJoint hinge;
    // public ChangeMaterialColor cc; // Assuming this is no longer needed since you handle material color here
    public AudioSource audioSouce;
    public UnityEvent pullDown;

    public UnityEvent startEvent;
    public UnityEvent midEvent;
    
    // Private State Variables
    private bool isGrabbed = false;
    private Quaternion startRotation;
    private Material myMaterial;
    private bool shouldReturn = false;
    private bool hasBeenPulled = false; // ⬅️ NEW FLAG
    private GameManager gameManager;
    private bool isEnabled = false; // To track if we've already enabled the lever
    public ParticleSystem flameParticle;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        if (grabInteractable == null)
            grabInteractable = GetComponent<XRGrabInteractable>();
        
        // 1. SAFELY GET AND INITIALIZE MATERIAL
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            myMaterial = renderer.material; 
            startEvent.Invoke();
        }
        
        startRotation = transform.localRotation;

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
        grabInteractable.enabled = false; // Start disabled
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
            grabInteractable.selectExited.RemoveListener(OnRelease);
        }
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
            // Use the HingeJoint's angle for accuracy
            currentAngle = Mathf.Abs(hinge.angle); 
        }
        else
        {
            // Fallback to Quaternion angle
            currentAngle = Quaternion.Angle(startRotation, transform.localRotation);
        }

        if (currentAngle >= thresholdAngle)
        {
            shouldReturn = true;      
            hasBeenPulled = true; // ⬅️ Set the flag when threshold is met
        }
        else
        {
            shouldReturn = false;
        }
    }

    private void Update()
    {
        // 2. CONDITION CHECK: Enable and color change only once
        if (gameManager.fixlever && !isEnabled)
        {
            grabInteractable.enabled = true;
            if (gameManager.fixlever==false)
            {
                midEvent.Invoke();
            }
            isEnabled = true;
        }

        // 3. AUTO RETURN LOGIC
        if (shouldReturn && !isGrabbed)
        {
            transform.localRotation = Quaternion.RotateTowards(
                transform.localRotation,
                startRotation,
                returnSpeed * Time.deltaTime
            );
            
            // 4. INVOKE ONCE: Check if the event needs to be triggered
            if (hasBeenPulled)
            {
                pullDown.Invoke();
                hasBeenPulled = false; // Reset after a single invocation
            }
        }
        
        // Stop the return process if the lever is back at start
        if (shouldReturn && Quaternion.Angle(transform.localRotation, startRotation) < 0.1f)
        {
            shouldReturn = false;
        }
    }

    // This method is called by the pullDown UnityEvent
    public void leverPulled()
    {
        audioSouce.Play();
        gameManager.leverErrorPulled = true;
        flameParticle.Play();
        gameManager.levererrorCaption.gameObject.SetActive(false);

    }
}