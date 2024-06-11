using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    [Header("InteractableObject")]
    public InteractableObject currentInteractable;

    public TextMeshProUGUI promptText;
    public GameObject interactableKey;
    private PlayerController playerController;
    private Camera camera;

    void Start()
    {
        camera = Camera.main;
        playerController = CharacterManager.Instance.Player.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            Debug.DrawRay(ray.origin, ray.direction * maxCheckDistance, UnityEngine.Color.red, checkRate);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance))
            {
                if (hit.collider.CompareTag("InteractableObject"))
                {
                    if (hit.collider.gameObject != currentInteractable)
                    {
                        SetInteractableKey();
                        currentInteractable = hit.collider.GetComponent<InteractableObject>();
                    }
                }
            }
            else
            {
                currentInteractable = null;
                interactableKey.gameObject.SetActive(false);
            }
        }
    }

    private void SetInteractableKey()
    {
        interactableKey.gameObject.SetActive(true);
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && currentInteractable != null)
        {
            currentInteractable.Interact();
            currentInteractable = null;
            GameManager.instance.ToggleCursor();
            interactableKey.gameObject.SetActive(false);

            AudioManager audioManager = FindAnyObjectByType<AudioManager>();
            if (audioManager != null)
            {
                audioManager.PlayInventorySound();
            }
        }
    }
}
