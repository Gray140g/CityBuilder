using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public bool testing;

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SlowDown()
    {
        Time.timeScale = .5f;
    }

    public void Play()
    {
        Time.timeScale = 1;
    }

    public void SpeedUp()
    {
        Time.timeScale = 2;
    }
}
