using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private List<Color> _colors = new List<Color>();

    private Renderer _renderer;

    private void Awake() => 
        _renderer = GetComponent<Renderer>();

    public void ChangeColor()
    {
        int indexColor = Random.Range(0, _colors.Count);

        _renderer.material.color = _colors[indexColor];
    }
}