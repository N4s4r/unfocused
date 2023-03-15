using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;


public class esmorzar_a_cegues : MonoBehaviour
{
    public TMP_Text definicio, data;
    private GameObject Up, Down, Left, Right, Poma, Tomaquet, tic_poma, tic_tomaquet;
    public TMP_Text timer;
    private float h, l, x, y;

    private GameObject[] itemsDay1 = new GameObject[20];
    private GameObject[] itemsDay2 = new GameObject[21];
    private GameObject[] itemsDay3 = new GameObject[21];

    private string[] namesDay1 = new string[20] {"formatge", "poma", "tomaquet", "cupcake", "pizza", "pastis", "galeta", "llet", "coco", "pernil", "baco", "aigua", "vodka", "taronja", "churros", "nap", "nacho", "iogurt", "nabiu", "pases"};
    private string[] namesDay2 = new string[21] {"pa", "magdalena", "croissant", "mantega_cacahuet", "mantega", "margarina", "mermelada", "llet_2", "formatge_2", "champinyons", "coliflor", "pera", "blat", "cocombre", "patata", "alberginia", "carbassa", "kiwi", "ou", "platan", "llenties"};
    private string[] namesDay3 = new string[21] {"croissant_2", "galeta_2", "magdalena_2", "pastis_2", "pa_2", "donut", "gelat", "batut_xocolata", "xocolata", "patata_2", "kiwi_2", "ou_2", "nou", "trufa", "datils", "taronja_2", "olives", "coco_2", "pollastre", "baco_2", "vodka_2"};

    private string[] correct_name_day_1 = new string[5] {"poma", "taronja", "coco", "formatge", "aigua"};
    private string[] correct_name_day_2 = new string[6] {"pa", "mantega", "mermelada", "llet_2", "pera", "platan"};
    private string[] correct_name_day_3 = new string[7] {"pastis_2", "magdalena_2", "batut_xocolata", "donut", "xocolata", "croissant_2", "vodka_2"};

    private GameObject[] ticks_day_1 = new GameObject[5];
    private GameObject[] ticks_day_2 = new GameObject[6];
    private GameObject[] ticks_day_3 = new GameObject[7];

    private string definitionsDay1 = "Poma \r\n \r\nTaronja \r\n \r\nCoco \r\n \r\nFormatge \r\n \r\nAigua";
    private string definitionsDay2 = "Pa \r\n \r\nMantega \r\n \r\nMermelada \r\n \r\nLlet \r\n \r\nPera \r\n \r\nPlatan";
    private string definitionsDay3 = "Pastis \r\n \r\nMagdalena \r\n \r\nBatut_xocolata \r\n \r\nDonut \r\n \r\nXocolata \r\n \r\nCroissant \r\n \r\nVodka";

    private float v;
    public static float time = 60;
    public static int num_correct = 0, num_aliments = 100;
    private float xmouse, ymouse;

    private int day;

    // Start is called before the first frame update
    void Start()
    {
        day = play.level;
        data.text = "19/06/2" + day.ToString();
        for (int i = 0; i < namesDay1.Length; i++)
        {
            itemsDay1[i] = GameObject.Find(namesDay1[i]);
        }

        for(int i = 0; i < correct_name_day_1.Length; i++) {
            ticks_day_1[i] = GameObject.Find("tic_" + correct_name_day_1[i]);
        }

        for(int i = 0; i < namesDay2.Length; i++)
        {
            itemsDay2[i] = GameObject.Find(namesDay2[i]);
        }

        for(int i = 0; i < correct_name_day_2.Length; i++) {
            ticks_day_2[i] = GameObject.Find("tic_" + correct_name_day_2[i]);
        }

        for(int i = 0; i < namesDay3.Length; i++)
        {
            itemsDay3[i] = GameObject.Find(namesDay3[i]);
        }

        for(int i = 0; i < correct_name_day_3.Length; i++) {
            ticks_day_3[i] = GameObject.Find("tic_" + correct_name_day_3[i]);
        }
        
        // Rectangles that reduces visibility
        Up = GameObject.Find("Up");
        Down = GameObject.Find("Down");
        Left = GameObject.Find("Left");
        Right = GameObject.Find("Right");

        // Passar a public
        x = 3.5f;
        y = -3.5f;

        //Velocity
        v = 5.0f;

        // Set every tick to not visible
        foreach (GameObject tick in ticks_day_1)
        {
            tick.SetActive(false);
        }

        foreach (GameObject tick in ticks_day_2)
        {
            tick.SetActive(false);
        }

        foreach (GameObject tick in ticks_day_3)
        {
            tick.SetActive(false);
        }

        if (day == 1) {
            h = 2; l = 2;
            num_aliments = correct_name_day_1.Length;
            definicio.text = definitionsDay1;

            // Set every item to visible
            foreach(GameObject item in itemsDay1)
            {
                item.SetActive(true);
            }

            foreach(GameObject item in itemsDay2)
            {
                item.SetActive(false);
            }

            foreach(GameObject item in itemsDay3)
            {
                item.SetActive(false);
            }
        } else if (day == 2) {
            h = 1; l = 1;
            num_aliments = correct_name_day_2.Length;
            definicio.text = definitionsDay2;

            // Set every item to visible
            foreach(GameObject item in itemsDay2)
            {
                item.SetActive(true);
            }

            foreach(GameObject item in itemsDay1)
            {
                item.SetActive(false);
            }

            foreach(GameObject item in itemsDay3)
            {
                item.SetActive(false);
            }
        } else {
            h = 0.5f; l = 0.5f;
            num_aliments = correct_name_day_3.Length;
            definicio.text = definitionsDay3;

            // Set every item to visible
            foreach(GameObject item in itemsDay3)
            {
                item.SetActive(true);
            }

            foreach(GameObject item in itemsDay2)
            {
                item.SetActive(false);
            }

            foreach(GameObject item in itemsDay1)
            {
                item.SetActive(false);
            }
        }
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

        if (day == 1) {
            xmouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            ymouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

            if (Input.GetMouseButtonDown(0) && (x < xmouse + 127.2f && xmouse + 127.0f < x + l && y - h < ymouse + 71.5f && ymouse + 71.0f < y))
            {                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {

                    Debug.Log(hit.transform.gameObject.name);

                    
                    if(correct_name_day_1.Contains(hit.transform.gameObject.name))
                    {

                        for (int i = 0; i < namesDay1.Length; i++) {
                            if (namesDay1[i] == hit.transform.gameObject.name) {
                                itemsDay1[i].SetActive(false);
                            }
                        }

                        for (int i = 0; i < correct_name_day_1.Length; i++) {
                            if (correct_name_day_1[i] == hit.transform.gameObject.name) {
                                ticks_day_1[i].SetActive(true);
                            }
                        }
                        num_correct += 1;
                        Debug.Log("correct");
                    }

                    else {
                        time -= 5;
                        float minutes = Mathf.FloorToInt(time / 60);
                        float seconds = Mathf.FloorToInt(time % 60);
                        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                        Debug.Log("error");
                    }                   
                }
            }
        }

        else if (day == 2) {
            xmouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            ymouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

            if (Input.GetMouseButtonDown(0) && (x < xmouse + 127.2f && xmouse + 127.0f < x + l && y - h < ymouse + 71.5f && ymouse + 71.0f < y))
            {                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {

                    Debug.Log(hit.transform.gameObject.name);

                    
                    if(correct_name_day_2.Contains(hit.transform.gameObject.name))
                    {

                        for (int i = 0; i < namesDay2.Length; i++) {
                            if (namesDay2[i] == hit.transform.gameObject.name) {
                                itemsDay2[i].SetActive(false);
                            }
                        }

                        for (int i = 0; i < correct_name_day_2.Length; i++) {
                            if (correct_name_day_2[i] == hit.transform.gameObject.name) {
                                ticks_day_2[i].SetActive(true);
                            }
                        }
                        num_correct += 1;
                        Debug.Log("correct");
                    }

                    else {
                        time -= 5;
                        float minutes = Mathf.FloorToInt(time / 60);
                        float seconds = Mathf.FloorToInt(time % 60);
                        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                        Debug.Log("error");
                    }                   
                }
            }
        }

        else {
            xmouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            ymouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

            if (Input.GetMouseButtonDown(0) && (x < xmouse + 127.2f && xmouse + 127.0f < x + l && y - h < ymouse + 71.5f && ymouse + 71.0f < y))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {

                    Debug.Log(hit.transform.gameObject.name);

                    
                    if(correct_name_day_3.Contains(hit.transform.gameObject.name))
                    {

                        for (int i = 0; i < namesDay3.Length; i++) {
                            if (namesDay3[i] == hit.transform.gameObject.name) {
                                itemsDay3[i].SetActive(false);
                            }
                        }

                        for (int i = 0; i < correct_name_day_3.Length; i++) {
                            if (correct_name_day_3[i] == hit.transform.gameObject.name) {
                                ticks_day_3[i].SetActive(true);
                            }
                        }
                        num_correct += 1;
                        Debug.Log("correct");
                    }

                    else {
                        time -= 5;
                        float minutes = Mathf.FloorToInt(time / 60);
                        float seconds = Mathf.FloorToInt(time % 60);
                        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                        Debug.Log("error");
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
