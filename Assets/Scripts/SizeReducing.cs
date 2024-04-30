using Assets.Scripts;
using UnityEngine;

public class SizeReducing : MonoBehaviour
{
    [SerializeField] private float _percentageReduction = 50;

    public void Init(Cube cube) => 
        Reduce(cube.gameObject.transform.localScale);

    private void Reduce(Vector3 scale)
    {
        scale *= _percentageReduction / Constant.MaxPercentage;        

        gameObject.transform.localScale = scale;
    }   
}