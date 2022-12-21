using UnityEngine;
using System.Collections;

public class Materials : MonoBehaviour
{
    [SerializeField] private Population pop;
    [SerializeField] private LossText lossAnim;

    public int materials;
    public int dailyMaterials;
    public float maxWorkers;
    public float workers;

    public void AddMaterials()
    {
        float gainFloat = (workers + 1) / (maxWorkers + 1) * dailyMaterials / 24 + .5f;
        int gain = Mathf.RoundToInt(gainFloat);
        materials += gain;
        lossAnim.StartAnimation(gain, 3);
    }
}
