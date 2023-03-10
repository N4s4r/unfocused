using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class play : MonoBehaviour
{
    // Start is called before the first frame update
    public static int level = 1;
    float[,] scores = new float[4,3];
    string current_scene;
    List<string> scenes;
    bool done1, done2, done3;

    void Start()
    {
        scenes = new List<string> { "esmorzar_a_cegues", "petits_detalls", "Dinar_abstracte", "tangram artístic" };
        SceneManager.LoadScene("petits_detalls", LoadSceneMode.Additive);
        done1 = false;
        done2 = false;
        done3 = false;
    }

        // Update is called once per frame
    void Update()
    {
        //Debug.Log(passar_llista.time);
        if ((passar_llista.time < 0 || passar_llista.num_alumnes==16)&&(done1==false))
        {
            scores[0, level-1] = ScoreSystem.score;
            //SceneManager.UnloadSceneAsync("petits_detalls");
            // Get count of loaded Scenes and last index
            var lastSceneIndex = SceneManager.sceneCount - 1;

            // Get last Scene by index in all loaded Scenes
            var lastLoadedScene = SceneManager.GetSceneAt(lastSceneIndex);
            // Unload Scene
            SceneManager.UnloadSceneAsync(lastLoadedScene);
            SceneManager.LoadScene("tangram artístic", LoadSceneMode.Additive);
            Debug.Log(scores[0, level - 1]);
            done1 = true;
        }
        if (ButtonController.myBoolean == true && done2 == false)
        {
            // Get count of loaded Scenes and last index
            var lastSceneIndex = SceneManager.sceneCount - 1;

            // Get last Scene by index in all loaded Scenes
            var lastLoadedScene = SceneManager.GetSceneAt(lastSceneIndex);
            // Unload Scene
            SceneManager.UnloadSceneAsync(lastLoadedScene);

            SceneManager.LoadScene("esmorzar_a_cegues", LoadSceneMode.Additive);
            done2 = true;
        }
    }
}
