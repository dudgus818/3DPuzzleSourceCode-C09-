using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject interactPuzzleUI;

    private void OnTriggerExit(Collider other)
    {
        if (interactPuzzleUI != null)
        {
            interactPuzzleUI.SetActive(false);
        }
    }

    public void Interact()
    {
        if(isPuzzleOpen())
        {
            interactPuzzleUI.SetActive(false);
        }
        else
        {
            interactPuzzleUI.SetActive(true);
        }
    }

    public bool isPuzzleOpen()
    {
        return interactPuzzleUI.activeInHierarchy;
    }
}
