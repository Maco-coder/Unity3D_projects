using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using System.IO.Ports            ;

public class IMUdata2 : MonoBehaviour
{

    public IMUdata1 IMUdata1_ ;


    void Start()
    {

    }

    
    void Update()
    {

        //print(IMUdata1_.x_value2) ;
        //print(IMUdata1_.y_value2) ;

        Vector3 to = new Vector3(IMUdata1_.x_value2, 0, IMUdata1_.y_value2);  // Raw values
        transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime*100);

    }
}
