using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text scoreText;
    int score;

    void Start()
    {
        scoreText = GetComponent<Text>();
        score = PlayerPrefs.GetInt("Score");
        scoreText.text = "Score: " + score.ToString();
    }



    

}
