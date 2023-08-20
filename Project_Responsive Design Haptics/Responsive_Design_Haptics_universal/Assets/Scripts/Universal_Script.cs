
using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.UI             ;
using UnityEngine.SceneManagement;

using Valve.VR                   ; // Needed to enable and disable VR trackers //
using Valve.VR.InteractionSystem ; // Needed to enable and disable VR controllers //


public class Universal_Script : MonoBehaviour
{

    public static int device = OpeningScene_Devices.chosen_device ;

    public GameObject Apple                ;
    private Rigidbody AppleRigidBody       ;

    public GameObject Grabber              ;
    public GameObject Body3                ;
    private Rigidbody GrabberRigidBody     ;

    public GameObject Picker_VR_Controller ;
    public GameObject Picker_3D_Touch      ;
    public GameObject Picker_Fruit_Picker  ;

    public GameObject OuterCube_InTree     ;
    public GameObject InnerCube_InTree     ;
    public GameObject TrunkCube_InTree     ;
    public GameObject LargeCube_InWorld    ;  // For vibrations produced by 3D touch when carrying apple in basket //
    public GameObject Capsule_Apple        ;  // For more intense friction produced by 3D touch around apple //
    


    void Start()
    {

        

        Capsule_Apple.SetActive(false)     ;
        OuterCube_InTree.SetActive(false)  ;
        InnerCube_InTree.SetActive(false)  ;
        TrunkCube_InTree.SetActive(false)  ;
        LargeCube_InWorld.SetActive(false) ;

        Picker_VR_Controller.SetActive(false) ;
        Picker_3D_Touch.SetActive(false)      ;
        Picker_Fruit_Picker.SetActive(false)  ;
        
        Apple.GetComponent<Haptics_Pen_v1>().enabled = false        ;
        Apple.GetComponent<SteamVR_TrackedObject>().enabled = false ;
        Apple.GetComponent<Interactable>().enabled = false          ;
        Apple.GetComponent<Throwable>().enabled = false             ;

        AppleRigidBody = Apple.GetComponent<Rigidbody>()            ;


        Grabber.GetComponent<Haptics_Vive>().enabled = false          ;
        Grabber.GetComponent<SteamVR_TrackedObject>().enabled = false ;
        Grabber.GetComponent<Interactable>().enabled = false          ;
        Grabber.GetComponent<Throwable>().enabled = false             ;

        GrabberRigidBody = Apple.GetComponent<Rigidbody>() ;


        Picker_VR_Controller.GetComponent<Haptics_Vive>().enabled = false         ;
        Picker_Fruit_Picker.GetComponent<SteamVR_TrackedObject>().enabled = false ;
        Picker_VR_Controller.GetComponent<Interactable>().enabled = false         ;
        Picker_VR_Controller.GetComponent<Throwable>().enabled = false            ;

    }

    void Update()
    {

        transform.Rotate(90, 0, 0);

        if (device == 1)  // IF VR CONTROLLER IS CHOSEN IN THE OPENING SCENE //
        {
            //Debug.Log("The device chosen was VR controller")   ;
            
            Apple.GetComponent<SpringJoint>().spring = 50      ;
            Apple.GetComponent<SpringJoint>().damper = 2       ;
            Apple.GetComponent<SpringJoint>().breakTorque = 10 ;
            Apple.GetComponent<SpringJoint>().breakForce = 10  ;
            
            OuterCube_InTree.SetActive(true)     ;
            InnerCube_InTree.SetActive(true)     ;
            TrunkCube_InTree.SetActive(true)     ;
            Picker_VR_Controller.SetActive(true) ;

            Apple.GetComponent<Interactable>().enabled = true ;
            Apple.GetComponent<Throwable>().enabled = true    ;

            Picker_VR_Controller.GetComponent<Haptics_Vive>().enabled = true ;
            Picker_VR_Controller.GetComponent<Interactable>().enabled = true ;
            Picker_VR_Controller.GetComponent<Throwable>().enabled = true    ;

        }


        if (device == 2)  // IF 3D TOUCH IS CHOSEN IN THE OPENING SCENE //
        {
            //Debug.Log("The device chosen was 3D Touch");

            Apple.GetComponent<SpringJoint>().spring = 50      ;
            Apple.GetComponent<SpringJoint>().damper = 2       ;
            Apple.GetComponent<SpringJoint>().breakTorque = 30 ;
            Apple.GetComponent<SpringJoint>().breakForce = 30  ;

            OuterCube_InTree.SetActive(true) ;
            TrunkCube_InTree.SetActive(true) ;
            Picker_3D_Touch.SetActive(true)  ;

            Apple.GetComponent<Interactable>().enabled = true   ;
            Apple.GetComponent<Throwable>().enabled = true      ;

            Apple.GetComponent<Haptics_Pen_v1>().enabled = true ;

        }


        if (device == 3)  // IF FRUIT PICKER IS CHOSEN IN THE OPENING SCENE //
        {
            //Debug.Log("The device chosen was Fruit picker")    ;

            // We do not require a joint in the scene, as the virtual apple is tracked with the VIVE tracker //
            Apple.GetComponent<SpringJoint>().spring = 50      ;
            Apple.GetComponent<SpringJoint>().damper = 2       ;
            Apple.GetComponent<SpringJoint>().breakTorque = 0  ;
            Apple.GetComponent<SpringJoint>().breakForce = 0   ;

            AppleRigidBody.isKinematic = true                  ;

            Picker_Fruit_Picker.SetActive(true) ;

            Apple.GetComponent<SteamVR_TrackedObject>().enabled = true ;
            
        }
                
    }

}