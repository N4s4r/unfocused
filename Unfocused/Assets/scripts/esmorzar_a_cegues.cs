using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public GameObject Up;

public class esmorzar_a_cegues : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Up.transform.scale() += Vector3(1,0,0);
    }
}
