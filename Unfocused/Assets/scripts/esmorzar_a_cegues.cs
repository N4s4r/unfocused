using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esmorzar_a_cegues : MonoBehaviour
{
    private GameObject Up, Down, Left, Right, Poma, Tomaquet, tic_poma, tic_tomaquet;

    private float h, l, x, y;

    private string[] names = new string[] {"Poma", "Tomaquet", "Formatge"};
    private GameObject[] items = new GameObject[3];
    private GameObject[] ticks = new GameObject[3];

    private float Poma_left_boundry, Poma_right_boundry, Poma_down_boundry, Poma_up_boundry, Tomaquet_left_boundry, Tomaquet_right_boundry, Tomaquet_down_boundry, Tomaquet_up_boundry, xmouse, ymouse;
    private float v;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < names.Length; i++)
        {
            items[i] = GameObject.Find(names[i]);
            ticks[i] = GameObject.Find("tic_" + names[i]);
        }
        // Set every item to visible
        foreach(GameObject item in items)
        {
            item.SetActive(true);
        }
        // Set every tick to not visible
        foreach (GameObject tick in ticks)
        {
            tick.SetActive(false);
        }

        // Rectangles that reduces visibility
        Up = GameObject.Find("Up");
        Down = GameObject.Find("Down");
        Left = GameObject.Find("Left");
        Right = GameObject.Find("Right");

        // Passar a public
        h = 2; l = 2;
        x = -6f;
        y = 1;

        //Velocity
        v = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime * v;
        // Movement
        if (Input.GetKey("w"))
        {
            y = Mathf.Min(5, y + delta);
        }
        if (Input.GetKey("s"))
        {
            y = Mathf.Max(-5 + h, y - delta);
        }
        if (Input.GetKey("a"))
        {
            x = Mathf.Max(-10, x - delta);
        }
        if (Input.GetKey("d"))
        {
            x = Mathf.Min(-l, x + delta);
        }

        // Take object
        if (Input.GetMouseButtonDown(0))
        {
            xmouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            ymouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            if (x < xmouse && xmouse < x + l && y - h < ymouse && ymouse < y)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    GameObject go = items[i];
                    float dx = xmouse - go.transform.position.x;
                    float dy = ymouse - go.transform.position.y;
                    float d2 = dx * dx + dy * dy;
                    // Per calcular el contacte ho fem amb distancia euclidiana
                    if (d2 < 0.4)
                    {
                        Debug.Log(names[i] + " at " + xmouse.ToString() + " " + ymouse.ToString());
                        go.SetActive(false);
                        ticks[i].SetActive(true);
                    }
                }
            }
        }

        Up.gameObject.transform.localScale = new Vector3(10, 10 - 2*y, 1);
        Down.gameObject.transform.localScale = new Vector3(10, 10 + 2 * (y - h), 1);
        Left.gameObject.transform.localScale = new Vector3(20 + 2 * x, 10, 1);
        Right.gameObject.transform.localScale = new Vector3(-2 * (x + l), 10, 1);
        timer += Time.deltaTime;
    }
}
