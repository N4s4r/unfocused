using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esmorzar_a_cegues : MonoBehaviour
{
    private GameObject Up, Down, Left, Right;
    private float h, l, x, y;

    // Start is called before the first frame update
    void Start()
    {
        Up = GameObject.Find("Up");
        Down = GameObject.Find("Down");
        Left = GameObject.Find("Left");
        Right = GameObject.Find("Right");
        h = 2; l = 2;
        x = -7f;
        y = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime * 10;
        if (Input.GetKey("up"))
        {
            y = Mathf.Min(5, y + delta);
        }
        if (Input.GetKey("down"))
        {
            y = Mathf.Max(-5 + h, y - delta);
        }
        if (Input.GetKey("left"))
        {
            x = Mathf.Max(-12, x - delta);
        }
        if (Input.GetKey("right"))
        {
            x = Mathf.Min(-l, x + delta);
        }
        if (Input.GetKeyDown("space"))
        {
            Debug.Log(x.ToString() + y.ToString());
        }

        Up.gameObject.transform.localScale = new Vector3(12, 10 - 2*y, 1);
        Down.gameObject.transform.localScale = new Vector3(12, 10 - 2 * (l - y), 1);
        Left.gameObject.transform.localScale = new Vector3(24 + 2 * x, 10, 1);
        Right.gameObject.transform.localScale = new Vector3(-2 * (x + l), 10, 1);
    }
}
