using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{   
    [Serializable]
    public class RespawnObject
    {
        public GameObject obj;
        public Vector3 loc;
    }
    public List<RespawnObject> respawnObjects;

    // Start is called before the first frame update
    void Start()
    {
        foreach (RespawnObject obj in respawnObjects)
        {
            GameObject spawned = Instantiate(obj.obj, obj.loc, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
