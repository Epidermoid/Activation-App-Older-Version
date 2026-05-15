// Source - https://stackoverflow.com/a/37906512
// Posted by Programmer, modified by community. See post 'Timeline' for change history
// Retrieved 2026-05-15, License - CC BY-SA 3.0

using UnityEngine;

public class SPRITEBUTTON : MonoBehaviour
{ 
    public ChangeLocation changeLocation;

    // This method will be called by the Button
    private void OnMouseDown()
    {
        Debug.Log("World Object Clicked!");

        changeLocation.SetRectTransformZero();

        // OR
        // changeLocation.SetRectTransformToGameValues();
    }

}
