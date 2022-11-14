using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private Building parentBuilding;
    [SerializeField] private SpriteRenderer render;
    [SerializeField] private Sprite[] sprites;
    private int i;
    [SerializeField] private bool isOutline = false;

    private void Update()
    {
        if (parentBuilding.beingPlaced)
        {
            if(!isOutline)
            {
                if (parentBuilding.rotate)
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
            else
            {
                if (parentBuilding.outLineRotate)
                {
                    if (i != 3)
                    {
                        i++;
                        parentBuilding.outLineRotate = false;
                        render.sprite = sprites[i];
                    }
                    else
                    {
                        i = 0;
                        parentBuilding.outLineRotate = false;
                        render.sprite = sprites[i];
                    }
                }
            }
        }
    }

    public void ShowSprite()
    {
        render.sprite = sprites[i];
    }
}
