using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public static bool myBoolean;

    public void OnButtonPressed()
    {
        myBoolean = true;
        Debug.Log("PRESSED");
    }
}
