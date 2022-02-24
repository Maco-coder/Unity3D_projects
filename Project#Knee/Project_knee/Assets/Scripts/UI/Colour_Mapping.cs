using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;

public class Colour_Mapping : MonoBehaviour
{

    public Color redColor, whiteColor;
    Color currentColor               ;
    MeshRenderer myRenderer          ;
    
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material.color = whiteColor   ;
        currentColor = whiteColor                ;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentColor = whiteColor;
        }
        else
        {
            currentColor = redColor  ;
        }

        myRenderer.material.color = Color.Lerp(myRenderer.material.color, currentColor, 0.1f);

    }
}
