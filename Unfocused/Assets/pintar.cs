using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pintar : MonoBehaviour
{
    private GameObject Wheel, current;
    public GameObject Triangle, Cercle, Quadrat, Hexagon, Diamant, Gnomo, Perrito, Gatito;
    public int level;
    private GameObject[] figures = new GameObject[5];
    private GameObject[] prefabs = new GameObject[5];
    private float xwheel, ywheel, xmouse, ymouse, xfigure, yfigure, current_depth;
    private Color color;
    private bool drawing;

    // Start is called before the first frame update
    void Start()
    {
        figures[0] = GameObject.Find("Triangle");
        figures[1] = GameObject.Find("Circle");
        figures[2] = GameObject.Find("Square");
        figures[3] = GameObject.Find("Hexagon");
        figures[4] = GameObject.Find("Isometric Diamond");

        prefabs[0] = Triangle;
        prefabs[1] = Cercle;
        prefabs[2] = Quadrat;
        prefabs[3] = Hexagon;
        prefabs[4] = Diamant;
        Wheel = GameObject.Find("color wheel");
        xwheel = Wheel.transform.position.x;
        ywheel = Wheel.transform.position.y;
        drawing = false;
        current_depth = 0;
        if (level == 1)
        {
            Gnomo.SetActive(false);
            Perrito.SetActive(false);

        }
        if(level == 2)
        {
            Gatito.SetActive(false);
            Perrito.SetActive(false);
        }
        if (level == 3)
        {
            Gnomo.SetActive(false);
            Gatito.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.GetKey(KeyCode.E) && drawing)
            {
                current.transform.Rotate(0,0,-100*Time.deltaTime,Space.Self);
            }
            if (Input.GetKey(KeyCode.Q) && drawing)
            {
                current.transform.Rotate(0, 0, 100 * Time.deltaTime, Space.Self);
            }
            if (Input.mouseScrollDelta.y != 0)
            {
                current.gameObject.transform.localScale = current.transform.localScale * Mathf.Pow(1.1f, Input.mouseScrollDelta.y);
            }

            xmouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            ymouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

            //Change color
            if (xwheel -1f < xmouse && xmouse < xwheel + 1f && ywheel - 1f < ymouse && ymouse < ywheel +1f)
            {
                if (xwheel - 0.1f < xmouse && xmouse < xwheel + 0.1f && ywheel - 1f < ymouse && ymouse < ywheel)
                {
                    color = new Color(0.60000f, 0.00000f, 0.80000f);//Color(0.643f, 0.129f, 0.920f); //Lila
                }   
                if (xwheel - 0.1f < xmouse && xmouse < xwheel + 0.1f && ywheel < ymouse && ymouse < ywheel + 1f)
                {
                    color = new Color(255/255, 255/255, 0/255);
                }
                if (xwheel - 1f < xmouse && xmouse < xwheel && ywheel - 0.1f < ymouse && ymouse < ywheel + 0.1f)
                {
                    color = new Color(0.20000f, 0.60000f, 1.00000f);//Color(51/255, 51/255, 255/255); //blau
                }
                if (xwheel < xmouse && xmouse < xwheel + 1f && ywheel-0.1f < ymouse && ymouse < ywheel + 0.1f)
                {
                    color = new Color(0.10000f, 0.00000f, 0.0000f); // Color(255/255, 51/255, 51/255); //Vermell
                }

                for (int i = 0; i < figures.Length; i++)
                {
                    figures[i].GetComponent<Renderer>().material.color = color;
                }
            }
            //Afegir figura
            for (int i = 0; i < figures.Length; i++)
            {
                xfigure = figures[i].transform.position.x;
                yfigure = figures[i].transform.position.y;
                if (xfigure - 1f < xmouse && xmouse < xfigure + 1f && yfigure - 1f < ymouse && ymouse < yfigure + 1f && !drawing)
                {
                    drawing = true;
                    Debug.Log("TTRIngle");
                    GameObject b = Instantiate(prefabs[i], Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                    b.GetComponent<Renderer>().material.color = color;
                    current_depth += 0.00001f;
                    //b.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(0f, 2f, -3f); ;
                    current = b;
                }

            }
            if (drawing && Camera.main.ScreenToWorldPoint(Input.mousePosition).x >0 && Camera.main.ScreenToWorldPoint(Input.mousePosition).y < 2.98)
            {
                current.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 3f - current_depth );
            }
        }
        else
        {
            drawing = false;
        }
        
    }
}
