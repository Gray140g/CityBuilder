using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public bool testing;

    [SerializeField] private Image speedUpButton;
    [SerializeField] private Image slowDownButton;

    [SerializeField] private Color red;

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SlowDown()
    {
        Time.timeScale = .5f;
        slowDownButton.color = red;
        speedUpButton.color = Color.white;
    }

    public void Play()
    {
        Time.timeScale = 1;
        slowDownButton.color = Color.white;
        speedUpButton.color = Color.white;
    }

    public void SpeedUp()
    {
        Time.timeScale = 2;
        slowDownButton.color = Color.white;
        speedUpButton.color = red;
    }
}
