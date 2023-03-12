using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dinar : MonoBehaviour
{
    public TMP_Text definicio; 
    private int day;
    private GameObject[,] itemsDay1 = new GameObject[4,5];
    private GameObject[,] itemsDay2 = new GameObject[5,6];
    private GameObject[,] itemsDay3 = new GameObject[6,7];

    private GameObject bombolles_vermelles;
    private GameObject bombolles_blaves;

    //public static float time=60f;
    //public TMP_Text timer;

    public GameObject scoreSystem;
    //private GameObject[] itemsDay2 = new GameObject[6][6];
    //private GameObject[] itemsDay3 = new GameObject[7][7];

    private int id;

    public int points = 0;

    private string[,] namesDay1 = new string[4,5] {{"croissant", "galeta", "magdalena", "pa", "pastis"}, {"mantega", "mantega_cacahuet", "margarina", "mermelada", "requeson"}, {"champinyons", "coco", "coliflor", "formatge", "llet"}, {"baco", "bistec", "pernil", "pollastre", "saltxitxa"}};
    private string[,] namesDay2 = new string[5,6] {{"api", "cols_bruseles", "esparrecs", "mongetes", "pebrot", "pessols"}, {"all", "ceba", "ceba_tendra", "pa_all", "pastinaca", "rave"}, {"alvocat", "brocoli", "ceba_2", "ceba_tendra_2", "cogombre", "porro"}, {"baco_2", "bistec_2", "costella", "pernil_2", "pollastre_2", "saltxitxa_2"}, {"aigua", "caldo", "oli", "sirope", "vinagre", "vodka"}};
    private string[,] namesDay3 = new string[6,7] {{"churros", "nacho", "nap", "pebrot_2", "taronja", "pastanaga", "boniato"}, {"caviar", "datils", "kiwi", "nou", "ou", "pistatxo", "trufa"}, {"alioli", "beixamel", "crema_formatge", "iogurt", "ketchup", "maionesa", "nata"}, {"cireres", "datils_2", "nabiu", "olives", "pases", "prunes", "raim"}, {"caviar_2", "faves_2", "llenties", "mongetes_2", "pebrot_3", "pessols_2", "quinoa"}, {"alberginia", "blat", "carbassó", "carbassa", "cocombre", "patata", "pera"}};

    private string[] correct_name_day1 = new string[4] {"pa", "mantega", "formatge", "pernil"};
    private string[] correct_name_day2 = new string[5] {"api", "all", "porro", "pollastre_2", "aigua"};
    private string[] correct_name_day3 = new string[6] {"pastanaga", "ou", "maionesa", "olives", "pessols_2", "patata"};

    private string[] definitionsDay1 = new string[4] {"Aliment fornejat que pot tenir moltes formes i mides diferents però normalment és de color marró o daurat amb una lleugera escorça", "Substància sòlida i de color groc cremós que es presenta en un bloc rectangular o un pal rodó i té una superfície llisa i lleugerament brillant", "Aliment sòlid o semisòlid generalment amb una superfície llisa o lleugerament texturada i una gamma de colors segons el tipus. Normalment és de color blanc", "Carn de forma oblonga de color rosa o vermellós amb una superfície lleugerament brillant i petites bosses de greix a tot arreu"};
    private string[] definitionsDay2 = new string[5] {"Verdura cruixent i verda amb tiges llargues i primes i part superior de full. Té una textura fibrosa i un gust lleugerament amarg", "Hortalissa bulbosa amb una pell paperera i blanca i un aroma picant. Solen ser petits i tenen una textura ferma i lleugerament gomosa", "Verdures llargues i primes de forma cilíndrica i de color verd i blanc pàl·lid. Tenen una textura lleugerament gomosa i s’utilitzen sovint com a aromatitzant", "Carn amb una pell de color clar i lleugerament rugosa. Té una textura tendra i sucosa quan es cuina", "Líquid clar i incolor amb un aspecte suau i com de vidre"};
    private string[] definitionsDay3 = new string[6] {"Hortalissa d’arrel llarga i afilada amb un color taronja brillant i una textura lleugerament rugosa a l’exterior", "Objecte petit i fràgil de forma ovalada amb una closa llisa i brillant que pot variar de color des del blanc fins al marró", "Salsa blanca i cremosa que té un aspecte llis i brillant", "Fruits petits de forma ovalada que solen ser de color negre o verd. Tenen una pell llisa i brillant i una textura ferma", "Petits, rodons i de color verd. Tenen una pell llisa i una textura lleugerament ferma", "Hortalissa de forma ovalada o oblonga amb una pell llisa i lleugerament accidentada. El color de la pell pot variar des del marró fins al grog"};
    // Start is called before the first frame update
    void Start()
    {
        bombolles_blaves = GameObject.Find("bombolles_blaves");
        bombolles_vermelles = GameObject.Find("bombolles_vermelles");

        bombolles_blaves.SetActive(false);
        bombolles_vermelles.SetActive(false);

        id = 0;
        day = 3;

        for(int i = 0; i < namesDay1.GetLength(0); i++)
        {
            for(int j = 0; j < namesDay1.GetLength(1); j++) {
                itemsDay1[i,j] = GameObject.Find(namesDay1[i,j]);
            }
        }
        for(int i = 0; i < namesDay2.GetLength(0); i++)
        {
            for(int j = 0; j < namesDay2.GetLength(1); j++) {
                itemsDay2[i,j] = GameObject.Find(namesDay2[i,j]);
            }
        }
        for(int i = 0; i < namesDay3.GetLength(0); i++)
        {
            for(int j = 0; j < namesDay3.GetLength(1); j++) {
                itemsDay3[i,j] = GameObject.Find(namesDay3[i,j]);
            }
        }
        
        if (day == 1) {
            definicio.text = definitionsDay1[0];

            for(int i = 0; i < itemsDay1.GetLength(0); i++)
            {
                for(int j = 0; j < itemsDay1.GetLength(1); j++) {
                    if (i == 0) {
                        itemsDay1[i, j].SetActive(true);
                    } else {
                        itemsDay1[i, j].SetActive(false);
                    }
                }
            }
            for(int i = 0; i < itemsDay2.GetLength(0); i++)
            {
                for(int j = 0; j < itemsDay2.GetLength(1); j++) {
                    itemsDay2[i, j].SetActive(false);
                }
            }
            for(int i = 0; i < itemsDay3.GetLength(0); i++)
            {
                for(int j = 0; j < itemsDay3.GetLength(1); j++) {
                    itemsDay3[i, j].SetActive(false);
                }
            }
        }
        else if (day == 2) {
            definicio.text = definitionsDay2[0];

            for(int i = 0; i < itemsDay2.GetLength(0); i++)
            {
                for(int j = 0; j < itemsDay2.GetLength(1); j++) {
                    if (i == 0) {
                        itemsDay2[i, j].SetActive(true);
                    } else {
                        itemsDay2[i, j].SetActive(false);
                    }
                }
            }
            for(int i = 0; i < itemsDay1.GetLength(0); i++)
            {
                for(int j = 0; j < itemsDay1.GetLength(1); j++) {
                    itemsDay1[i, j].SetActive(false);
                }
            }
            for(int i = 0; i < itemsDay3.GetLength(0); i++)
            {
                for(int j = 0; j < itemsDay3.GetLength(1); j++) {
                    itemsDay3[i, j].SetActive(false);
                }
            }
        }
        else {
            definicio.text = definitionsDay3[0];

            for(int i = 0; i < itemsDay3.GetLength(0); i++)
            {
                for(int j = 0; j < itemsDay3.GetLength(1); j++) {
                    if (i == 0) {
                        itemsDay3[i, j].SetActive(true);
                    } else {
                        itemsDay3[i, j].SetActive(false);
                    }
                }
            }
            for(int i = 0; i < itemsDay2.GetLength(0); i++)
            {
                for(int j = 0; j < itemsDay2.GetLength(1); j++) {
                    itemsDay2[i, j].SetActive(false);
                }
            }
            for(int i = 0; i < itemsDay1.GetLength(0); i++)
            {
                for(int j = 0; j < itemsDay1.GetLength(1); j++) {
                    itemsDay1[i, j].SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (time > 0)
        //{
        //    time -= Time.deltaTime;
        //    float minutes = Mathf.FloorToInt(time / 60);
        //    float seconds = Mathf.FloorToInt(time % 60);
        //    timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //}

        if (day == 1) {
            if (Input.GetMouseButtonDown(0) && id < 4)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    Debug.Log(hit.transform.gameObject.name);

                    for(int i = 0; i < itemsDay1.GetLength(1); i++) {
                        itemsDay1[id, i].SetActive(false);
                    }

                    if(hit.transform.gameObject.name == correct_name_day1[id])
                    {                        
                        bombolles_vermelles.SetActive(false);
                        bombolles_blaves.SetActive(true);
                        Debug.Log("+1");
                        scoreSystem.GetComponent<ScoreSystem>().AddScore(1);
                    }
                    else
                    {
                        bombolles_blaves.SetActive(false);
                        bombolles_vermelles.SetActive(true);
                        Debug.Log("-1");
                        scoreSystem.GetComponent<ScoreSystem>().SubtractScore(1);
                    }

                    if (id != 3) {
                        id = id + 1;

                        definicio.text = definitionsDay1[id];

                        for(int i = 0; i < itemsDay1.GetLength(1); i++) {
                            itemsDay1[id, i].SetActive(true);
                        }
                    } else {
                        definicio.text = "";
                    }
                    
                }
            }
        } else if (day == 2) {
            if (Input.GetMouseButtonDown(0) && id < 5)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    Debug.Log(hit.transform.gameObject.name);

                    for(int i = 0; i < itemsDay2.GetLength(1); i++) {
                        itemsDay2[id, i].SetActive(false);
                    }

                    if(hit.transform.gameObject.name == correct_name_day2[id])
                    {                 
                        bombolles_vermelles.SetActive(false);
                        bombolles_blaves.SetActive(true);       
                        scoreSystem.GetComponent<ScoreSystem>().AddScore(1);
                    }
                    else
                    {
                        bombolles_blaves.SetActive(false);
                        bombolles_vermelles.SetActive(true);
                        scoreSystem.GetComponent<ScoreSystem>().SubtractScore(1);
                    }

                    if (id != 4) {
                        id = id + 1;

                        definicio.text = definitionsDay2[id];

                        for(int i = 0; i < itemsDay2.GetLength(1); i++) {
                            itemsDay2[id, i].SetActive(true);
                        }
                    } else {
                        definicio.text = "";
                    }
                    
                }
            }
        } else {
            if (Input.GetMouseButtonDown(0) && id < 6)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    Debug.Log(hit.transform.gameObject.name);

                    for(int i = 0; i < itemsDay3.GetLength(1); i++) {
                        itemsDay3[id, i].SetActive(false);
                    }

                    if(hit.transform.gameObject.name == correct_name_day3[id])
                    {      
                        bombolles_vermelles.SetActive(false);
                        bombolles_blaves.SetActive(true);                  
                        scoreSystem.GetComponent<ScoreSystem>().AddScore(1);
                    }
                    else
                    {
                        bombolles_blaves.SetActive(false);
                        bombolles_vermelles.SetActive(true);
                        scoreSystem.GetComponent<ScoreSystem>().SubtractScore(1);
                    }

                    if (id != 5) {
                        id = id + 1;

                        definicio.text = definitionsDay3[id];

                        for(int i = 0; i < itemsDay3.GetLength(1); i++) {
                            itemsDay3[id, i].SetActive(true);
                        }
                    } else {
                        definicio.text = "";
                    }
                    
                }
            }
        }
    }
}
