using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text scoreTxt;

    int scoreIs;
    // Start is called before the first frame update
    void Start()
    {
        scoreTxt.text = "Score: " + scoreIs;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int point)
    {
        scoreIs += point;
        scoreTxt.text = "Score: " + scoreIs;
    }
}
