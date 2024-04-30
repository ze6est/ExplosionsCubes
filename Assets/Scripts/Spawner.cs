using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _template;
    [SerializeField] private Separator _separator;

    [SerializeField] private int _minCountCubes = 2;
    [SerializeField] private int _maxCountCubes = 6;    

    public event Action<Cube> Spawned;

    private void Start() => 
        _separator.Separated += OnSeparated;

    private void OnDestroy() => 
        _separator.Separated -= OnSeparated;

    private void OnSeparated(Cube cube, int chanceSeparation) => 
        SpawnCubes(cube, chanceSeparation);

    private void SpawnCubes(Cube cube, int chanceSeparation)
    {
        int count = Random.Range(_minCountCubes, _maxCountCubes);

        for (int i = 0; i < count; i++)
        {
            Cube newCube = Instantiate(_template, cube.transform.position, Quaternion.identity);
            InitCubeComponents(newCube, cube, chanceSeparation);

            Spawned?.Invoke(newCube);
        }
    }

    private void InitCubeComponents(Cube newCube, Cube oldCube, int chanceSeparation)
    {
        newCube.Init(chanceSeparation);

        if (newCube.TryGetComponent(out SizeReducing sizeReducing))
            sizeReducing.Init(oldCube);

        if (newCube.TryGetComponent(out Explosion explosion))
            explosion.Init(oldCube);

        if (newCube.TryGetComponent(out ColorChanger colorChanger))
            colorChanger.ChangeColor();
    }
}