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

    private Vector3 moveTowards;
    private bool needsToFollowBuilding = false;
    [SerializeField] private int step;

    [SerializeField] private int min;
    [SerializeField] private int max;

    private void FixedUpdate()
    {
        if(!opener.buildIsOpen && !opener.commandIsOpen)
        {
            if(!needsToFollowBuilding)
            {
                rb.velocity = moveVector.normalized * speed * Time.unscaledDeltaTime;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if(needsToFollowBuilding && cam.transform.position != moveTowards)
        {
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, moveTowards, step * Time.unscaledDeltaTime);
        }
        else
        {
            needsToFollowBuilding = false;
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

    public void MoveToBuilding(Vector3 buildingPos)
    {
        moveTowards = buildingPos;
        moveTowards.z = -10;
        needsToFollowBuilding = true;
    }
}
