using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;


public class StaticVar : MonoBehaviour
{
    
    public static float num = 0;

    void Start()
    {
        
    }

    void Update()
    {
        num += Time.deltaTime;
    }
}
