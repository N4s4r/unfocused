using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class esmorzar_a_cegues : MonoBehaviour
{
    private GameObject Up, Down, Left, Right, Poma, Tomaquet, tic_poma, tic_tomaquet;
    public TMP_Text timer;
    private float h, l, x, y;

    private string[] names = new string[] {"Poma", "Tomaquet", "Formatge"};
    private GameObject[] items = new GameObject[3];
    private GameObject[] ticks = new GameObject[3];

    private float Poma_left_boundry, Poma_right_boundry, Poma_down_boundry, Poma_up_boundry, Tomaquet_left_boundry, Tomaquet_right_boundry, Tomaquet_down_boundry, Tomaquet_up_boundry, xmouse, ymouse;
    private float v;
    private float time = 60;

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
        x = 3.5f;
        y = -3.5f;

        //Velocity
        v = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);
            timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        } 
        
        float delta = Time.deltaTime * v;
        // Movement
        if (Input.GetKey("w"))
        {
            y = Mathf.Min(0, y + delta);
        }
        if (Input.GetKey("s"))
        {
            y = Mathf.Max(-9 + h, y - delta);
        }
        if (Input.GetKey("a"))
        {
            x = Mathf.Max(0, x - delta);
        }
        if (Input.GetKey("d"))
        {
            x = Mathf.Min(9 - l, x + delta);
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

        Up.gameObject.transform.localScale = new Vector3(9, -2 * y, 1);
        Down.gameObject.transform.localScale = new Vector3(9, 18 + 2 * (y - h), 1);
        Left.gameObject.transform.localScale = new Vector3(2 * x, 9, 1);
        Right.gameObject.transform.localScale = new Vector3(18 - 2 * (x + l), 9, 1);
    }
}
