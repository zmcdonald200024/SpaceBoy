using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text score;

    void Start()
    {
        score = GetComponent<Text>();
       
    }

    private void OnEnable()
    {
        Subscribe();
    }
    private void OnDisable()
    {
        Unsubscribe();
    }

    private void UpdateScoreUI(int newScoreCount)
    {


        score.text = "Score: " + newScoreCount.ToString();


    }

   

    private void Subscribe()
    {
        Unsubscribe();
        UIEventController.Instance.onScoreChange += UpdateScoreUI; //switch this back to +=

    }

    private void Unsubscribe()
    {
        UIEventController.Instance.onScoreChange -= UpdateScoreUI; //switch this back to -=
    }
}
