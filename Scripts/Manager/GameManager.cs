using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private PlayerController playerController;

    public bool isToggle = false;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance == this)
            {
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        playerController = CharacterManager.Instance.Player.GetComponent<PlayerController>();
        ToggleCursor();
    }

    public void ToggleCursor()
    {
        isToggle = !isToggle;
        if(isToggle )
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }
    }
}
