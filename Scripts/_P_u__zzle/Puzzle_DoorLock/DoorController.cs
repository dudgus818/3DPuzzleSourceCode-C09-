using System.Diagnostics;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform doorTransform;
    public float openAngle = 90f;
    public float doorSpeed = 2f;
    public bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    public GameObject doorObject;

    void Start()
    {
        closedRotation = doorTransform.rotation;
        openRotation = Quaternion.Euler(doorTransform.eulerAngles + new Vector3(0, openAngle, 0));
    }

    void Update()
    {
        if (isOpen)
        {
            doorTransform.rotation = Quaternion.Slerp(doorTransform.rotation, openRotation, Time.deltaTime * doorSpeed);
        }
        else
        {
            doorTransform.rotation = Quaternion.Slerp(doorTransform.rotation, closedRotation, Time.deltaTime * doorSpeed);
        }
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }


}
