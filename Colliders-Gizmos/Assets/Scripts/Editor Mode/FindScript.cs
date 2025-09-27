using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class FindScript : MonoBehaviour
{
    void OnDrawGizmos()
    {
        MonoBehaviour[] scripts = FindObjectsOfType<MonoBehaviour>();

        foreach (var script in scripts)
        {
            Handles.Label(script.gameObject.transform.position + Vector3.up*2.75f, "Script Attached : "+script.GetType().Name);
        }

    }
  
}
