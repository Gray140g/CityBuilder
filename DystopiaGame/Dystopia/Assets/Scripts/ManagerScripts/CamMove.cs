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
        rb.velocity = moveVector.normalized * speed * Time.fixedDeltaTime;
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        if(!opener.buildIsOpen)
        {
            moveVector = ctx.ReadValue<Vector2>();
        }
    }

    public void Zoom(InputAction.CallbackContext ctx)
    {
        if(ctx.ReadValue<float>() > 0)
        {
            if(cam.orthographicSize + .5f < max)
            {
                cam.orthographicSize  += .5f;
            }
        }

        if(ctx.ReadValue<float>() < 0)
        {
            if(cam.orthographicSize - .5f > min)
            {
                cam.orthographicSize -= .5f;
            }
        }
    }
}
