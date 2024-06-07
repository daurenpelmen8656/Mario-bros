using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public PlayerMovement playerMovement; // —сылка на скрипт PlayerMovement

    public void OnLeftButtonDown()
    {
        playerMovement.MoveLeft();
    }

    public void OnLeftButtonUp()
    {
        playerMovement.StopMoving();
    }

    public void OnRightButtonDown()
    {
        playerMovement.MoveRight();
    }

    public void OnRightButtonUp()
    {
        playerMovement.StopMoving();
    }

    public void OnJumpButtonDown()
    {
        playerMovement.Jump();
    }
}
