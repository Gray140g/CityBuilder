using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamMove : MonoBehaviour
{
    [SerializeField] private MenuOpener opener;

    [SerializeField] private Camera cam;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject camObject;

    private Vector3 moveVector;
    [SerializeField] private int speed;

    [SerializeField] private float zoomSpeed;
    [SerializeField] private float zoomPerFrame;
    private float zoomTowards = 0;
    private int needToZoom = 0;

    private Vector3 moveTowards;
    private bool needsToFollowBuilding = false;
    [SerializeField] private int step;

    [SerializeField] private int min;
    [SerializeField] private int max;

    private void Update()
    {
        if(needToZoom > 0 && zoomTowards < max)
        {
            zoomTowards += zoomPerFrame;
        }
        else if(needToZoom < 0 && zoomTowards > min)
        {
            zoomTowards -= zoomPerFrame;
        }
    }

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

        if (zoomTowards != 0)
        {
            if (cam.orthographicSize != zoomTowards)
            {
                if(zoomTowards > cam.orthographicSize && cam.orthographicSize < max)
                {
                    cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomTowards, zoomSpeed);
                }
                else if(zoomTowards < cam.orthographicSize && cam.orthographicSize > min)
                {
                    cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomTowards, zoomSpeed);
                }
            }
            else
            {
                zoomTowards = 0;
            }
        }
      
        if (needsToFollowBuilding && cam.transform.position != moveTowards)
        {
            //cam.transform.position = Vector3.MoveTowards(cam.transform.position, moveTowards, step * Time.unscaledDeltaTime);
            cam.transform.position = Vector3.Lerp(cam.transform.position, moveTowards, step * Time.unscaledDeltaTime);
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
            if(ctx.performed)
            {
                if (ctx.ReadValue<float>() > 0)
                {
                    if (cam.orthographicSize + .5f < max)
                    {
                        //cam.orthographicSize += .5f;
                        zoomTowards = cam.orthographicSize;
                        needToZoom = 1;
                    }
                }

                if (ctx.ReadValue<float>() < 0)
                {
                    if (cam.orthographicSize - .5f > min)
                    {
                        //cam.orthographicSize -= .5f;
                        zoomTowards = cam.orthographicSize;
                        needToZoom = -1;
                    }
                }
            }

            if(ctx.canceled)
            {
                zoomTowards = 0;
                needToZoom = 0;
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
