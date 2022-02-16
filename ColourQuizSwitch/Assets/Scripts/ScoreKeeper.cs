using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{

    public int score;
    public Text scoreText;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Star")
        {
            score++;
            scoreText.text = score.ToString();
            Destroy(col.gameObject);
            return;
        }
    }
}
