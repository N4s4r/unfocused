using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class play : MonoBehaviour
{
    // Start is called before the first frame update
    public static int level = 1;
    float[,] scores = new float[4,3];
    string current_scene;
    List<string> scenes;
    List<List<string>> missatges;
    bool done, done0, done01, done1, done11, done2, done21, done3, done4, done41, done42;
    public TMP_Text titol, textDisplay, textDisplay2, esmorzar, detalls, abstracte, tangram, total, final;
    public Button playButton;
    public GameObject EventManager, camera, Doctor;
    void Start()
    {
        scenes = new List<string> { "esmorzar_a_cegues", "petits_detalls", "Dinar_abstracte", "tangram art�stic" };
        missatges = new List<List<string>>();
        missatges.Add(new List<string>() {"El Dr P. va ser un m�sic de distinci�, conegut durant molts anys com a cantant, i despr�s, a l'Escola de M�sica local, com a professor.\n\n Recentment el seu voltant s'havia adonat de petits incidents que denotaven que el Dr P. veia caracter�stiques individuals, per� no veient el seu context.",
            "Uns mesos mes tard es va adonar que cada cop la seva visio abarcava menys i per tant shavia de despertar mes pronte per fer lesmorzar", "La malaltia ha empitjorat molt i ja no es capa� de veure un objecte al complet. Ha de fer servir la intuicio per treure els aliments de la nevera per tal de fer-se l�esmorzar abans d�anar a l�escola"});
        missatges.Add(new List<string>() {"Va ser a l'escola, en relaci� als seus alumnes, on certs problemes estranys van ser primer observats.\nDe vegades es presentava un estudiant, i el Dr P. no el reconeixeria; o, concretament, no reconeixeria la seva cara. En el moment en qu� l'alumne parl�s, el reconeixeria per la seva veu.",
            "2Patata", "2Patata"});
        missatges.Add(new List<string>(){ "�ltimament tornava a casa per dinar. La seva dona li havia ensenyat a cuinar els seus plats preferits. Ell s'havia apuntat tots els ingredients que necesitava per preparar-los.", "La seva dona s'havia acostumat a trobar el dinar fet, per� ell tenia dificultats per trobar els aliments que necessitava. Les descripcions que tenia dins el seu cap eren massa generals per identificar amb claretat els ingredients", "Li agradava fer el dinar ell, per� cada vegada guardava menys les particularitats de cada aliment. Ja no podra complir el somni de presentar-se a masterchef" });
        missatges.Add(new List<string>() { "A la tarda li agradava passar l'estona pintant el que veia per la finestra...", "Durant les pauses que realitzava a les tardes, veia que ja no sabia veure els detalls del que veia per la finestra i per tant les seves pintures deixaven de ser tant realistes", "Quan decideix posar-se a pintar el que observa pel seu jard� no veu la forma de representar-ho, nomes li venen figures geometriques molt simples al cap" });
        missatges.Add(new List<string>() {"El Dr P. va consultar un oftalm�leg, que va examinar els seus ulls detingudament:\n'No passa res amb els teus ulls. Per� hi ha problemes amb les parts visuals del vostre cervell. No necessiteu la meva ajuda, heu de veure un neur�leg.'.\n I aix�, arran d�aquesta derivaci�, el doctor P. va anar a veure Oliver Sacks.",
            "5Pat", "�5pat"});
        done = false;
        done0 = false;
        done01 = false;
        done1 = false;
        done11 = false;
        done2 = false;
        done21 = false;
        done3 = false;
        done4 = false;
        done41 = false;
        done42 = false;
        textDisplay2.gameObject.SetActive(false);
        esmorzar.gameObject.SetActive(false);
        detalls.gameObject.SetActive(false);
        abstracte.gameObject.SetActive(false);
        tangram.gameObject.SetActive(false);
        total.gameObject.SetActive(false);
        final.gameObject.SetActive(false);
        Doctor.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (level == 4 && done41)
        {
            final.gameObject.SetActive(true);
            playButton.GetComponentInChildren<TextMeshProUGUI>().text = "End Game";
            ButtonControlPlay.myBoolean = false;
            Debug.Log("FINALLL");
        }
        else if (level > 4)
        {
            Application.Quit();
            Debug.Log("Exit");
        }
        else if(ButtonControlPlay.myBoolean == true)
        {
            Debug.Log("Num Aliments: "+esmorzar_a_cegues.num_aliments.ToString());
            Debug.Log("Num Correctes: " + esmorzar_a_cegues.num_correct.ToString());
            if(done == false)
            {
                //playButton.gameObject.SetActive(false);
                titol.gameObject.SetActive(false);
                textDisplay.text = missatges[0][level - 1];
                    textDisplay.fontSize = 20;
                playButton.GetComponentInChildren<TextMeshProUGUI>().text = "Next";
                ButtonControlPlay.myBoolean = false;
                done = true;
            }
            else if (done && !done0)
            {
                camera.gameObject.SetActive(false);
                playButton.gameObject.SetActive(false);
                EventManager.gameObject.SetActive(false);
                textDisplay.gameObject.SetActive(false);
                SceneManager.LoadScene("esmorzar_a_cegues", LoadSceneMode.Additive);
                Debug.Log(esmorzar_a_cegues.num_aliments);
                done0 = true;
            }
            else if (done0 && !done01 && (esmorzar_a_cegues.time < 0 || esmorzar_a_cegues.num_aliments == esmorzar_a_cegues.num_correct))
            {
                scores[0, level - 1] =  esmorzar_a_cegues.num_correct;
                if(0.1f * esmorzar_a_cegues.time > 0)
                {
                    scores[0, level - 1] += 0.1f * esmorzar_a_cegues.time;
                }
                // Get count of loaded Scenes and last index
                var lastSceneIndex = SceneManager.sceneCount - 1;

                // Get last Scene by index in all loaded Scenes
                var lastLoadedScene = SceneManager.GetSceneAt(lastSceneIndex);
                // Unload Scene
                camera.gameObject.SetActive(true);

                SceneManager.UnloadSceneAsync(lastLoadedScene);

                playButton.gameObject.SetActive(true);
                EventManager.gameObject.SetActive(true);
                textDisplay.gameObject.SetActive(true);
                textDisplay.text = missatges[1][level - 1];
                ButtonControlPlay.myBoolean = false;
                done01 = true;
            }
            else if (done01 && !done1)
            {
                camera.gameObject.SetActive(false);
                playButton.gameObject.SetActive(false);
                EventManager.gameObject.SetActive(false);
                textDisplay.gameObject.SetActive(false);
                SceneManager.LoadScene("petits_detalls", LoadSceneMode.Additive);
                done1 = true;
            }
            //Debug.Log(passar_llista.time);
            else if ((passar_llista.time < 0 || passar_llista.num_alumnes == 16) && (done11 == false))
            {
                scores[1, level - 1] = ScoreSystem.score;
                //SceneManager.UnloadSceneAsync("petits_detalls");
                // Get count of loaded Scenes and last index
                var lastSceneIndex = SceneManager.sceneCount - 1;

                // Get last Scene by index in all loaded Scenes
                var lastLoadedScene = SceneManager.GetSceneAt(lastSceneIndex);
                // Unload Scene
                camera.gameObject.SetActive(true);
                SceneManager.UnloadSceneAsync(lastLoadedScene);

                playButton.gameObject.SetActive(true);
                EventManager.gameObject.SetActive(true);
                textDisplay.gameObject.SetActive(true);
                textDisplay.text = missatges[2][level-1];
                ButtonControlPlay.myBoolean = false;
                done11 = true;
                
                Debug.Log(scores[0, level - 1]);
            }
            else if (done11 && !done2)
            {
                camera.gameObject.SetActive(false);
                playButton.gameObject.SetActive(false);
                EventManager.gameObject.SetActive(false);
                textDisplay.gameObject.SetActive(false);
                SceneManager.LoadScene("Dinar_abstracte", LoadSceneMode.Additive);
                done2 = true;
            }
            else if (!done21 && (dinar.id==dinar.size))
            {
                scores[2, level - 1] = ScoreSystem.score;
                //SceneManager.UnloadSceneAsync("petits_detalls");
                // Get count of loaded Scenes and last index
                var lastSceneIndex = SceneManager.sceneCount - 1;

                // Get last Scene by index in all loaded Scenes
                var lastLoadedScene = SceneManager.GetSceneAt(lastSceneIndex);
                // Unload Scene
                camera.gameObject.SetActive(true);
                SceneManager.UnloadSceneAsync(lastLoadedScene);

                playButton.gameObject.SetActive(true);
                EventManager.gameObject.SetActive(true);
                textDisplay.gameObject.SetActive(true);
                textDisplay.text = missatges[3][level-1];
                ButtonControlPlay.myBoolean = false;
                done21 = true;
            }
            else if (done21 && !done3)
            {
                camera.gameObject.SetActive(false);
                playButton.gameObject.SetActive(false);
                EventManager.gameObject.SetActive(false);
                textDisplay.gameObject.SetActive(false);
                SceneManager.LoadScene("tangram art�stic", LoadSceneMode.Additive);
                done3 = true;
            }

            else if (ButtonController.myBoolean == true && done4 == false)
            {
                // Get count of loaded Scenes and last index
                var lastSceneIndex = SceneManager.sceneCount - 1;

                // Get last Scene by index in all loaded Scenes
                var lastLoadedScene = SceneManager.GetSceneAt(lastSceneIndex);
                // Unload Scene
                camera.gameObject.SetActive(true);
                while(pintar.my_draws.Count!=0)
                {
                    Destroy(pintar.my_draws[0], 0);
                }
                SceneManager.UnloadSceneAsync(lastLoadedScene);

                playButton.gameObject.SetActive(true);
                EventManager.gameObject.SetActive(true);
                textDisplay.gameObject.SetActive(true);
                textDisplay.text = missatges[4][level-1];
                ButtonControlPlay.myBoolean = false;
                //GameObject.Find("").SetActive(false);
                level += 1;
                done4 = true;
            }

            else if(done4 && !done41)
            {
                Doctor.gameObject.SetActive(true);
                textDisplay.gameObject.SetActive(false);
                textDisplay2.gameObject.SetActive(true);
                var time = esmorzar_a_cegues.time;
                float minutes = Mathf.FloorToInt(time / 60);
                float seconds = Mathf.FloorToInt(time % 60);
                string timer = string.Format("{0:00}:{1:00}", minutes, seconds);
                esmorzar.text = "Esmorzar a cegues: " + esmorzar_a_cegues.num_correct.ToString() + " Aliments " + timer + " seconds left\t= "+ scores[0, level - 2] + " Punts\t\tGood";
                esmorzar.gameObject.SetActive(true);
                time = passar_llista.time;
                minutes = Mathf.FloorToInt(time / 60);
                seconds = Mathf.FloorToInt(time % 60);
                timer = string.Format("{0:00}:{1:00}", minutes, seconds);
                detalls.text = "Petits detalls: "+ passar_llista.num_alumnes.ToString() + " Alumnes "+ timer + " seconds left = " + scores[1, level-2] + " Punts\t\tGood";
                detalls.gameObject.SetActive(true);
                abstracte.text = "Un dinar abstracte: "+ dinar.correctes.ToString()+ " Aliments correctes\t= "+ scores[2, level - 2] + " Punts\t\tGood";
                abstracte.gameObject.SetActive(true);
                tangram.gameObject.SetActive(true);
                total.text = "Final Score = "+ (scores[0, level - 2]+ scores[1, level - 2]+ scores[2, level - 2]).ToString();
                if (level == 4)
                {
                    total.text += "\nOverall Evaluation = " + (scores[0,0] + scores[1, 0] + scores[2, 0] + (scores[0, 1] + scores[1, 1] + scores[2, 1]) + (scores[0, 2] + scores[1, 2] + scores[2, 2])).ToString();
                }
                total.gameObject.SetActive(true);
                ButtonControlPlay.myBoolean = false;
                done42 = false;
                done41 = true;
            }
            else if(done41 & !done42)
            {
                done = false;
                done0 = false;
                done01 = false;
                done1 = false;
                done11 = false;
                done2 = false;
                done21 = false;
                done3 = false;
                done4 = false;
                done41 = false;
                done42 = true;
                esmorzar_a_cegues.time = 60f;
                passar_llista.time = 60f;
                passar_llista.num_alumnes = 0;
                esmorzar_a_cegues.num_correct = 0;
                if (level == 2)
                {
                    esmorzar_a_cegues.num_aliments = 6;
                }
                else
                {
                    esmorzar_a_cegues.num_aliments = 7;
                }
                dinar.correctes = 0;
                dinar.id = 0;
                ButtonController.myBoolean = false;
                Doctor.gameObject.SetActive(false);
                textDisplay.gameObject.SetActive(true);
                textDisplay2.gameObject.SetActive(false);
                abstracte.gameObject.SetActive(false);
                tangram.gameObject.SetActive(false);
                esmorzar.gameObject.SetActive(false);
                detalls.gameObject.SetActive(false);
                total.gameObject.SetActive(false);
                Debug.Log("RESET");
            }
        }
        
    }
}
