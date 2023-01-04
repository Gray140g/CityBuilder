using UnityEngine;
using UnityEngine.InputSystem;

public class CursorMove : MonoBehaviour
{
    [SerializeField] private GameObject cursor;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;

    [SerializeField] private PlayerInput inp;

    [SerializeField] private Vector2 offSet;

    private Vector2 moveVector;
    [SerializeField] private int speed;

    private void Update()
    {
        if(inp.currentControlScheme != "Gamepad")
        {
            cursor.GetComponent<RectTransform>().position = Mouse.current.position.ReadValue() + offSet;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector.normalized * speed * Time.fixedDeltaTime;
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        moveVector = ctx.ReadValue<Vector2>();
    }
}
