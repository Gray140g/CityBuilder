using UnityEngine;
using UnityEngine.InputSystem;

public class CamMove : MonoBehaviour
{
    [SerializeField] private MenuOpener opener;

    [SerializeField] private Camera cam;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject camObject;

    private Vector2 moveVector;
    [SerializeField] private int speed;

    [SerializeField] private int min;
    [SerializeField] private int max;

    private void FixedUpdate()
    {
        if(!opener.buildIsOpen && !opener.commandIsOpen)
        {
            rb.velocity = moveVector.normalized * speed * Time.fixedDeltaTime;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        moveVector = ctx.ReadValue<Vector2>();
    }

    public void Zoom(InputAction.CallbackContext ctx)
    {
        if(!opener.buildIsOpen && !opener.commandIsOpen)
        {
            if (ctx.ReadValue<float>() > 0)
            {
                if (cam.orthographicSize + .5f < max)
                {
                    cam.orthographicSize += .5f;
                }
            }

            if (ctx.ReadValue<float>() < 0)
            {
                if (cam.orthographicSize - .5f > min)
                {
                    cam.orthographicSize -= .5f;
                }
            }
        }
    }
}
