using UnityEngine;
using UnityEngine.EventSystems;

public class MobileMovementButton : MonoBehaviour,
    IPointerDownHandler, IPointerUpHandler,
    IPointerExitHandler
{
    public PlayerMovement player;
    public float direction;

    public void OnPointerDown(PointerEventData eventData)
    {
        player.SetMoveInput(direction);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.SetMoveInput(0f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        player.SetMoveInput(0f);
    }
}
