using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poma : MonoBehaviour
{
    private GameObject circle;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    // Update is called once per frame
    public GameObject selectedObject;
    void Update()
    {
        //transform.position = Input.mousePosition;
        /*if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject;
            }
        }*/
    }
}
