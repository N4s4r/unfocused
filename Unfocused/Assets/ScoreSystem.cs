using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreSystem : MonoBehaviour
{

    public static float score;
    //private GameObject scoreText;
    public TMP_Text scoreText;
    void Start()
    {
        //scoreText = GameObject.Find("Score");
        //scoreText.GetComponent<TextMeshPro>().SetText("Alumnes encertats: " + score.ToString());
        score = 0;
    }


    public void Update()
    {
        //scoreText.GetComponent<TextMeshPro>().SetText("Alumnes encertats: "+score.ToString());
    }

    public void AddScore(float amount)
    {
        score += amount;
        scoreText.text="Punts: "+ score.ToString();
    }
    public void SubtractScore(float amount)
    {
        score -= amount;
        scoreText.text = "Punts: " + score.ToString();
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("score", score);
    }
    public void Load()
    {
        score = PlayerPrefs.GetFloat("score");
    }
}