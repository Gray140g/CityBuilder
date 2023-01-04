using UnityEngine;

public class ColliderRotate : MonoBehaviour
{
    [SerializeField] private Building parentBuilding;
    [SerializeField] private Rotation rotation;
    [SerializeField] private Collider2D[] colliders;
    public int i;

    void Update()
    {
        if (parentBuilding.beingPlaced)
        {
            if (parentBuilding.colliderRotate)
            {
                if (i != 3)
                {
                    i++;
                    parentBuilding.colliderRotate = false;
                    colliders[i].enabled = true;

                    if (i != 0)
                    {
                        colliders[i - 1].enabled = false;
                    }
                    else
                    {
                        colliders[3].enabled = false;
                    }
                }
                else
                {
                    i = 0;
                    parentBuilding.colliderRotate = false;
                    colliders[i].enabled = true;
                    colliders[i - 1].enabled = false;
                }
            }
        }
    }

    public void ShowCollider()
    {
        i = rotation.i;

        for (int j = 0; j < colliders.Length; j++)
        {
            if(j == i)
            {
                colliders[j].enabled = true;
            }
            else
            {
                colliders[j].enabled = false;
            }
        }
    }
}
