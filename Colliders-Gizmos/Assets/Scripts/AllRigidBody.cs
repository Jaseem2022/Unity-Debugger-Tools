using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class AllRigidBody : MonoBehaviour
{

    private void FindAllRigidBody()
    {

        Rigidbody[] rigidBodyList = FindObjectsOfType<Rigidbody>();
        foreach (var rigidBody in rigidBodyList)
        {
            Handles.Label(rigidBody.position + Vector3.up * 1.5f, "Rigid Body : "+rigidBody.name);

            if (rigidBody.isKinematic)
            {
                Handles.Label(rigidBody.position + Vector3.up * 1.25f, "(kinematic)");
                Gizmos.color = Color.green;
            }
            else
            {
                Handles.Label(rigidBody.position + Vector3.up * 1.25f, "(Dynamic)");
                Gizmos.color = Color.aquamarine;
            }
            
            Gizmos.DrawSphere(rigidBody.position + Vector3.up * 1f, 0.2f);
        }

    }


    private void OnDrawGizmos()
    {
        FindAllRigidBody();
    }

}
