using UnityEngine;

public class InputTest : MonoBehaviour
{
    private void Update()
    {
        if (InputManager.Instance == null)
        {
            Debug.LogWarning("InputManager íå ñîçäàí!");
            return;
        }

        Vector2 move = InputManager.Instance.MoveInput;
        Vector2 look = InputManager.Instance.LookInput;

        if (move != Vector2.zero)
            Debug.Log($"Move: {move}");

        if (look != Vector2.zero)
            Debug.Log($"Look: {look}");

        if (InputManager.Instance.JumpPressed)
            Debug.Log("Jump pressed!");

        if (InputManager.Instance.AttackPressed)
            Debug.Log("Attack pressed!");

        // Ñáðîñ ôëàãîâ
        InputManager.Instance.ResetButtonFlags();
    }
}