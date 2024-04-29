using System;
using Assets.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _minCountCubes = 2;
    [SerializeField] private int _maxCountCubes = 6;
    [SerializeField] private int _chanceSeparation = 100;
    [SerializeField] private int _divider = 2;

    public event Action<GameObject> Spawned;    

    private void OnMouseUpAsButton()
    {        
        InstantiateCubes();
        Destroy(gameObject);
    }

    private void InstantiateCubes()
    {
        int percentage = Random.Range(0, Constant.MaxPercentage);

        if(percentage <= _chanceSeparation)
        {
            int count = Random.Range(_minCountCubes, _maxCountCubes);

            for (int i = 0; i < count; i++)
            {
                GameObject newObject = Instantiate(gameObject, transform.position, Quaternion.identity);
                newObject.GetComponent<Spawner>().ReduceChanceSeparation();

                Spawned?.Invoke(newObject);
            }
        }        
    }

    private void ReduceChanceSeparation() => 
        _chanceSeparation /= _divider;
}