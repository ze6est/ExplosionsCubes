using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private List<Color> _colors = new List<Color>();

    private Spawner _spawner;

    private void Awake() => 
        _spawner = GetComponent<Spawner>();

    private void Start() =>
        _spawner.Spawned += OnSpawned;

    private void OnDestroy() =>
        _spawner.Spawned -= OnSpawned;

    private void OnSpawned(GameObject newObject) => 
        ChangeColor(newObject);

    private void ChangeColor(GameObject gameObject)
    {
        int indexColor = Random.Range(0, _colors.Count);

        gameObject.GetComponent<Renderer>().material.color = _colors[indexColor];
    }
}