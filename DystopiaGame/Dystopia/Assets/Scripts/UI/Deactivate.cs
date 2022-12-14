using System.Collections;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    [SerializeField] float waitTime;

    public IEnumerator Inactivate()
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }
}
