
using System.Collections          ;
using System.Collections.Generic  ;
using UnityEngine                 ;
using UnityEngine.UI              ;
using UnityEngine.SceneManagement ;


public class OpeningScene_Devices : MonoBehaviour
{

    public Button ButtonVRController;
    public Button Button3DTouch     ;
    public Button ButtonFruitPicker ;

    public static int chosen_device = 0 ;


    public void DeviceChosenIsVRController ()
    {
        chosen_device = 1                        ;
        SceneManager.LoadScene("UNIVERSAL_Scene");
    }

    public void DeviceChosenIs3DTouch ()
    {
        chosen_device = 2                        ;
        SceneManager.LoadScene("UNIVERSAL_Scene");
    }

    public void DeviceChosenIsFruitPicker ()
    {
        chosen_device = 3                        ;
        SceneManager.LoadScene("UNIVERSAL_Scene");
    }


    void Start()
    {
        
    }

    void Update()
    {
          
    }
}