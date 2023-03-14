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
    bool done, done0, done01, done1, done11, done2, done21, done3, done4, done41;
    public TMP_Text titol, textDisplay, textDisplay2, esmorzar, detalls, abstracte, tangram;
    public Button playButton;
    public GameObject EventManager, camera, Doctor;
    void Start()
    {
        scenes = new List<string> { "esmorzar_a_cegues", "petits_detalls", "Dinar_abstracte", "tangram artístic" };
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
        textDisplay2.gameObject.SetActive(false);
        esmorzar.gameObject.SetActive(false);
        detalls.gameObject.SetActive(false);
        abstracte.gameObject.SetActive(false);
        tangram.gameObject.SetActive(false);
        Doctor.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(ButtonControlPlay.myBoolean == true)
        {
            Debug.Log(esmorzar_a_cegues.num_aliments);
            Debug.Log(esmorzar_a_cegues.num_correct);
            if(done == false)
            {
                //playButton.gameObject.SetActive(false);
                titol.gameObject.SetActive(false);
                textDisplay.text = "El Dr P. va ser un músic de distinció, conegut durant molts anys com a cantant, i després, a l'Escola de Música local, com a professor.\n\n Recentment el seu voltant s'havia adonat de petits incidents que denotaven que el Dr P. veia característiques individuals, però no veient el seu context.";
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
                scores[0, level - 1] = ScoreSystem.score;
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
                textDisplay.text = "Va ser a l'escola, en relació als seus alumnes, on certs problemes estranys van ser primer observats.\nDe vegades es presentava un estudiant, i el Dr P. no el reconeixeria; o, concretament, no reconeixeria la seva cara. En el moment en què l'alumne parlés, el reconeixeria per la seva veu.";
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
                textDisplay.text = "Últimament tornava a casa per dinar. La seva dona li havia ensenyat a cuinar els seus plats preferits. Ell s'havia apuntat tots els ingredients que necesitava per preparar-los.";
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
                textDisplay.text = "A la tarda li agradava passar l'estona pintant el que veia per la finestra...";
                ButtonControlPlay.myBoolean = false;
                done21 = true;
            }
            else if (done21 && !done3)
            {
                camera.gameObject.SetActive(false);
                playButton.gameObject.SetActive(false);
                EventManager.gameObject.SetActive(false);
                textDisplay.gameObject.SetActive(false);
                SceneManager.LoadScene("tangram artístic", LoadSceneMode.Additive);
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
                SceneManager.UnloadSceneAsync(lastLoadedScene);

                playButton.gameObject.SetActive(true);
                EventManager.gameObject.SetActive(true);
                textDisplay.gameObject.SetActive(true);
                textDisplay.text = "El Dr P. va consultar un oftalmòleg, que va examinar els seus ulls detingudament.\n'No passa res amb els teus ulls', va concloure el metge. 'Però hi ha problemes amb les parts visuals del vostre cervell.No necessiteu la meva ajuda, heu de veure un neuròleg.'.\n I així, arran d’aquesta derivació, el doctor P. va anar a veure Oliver Sacks.";
                ButtonControlPlay.myBoolean = false;
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
                esmorzar.text = "Esmorzar a cegues: " + esmorzar_a_cegues.num_correct.ToString() + " Aliments " + timer + " seconds left\t\tGood";
                esmorzar.gameObject.SetActive(true);
                time = passar_llista.time;
                minutes = Mathf.FloorToInt(time / 60);
                seconds = Mathf.FloorToInt(time % 60);
                timer = string.Format("{0:00}:{1:00}", minutes, seconds);
                detalls.text = "Petits detalls: "+ passar_llista.num_alumnes.ToString() + " Alumnes "+ timer + " seconds left\t\tGood";
                detalls.gameObject.SetActive(true);
                abstracte.text = "Un dinar abstracte: "+ dinar.correctes.ToString()+ " Aliments correctes\t\tGood";
                abstracte.gameObject.SetActive(true);
                tangram.gameObject.SetActive(true);
                ButtonControlPlay.myBoolean = false;
                
                done41 = true;
            }
        }
        
    }
}
