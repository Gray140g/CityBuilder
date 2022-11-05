using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private Building parentBuilding;
    [SerializeField] private SpriteRenderer render;
    [SerializeField] private Sprite[] sprites;
    private int i;

    private void Update()
    {
        if (parentBuilding.beingPlaced)
        {
            if(parentBuilding.rotate)
            {
                if (i != 3)
                {
                    i++;
                    parentBuilding.rotate = false;
                    render.sprite = sprites[i];
                }
                else
                {
                    i = 0;
                    parentBuilding.rotate = false;
                    render.sprite = sprites[i];
                }
            }
        }
    }
}
