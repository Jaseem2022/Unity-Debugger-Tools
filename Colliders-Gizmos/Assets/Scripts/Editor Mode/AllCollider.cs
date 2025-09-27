using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class AllCollider : MonoBehaviour
{
    private void FindAllCollider()
    {
        Collider[] collidersList = FindObjectsOfType<Collider>();
        foreach (var collider in collidersList)
        {
            CheckTrigger(collider);
            CheckColliderShape(collider);
            Handles.Label(collider.transform.position + Vector3.up * 3f, "(Tag : " + collider.tag+")");
        }

    }

    private void CheckColliderShape(Collider collider)
    {
        if (collider is BoxCollider box)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(box.bounds.center, box.bounds.size);
        }
        else if (collider is SphereCollider sphere)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(sphere.bounds.center, sphere.radius);
        }
        else if (collider is CapsuleCollider capsule)
        {
            Gizmos.color = Color.brown;
            Gizmos.DrawWireSphere(capsule.bounds.center, capsule.radius + (capsule.height / 2));
        }
    }

    private void CheckTrigger(Collider collider)
    {
        if (collider.isTrigger)
        {
            Handles.Label(collider.transform.position + Vector3.up * 2.75f, "(IsTrigger)");
        }
    }

    private void OnDrawGizmos()
    {
        FindAllCollider();
    }

}
