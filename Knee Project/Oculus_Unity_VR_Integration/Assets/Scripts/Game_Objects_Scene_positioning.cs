using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;

public class Game_Objects_Scene_positioning : MonoBehaviour
{

    public GameObject Headset_camera;
    public GameObject Cube_collider ;
    public GameObject Manikin_body  ;

    public Vector3 Camera_target_Position ;  // (1.75, -0.50, -1.50)
    public Vector3 Collider_offset        ;
    public Vector3 Body_offset            ;


    void Start()
    {
        Headset_camera.transform.position = Camera_target_Position                            ;
        Cube_collider.transform.position = Headset_camera.transform.position + Collider_offset;
    }

    
    void Update()
    {
        
    }
}