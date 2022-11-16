using System.Collections;
using UnityEngine;

public class BuildTime : MonoBehaviour
{
    [SerializeField] private Building parentBuilding;
    [SerializeField] private BuildClick click;
    [SerializeField] private Rotation rotation;
    [SerializeField] private Rotation outlineRotation;

    [SerializeField] private SpriteRenderer render;
    public SpriteRenderer outline;

    [SerializeField] private Sprite inProgressSprite;
    [SerializeField] private Sprite outlineInProgressSprite;

    public int totalTime;
    public int seconds;
    private int trueType;
    private int trueMax;
    
    public void OnPlace()
    {
        StartCoroutine("TimeTick");
        render.sprite = inProgressSprite;
        if(outline != null)
        {
            outline.sprite = outlineInProgressSprite;
        }
        trueType = click.type;
        click.type = 5;
        trueMax = click.maxVal;
        click.maxVal = totalTime;
        click.val = seconds;
        if (outline != null)
        {
            outline.gameObject.SetActive(false);
        }
    }

    private void FinishBuild()
    {
        parentBuilding.OnPlace();
        if(rotation != null)
        {
            rotation.ShowSprite();
        }
        if(outline != null)
        {
            outlineRotation.ShowSprite();
        }
        click.type = trueType;
        click.maxVal = trueMax;
        Destroy(this);
    }

    private IEnumerator TimeTick()
    {
        yield return new WaitForSeconds(1);
        seconds -= 1;
        click.TimeChange();

        if(seconds <= 0)
        {
            FinishBuild();
        }
        else
        {
            StartCoroutine("TimeTick");
        }
    }
}
