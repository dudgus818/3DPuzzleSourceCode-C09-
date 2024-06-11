using UnityEngine;

public class UiCondition : MonoBehaviour
{
    public Condition sprintStamina;

    void Start()
    {
        CharacterManager.Instance.Player.condition.uiCondition = this;
    }
}
