using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text lives;

    void Start()
    {
        lives = GetComponent<Text>();
    }

    private void OnEnable()
    {
        Subscribe();
    }
    private void OnDisable()
    {
        Unsubscribe();
    }

    private void UpdateLivesUI(int newLivesCount)
    {
        lives.text = "Lives: " + newLivesCount.ToString();
    }

    private void Subscribe()
    {
        Unsubscribe();
        UIEventController.Instance.OnLivesChange += UpdateLivesUI;

    }

    private void Unsubscribe()
    {
        UIEventController.Instance.OnLivesChange -= UpdateLivesUI;
    }
}
