using System;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class Separator : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private List<Cube> _cubes = new List<Cube>();
    [SerializeField] private int _divider = 2;    

    public event Action<Cube, int> Separated;    

    private void Start() => 
        Subscribe();

    private void OnDestroy() => 
        Unsubscribe();

    private void Subscribe()
    {
        foreach (Cube cube in _cubes)
            cube.Clicked += Separate;

        _spawner.Spawned += OnSpawned;
    }    

    private void Unsubscribe()
    {
        foreach (Cube cube in _cubes)
            cube.Clicked -= Separate;

        _spawner.Spawned -= OnSpawned;
    }    

    private void OnSpawned(Cube cube) => 
        cube.Clicked += Separate;

    private void Separate(Cube cube)
    {
        int percentage = Random.Range(0, Constant.MaxPercentage);
        int chanceSeparation = cube.ChanceSeparation;

        if (percentage <= chanceSeparation)
        {
            ReduceChanceSeparation(ref chanceSeparation);
            Separated?.Invoke(cube, chanceSeparation);
        }
        else
        {
            if (cube.TryGetComponent(out Explosion explosion))
                explosion.Explode();
        }
    }

    private void ReduceChanceSeparation(ref int chanceSeparation) =>
        chanceSeparation /= _divider;
}