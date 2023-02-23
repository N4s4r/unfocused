using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esmorzar_a_cegues : MonoBehaviour
{
    private GameObject Up, Down, Left, Right, Poma, Tomaquet, tic_poma, tic_tomaquet;
    private float h, l, x, y, Poma_left_boundry, Poma_right_boundry, Poma_down_boundry, Poma_up_boundry, Tomaquet_left_boundry, Tomaquet_right_boundry, Tomaquet_down_boundry, Tomaquet_up_boundry, xmouse, ymouse;

    // Start is called before the first frame update
    void Start()
    {
        Up = GameObject.Find("Up");
        Down = GameObject.Find("Down");
        Left = GameObject.Find("Left");
        Right = GameObject.Find("Right");
        Poma = GameObject.Find("Poma");
        Tomaquet = GameObject.Find("Tomaquet");
        tic_poma = GameObject.Find("tic_poma");
        tic_tomaquet = GameObject.Find("tic_tomaquet");
        Poma_right_boundry = Poma.transform.position.x + 1f;
        Poma_left_boundry = Poma.transform.position.x - 1f;
        Poma_up_boundry = Poma.transform.position.y + 1f;
        Poma_down_boundry = Poma.transform.position.y - 1f;
        Tomaquet_right_boundry = Tomaquet.transform.position.x + 1f;
        Tomaquet_left_boundry = Tomaquet.transform.position.x - 1f;
        Tomaquet_up_boundry = Tomaquet.transform.position.y + 1f;
        Tomaquet_down_boundry = Tomaquet.transform.position.y - 1f;
        tic_poma.SetActive(false);
        tic_tomaquet.SetActive(false);
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
        if (Input.GetMouseButtonDown(0))
        {
            xmouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            ymouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            if (xmouse < Tomaquet_right_boundry && xmouse > Tomaquet_left_boundry && Tomaquet_down_boundry < ymouse && ymouse < Tomaquet_up_boundry)
            {
                Debug.Log(x.ToString() + y.ToString());
                Debug.Log("Tomaquet");
                Tomaquet.SetActive(false);
                tic_tomaquet.SetActive(true);
            }
            if (xmouse < Poma_right_boundry && xmouse > Poma_left_boundry && Poma_down_boundry < ymouse && ymouse < Poma_up_boundry)
            {
                Debug.Log(x.ToString() + y.ToString());
                Debug.Log("POMAAAA");
                Poma.SetActive(false);
                tic_poma.SetActive(true);
            }
        }
        Up.gameObject.transform.localScale = new Vector3(12, 10 - 2*y, 1);
        Down.gameObject.transform.localScale = new Vector3(12, 10 - 2 * (l - y), 1);
        Left.gameObject.transform.localScale = new Vector3(24 + 2 * x, 10, 1);
        Right.gameObject.transform.localScale = new Vector3(-2 * (x + l), 10, 1);
    }
}
