using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public bool testing;

    [SerializeField] private Image speedUpButton;
    [SerializeField] private Image slowDownButton;

    [SerializeField] private Color red;

    private float currentTimeScale = 1;

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SlowDown()
    {
        Time.timeScale = .5f;
        currentTimeScale = .5f;
        slowDownButton.color = red;
        speedUpButton.color = Color.white;
    }

    public void Play()
    {
        Time.timeScale = 1;
        currentTimeScale = 1;
        slowDownButton.color = Color.white;
        speedUpButton.color = Color.white;
    }

    public void SpeedUp()
    {
        Time.timeScale = 2;
        currentTimeScale = 2;
        slowDownButton.color = Color.white;
        speedUpButton.color = red;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        Time.timeScale = currentTimeScale;
    }
}
