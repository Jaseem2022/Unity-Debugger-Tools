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
            Handles.Label(rigidBody.position + Vector3.up * 1.5f, rigidBody.name);

            if (rigidBody.isKinematic)
            {
                Gizmos.color = Color.green;
            }
            else
            {
                Gizmos.color = Color.aquamarine;
            }
            Gizmos.DrawSphere(rigidBody.position + Vector3.up * 1f, 0.2f);
        }

    }

    // private void FindAllCollider()
    // {
    //     Collider[] collidersList = FindObjectsOfType<Collider>();
    //     foreach (var collider in collidersList)
    //     {
    //         if (collider.isTrigger)
    //         {
    //             Handles.Label(collider.transform.position + Vector3.up *2.5f,"Has IsTrigger");
    //         }

    //         if (collider is BoxCollider box)
    //             {
    //                 Gizmos.color = Color.blue;
    //                 Gizmos.DrawWireCube(box.bounds.center, box.bounds.size);
    //             }
    //             else if (collider is SphereCollider sphere)
    //             {
    //                 Gizmos.color = Color.yellow;
    //                 Gizmos.DrawWireSphere(sphere.bounds.center, sphere.radius);
    //             }
    //             else if (collider is CapsuleCollider capsule)
    //             {
    //                 Gizmos.color = Color.brown;
    //                 // center position
    //                 Vector3 center = capsule.transform.position + capsule.center;
    //                 float radius = capsule.radius;
    //                 float height = capsule.height;

    //                 // cylinder part
    //                 Vector3 cylinderHeight = Vector3.up * (height - 2 * radius);
    //                 Gizmos.DrawCube(center, new Vector3(radius * 2, cylinderHeight.y, radius * 2));

    //                 // top cap
    //                 Gizmos.DrawSphere(center + Vector3.up * (cylinderHeight.y / 2), radius);
    //                 // bottom cap
    //                 Gizmos.DrawSphere(center - Vector3.up * (cylinderHeight.y / 2), radius);
    //             }
    //             Handles.Label(collider.transform.position + Vector3.up * 3f, collider.tag);


    //     }

    // }


    private void OnDrawGizmos()
    {
        FindAllRigidBody();
        //FindAllCollider();
    }

}
