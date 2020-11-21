using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Score : MonoBehaviour
{
    public GameObject player;
    public Text totalScore;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string points = player.GetComponent<S_PlayerMovement>().score.ToString();
        totalScore.text = "Score:" + points;
    }
}
