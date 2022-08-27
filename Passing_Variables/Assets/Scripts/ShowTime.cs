using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.UI             ;


public class ShowTime : MonoBehaviour
{
    
    public Text timeTxt;

    void Start()
    {
        
    }

    void Update()
    {
        timeTxt.text = "Time: " + StaticVar.num ;
    }
}
