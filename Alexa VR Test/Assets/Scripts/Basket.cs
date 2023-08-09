using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    private TMP_Text text;
    private int apple_count = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "apple")
        {
            apple_count++;
            text.text = apple_count + " apples";
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "apple")
        {
            apple_count--;
            text.text = apple_count + " apples";
        }
    }
}
