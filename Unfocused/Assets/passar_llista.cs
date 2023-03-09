using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class passar_llista : MonoBehaviour
{
    private GameObject alumne;
    private List<string> alumnes_trobats, alumnes;
    private string current_alumne;
    public GameObject scoreSystem;
    public float time=60;
    public TMP_Text timer;
    public ParticleSystem blur;
    // Start is called before the first frame update
    void Start()
    {       
        alumnes_trobats = new List<string>();
        alumnes = new List<string>(){"pau", "j�lia", "berta", "adri�", "laura", "tresa", "n�ria", "eloi", "toni", "marc", "nil", "rita", "elsa", "ana", "maria", "xavi"};
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
        time -= Time.deltaTime;
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
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
}
