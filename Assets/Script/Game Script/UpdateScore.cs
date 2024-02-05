using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] public int score = 0;
    private void Update(){
        UpdateScoreText();
    }
    private void UpdateScoreText(){
        scoreText.text = "Score: " + score.ToString();
    }
}
