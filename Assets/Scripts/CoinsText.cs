using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsText : MonoBehaviour
{
    public static int Coins;
    public Text _text;
    private void Start()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        _text.text = Coins.ToString();
    }
}
