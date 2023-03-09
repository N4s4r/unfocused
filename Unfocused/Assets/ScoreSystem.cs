using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreSystem : MonoBehaviour
{

    public int score;
    //private GameObject scoreText;
    public GameObject scoreText;
    void Start()
    {
        //scoreText = GameObject.Find("Score");
        //scoreText.GetComponent<TextMeshPro>().SetText("Alumnes encertats: " + score.ToString());
    }


    public void Update()
    {
        //scoreText.GetComponent<TextMeshPro>().SetText("Alumnes encertats: "+score.ToString());
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.gameObject.GetComponent<TextMeshPro>().SetText("Alumnes encertats: ");// + score.ToString());
    }
    public void SubtractScore(int amount)
    {
        score -= amount;
    }
    public void Save()
    {
        PlayerPrefs.SetInt("score", score);
    }
    public void Load()
    {
        score = PlayerPrefs.GetInt("score");
    }
}