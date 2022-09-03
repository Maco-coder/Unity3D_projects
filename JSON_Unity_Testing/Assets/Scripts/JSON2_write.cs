using System.IO                 ;
using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;


public class JSON2_write : MonoBehaviour
{
    
    private void Start()
    {

        // GENERATING A JSON FILE FROM PARAMETERS INPUTTED IN UNITY //
        
        PlayerData playerData = new PlayerData();
        playerData.position = new float[] {1.0f,2.5f,3.0f,4.2f};


        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        File.WriteAllText(Application.dataPath + "FileJson.json", json);

    }

    private class PlayerData
    {
        public float [] position;
    }

}