using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class Explosion : MonoBehaviour
{
    [SerializeField] private int _force = 400;
    [SerializeField] private int _radius = 1;

    private Spawner _spawner;

    private void Awake() =>
        _spawner = GetComponent<Spawner>();

    private void Start() =>
        _spawner.Spawned += OnSpawned;

    private void OnDestroy() =>
        _spawner.Spawned -= OnSpawned;

    private void OnSpawned(GameObject newObject)
    {
        if (newObject.TryGetComponent(out Rigidbody rigidbody))
            Explode(rigidbody);
    }

    private void Explode(Rigidbody rigidbody) => 
        rigidbody.AddExplosionForce(_force, transform.position, _radius);
}