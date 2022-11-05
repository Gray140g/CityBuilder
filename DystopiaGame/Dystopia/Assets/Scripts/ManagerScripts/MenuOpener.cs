using UnityEngine;

public class MenuOpener : MonoBehaviour
{
    public bool buildIsOpen = false;
    public bool editIsOpen = false;

    public void CloseBuild()
    {
        buildIsOpen = false;
    }

    public void CloseEdit()
    {
        editIsOpen = false;
    }
}
