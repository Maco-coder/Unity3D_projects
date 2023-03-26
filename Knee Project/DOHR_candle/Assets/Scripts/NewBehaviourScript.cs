using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject tracked_object ;
    public GameObject candle         ;
    public float offset              ;

    void Start()
    {
        candle.transform.position = new Vector3(tracked_object.transform.position.x, tracked_object.transform.position.y + offset, tracked_object.transform.position.z);
    }

    void Update()
    {
        
    }
}