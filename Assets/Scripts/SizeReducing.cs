using Assets.Scripts;
using UnityEngine;

[RequireComponent (typeof(Spawner))]
public class SizeReducing : MonoBehaviour
{
    [SerializeField] private float _percentageReduction = 50;    

    private Spawner _spawner;

    private void Awake() => 
        _spawner = GetComponent<Spawner>();

    private void Start() => 
        _spawner.Spawned += OnSpawned;

    private void OnDestroy() => 
        _spawner.Spawned -= OnSpawned;

    private void OnSpawned(GameObject newObject) => 
        Reduce(newObject);

    private void Reduce(GameObject gameObject)
    {
        Vector3 currentScale = gameObject.transform.localScale;

        currentScale *= _percentageReduction / Constant.MaxPercentage;

        gameObject.transform.localScale = currentScale;
    }   
}