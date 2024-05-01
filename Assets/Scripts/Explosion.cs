using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private int _force = 100;
    [SerializeField] private float _radius = 1f;
    [SerializeField] private float _upwardsModifier = 3f;

    public void Explode()
    {
        foreach(Rigidbody explodableObject in GetExplodableObjects())
        {
            explodableObject.AddExplosionForce(_force / transform.localScale.x, transform.position, _radius / transform.localScale.x, _upwardsModifier);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _radius);

        List<Rigidbody> objects = new List<Rigidbody>();

        foreach (Collider hit in hits)
            if(hit.attachedRigidbody != null)
                objects.Add(hit.attachedRigidbody);

        return objects;
    }
}