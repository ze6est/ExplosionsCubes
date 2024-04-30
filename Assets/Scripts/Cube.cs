using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action<Cube> Clicked;

    public int ChanceSeparation { get; private set; } = 100;

    public void Init(int chanceSeparation) => 
        ChanceSeparation = chanceSeparation;

    private void OnMouseUpAsButton()
    {
        Clicked?.Invoke(this);
        Destroy(gameObject);
    }    
}