using UnityEngine;

[CreateAssetMenu(fileName = "InputSystem", menuName = "ScriptableObjects/InputSystem")]
public class InputSystem : ScriptableObject
{
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Jump;

    public KeyCode Arm;
    public KeyCode Leg;

    public string VerticalAxis;
    public string HorizontalAxis;
}
