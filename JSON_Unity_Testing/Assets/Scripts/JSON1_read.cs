using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;
using System.IO                 ;


public class JSON1_read : MonoBehaviour
{

    void Start()
    {
        // EXTRACTING VARIABLES FOR HAPTIC MODALITIES SPECIFIED BY AN EXPERIENCE DESIGNER IN THE "JSON1-name_modalities" FILE //

        Debug.Log("GameHandler.start") ;
        string json = File.ReadAllText(Application.dataPath + "/JSON1-name_modalities.json");
        PlayerData loadedExperienceData = JsonUtility.FromJson<PlayerData>(json) ;
        Debug.Log("position of cube: "+loadedExperienceData.PositionCube) ;
        Debug.Log("scale of cube: "+loadedExperienceData.ScaleCube)       ;
        Debug.Log("speed of cube: "+loadedExperienceData.SpeedCube)       ;
        Debug.Log("gravity enable: "+loadedExperienceData.GravityYN)      ;



        StoreVariables.position_x = loadedExperienceData.PositionCube.x ;
        StoreVariables.position_y = loadedExperienceData.PositionCube.y ;
        StoreVariables.position_z = loadedExperienceData.PositionCube.z ;

        StoreVariables.scale_x = loadedExperienceData.ScaleCube.x ;
        StoreVariables.scale_y = loadedExperienceData.ScaleCube.y ;
        StoreVariables.scale_z = loadedExperienceData.ScaleCube.z ;

        StoreVariables.speed_x = loadedExperienceData.SpeedCube.x ;
        StoreVariables.speed_y = loadedExperienceData.SpeedCube.y ;
        StoreVariables.speed_z = loadedExperienceData.SpeedCube.z ;

        StoreVariables.gravity = loadedExperienceData.GravityYN ;


    }

    
    void Update()
    {
        
    }

    
    private class PlayerData
    {
        public Vector3 PositionCube;
        public Vector3 ScaleCube   ;
        public Vector3 SpeedCube   ;
        public bool GravityYN      ;
    }
}