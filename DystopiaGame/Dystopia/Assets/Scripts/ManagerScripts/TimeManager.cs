using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TimeManager : MonoBehaviour
{
    public void Reload(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
