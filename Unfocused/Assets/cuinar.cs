using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cuinar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject text;
    void Start()
    {
        text.gameObject.GetComponent<TextMesh>().text = "Arrel comestible, generalment de color taronja";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
