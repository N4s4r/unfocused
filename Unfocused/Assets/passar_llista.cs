using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class passar_llista : MonoBehaviour
{
    private GameObject alumne;
    public static int num_alumnes=0;
    private List<string> alumnes_trobats, alumnes;
    private string current_alumne;
    public GameObject scoreSystem;
    public static float time=60f, time_speaking, particle_size = 2f;
    public TMP_Text timer, titol;
    public ParticleSystem blur;
    
    // Start is called before the first frame update
    void Start()
    {
        titol.text = "Llista Estudiants 202" + play.level.ToString();
        time_speaking = 0f;
        alumnes_trobats = new List<string>();
        alumnes = new List<string>(){"pau", "júlia", "berta", "adrià", "laura", "tresa", "núria", "eloi", "toni", "marc", "nil", "rita", "elsa", "ana", "maria", "xavi"};
        current_alumne = alumnes[Random.Range(0, alumnes.Count)];
        alumne = GameObject.Find(current_alumne);
        for (int i = 0; i<alumnes.Count; i++)
        {
            if (alumnes[i] != current_alumne)
            {
                GameObject.Find(alumnes[i]).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        time_speaking += Time.deltaTime;
        var main = blur.main;
        main.startSize = particle_size - 0.1f*time_speaking;
        if (time > 0)
        {
            time -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);
            timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        if (Input.GetMouseButtonDown(0) && alumnes.Count>0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
                if(hit.transform.gameObject.name == alumne.gameObject.name + "_carnet")
                {
                    alumne.GetComponent<SpriteRenderer>().enabled = false;
                    alumnes_trobats.Add(current_alumne);
                    alumnes.Remove(current_alumne);
                    scoreSystem.GetComponent<ScoreSystem>().AddScore(1);
                    particle_size = 2f;
                    time_speaking = 0f;
                    num_alumnes += 1;
                    if (alumnes.Count > 0)
                    {
                        current_alumne = alumnes[Random.Range(0, alumnes.Count)];
                        alumne = GameObject.Find(current_alumne);
                        alumne.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else
                    {
                        scoreSystem.GetComponent<ScoreSystem>().AddScore(0.1f*time);
                        blur.Stop();
                    }
                    
                }
                else
                {
                    scoreSystem.GetComponent<ScoreSystem>().SubtractScore(1);
                }
                
            }
        }
    }

    public int GetNumTrobats()
    {
        return alumnes_trobats.Count;
    }
}
