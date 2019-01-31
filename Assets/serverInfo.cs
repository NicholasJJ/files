using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class serverInfo : MonoBehaviour
{
    public static serverInfo CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<serverInfo>(jsonString);
    }
}
