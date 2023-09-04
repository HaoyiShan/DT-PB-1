using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public TMP_Text ui;
    public int Coin = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("coin"))
        {
            Coin++;
            ui.text = "Coin : " + Coin;
            Destroy(other.gameObject);
        }
    }
}
