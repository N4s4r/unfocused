using UnityEngine;
using UnityEngine.UI;

public class ButtonControlPlay : MonoBehaviour
{
    public static bool myBoolean = false;

    public void OnButtonPressed()
    {
        myBoolean = true;
        Debug.Log("PRESSED");
    }
}
