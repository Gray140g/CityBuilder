using UnityEngine;
public class Materials : MonoBehaviour
{
    [SerializeField] private Population pop;
    [SerializeField] private LossText lossAnim;

    public int materials;
    public int hourlyMaterials;
    public float maxWorkers;
    public float workers;

    public void AddMaterials()
    {
        float gainFloat = (workers + 1) / (maxWorkers + 1) * hourlyMaterials;
        int gain = Mathf.RoundToInt(gainFloat);
        materials += gain;
        lossAnim.StartAnimation(gain, 3);
    }
}
