using UnityEngine;

public readonly struct InputData
{
    public readonly float HorizontalMovement;
    public readonly bool Jump;

    public InputData(float horizontalMovement, bool jump)
    {
        Jump = jump;
        HorizontalMovement = Mathf.Clamp(horizontalMovement, -1f, 1f);
    }
}