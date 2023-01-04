using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private TimeManager time;

    [SerializeField] private GameObject menu;

    private bool paused = false;

    public void PressPause(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            OpenOrClose();
        }
    }

    public void OpenOrClose()
    {
        if (paused)
        {
            menu.SetActive(false);
            time.Unpause();
            paused = false;
        }
        else
        {
            menu.SetActive(true);
            time.Pause();
            paused = true;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
