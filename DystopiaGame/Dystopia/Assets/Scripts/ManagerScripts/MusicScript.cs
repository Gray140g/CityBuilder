using System.Collections;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip[] songs;

    [SerializeField] int time;

    void Start()
    {
        PlayRandom();
    }

    private void PlayRandom()
    {
        if(!source.isPlaying)
        {
            if(songs.Length > 0)
            {
                int i = Random.Range(0, songs.Length - 1);
                source.clip = songs[i];
            }
            source.Play();
            StartCoroutine("WaitForNextSong");
        }
    }

    private IEnumerator WaitForNextSong()
    {
        yield return new WaitForSeconds(time);
        PlayRandom();
    }
}
