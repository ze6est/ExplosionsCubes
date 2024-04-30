using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private int _force = 400;
    [SerializeField] private int _radius = 1;    

    public void Init(Cube cube)
    {
        if (cube.TryGetComponent(out Rigidbody rigidbody))
            Explode(rigidbody);
    }

    private void Explode(Rigidbody rigidbody) => 
        rigidbody.AddExplosionForce(_force, transform.position, _radius);
}