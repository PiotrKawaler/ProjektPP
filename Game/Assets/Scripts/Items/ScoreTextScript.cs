using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{

    public Text text;
    public static int coinCount = 0;

    // Update is called once per frame
    void Update()
    {
        text.text = coinCount.ToString();
    }
}
