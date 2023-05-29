using UnityEngine;
using System.IO  ;


public class Saving_Data : MonoBehaviour
{

    string filePath = "Assets/SavedData/savedData.txt" ;

    public void SaveDataToFile(string data)
    {
        
        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine(data);
        }
        Debug.Log("Data saved to file: " + filePath);

    }


    public void ReceiveSerialData(string receiveData)
    {
        SaveDataToFile(receiveData);
    }
}