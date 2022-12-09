using UnityEngine;

public class RangeFloat //classe responsável por retornar o valor entre o mínimo e máximo das floats informadas.
{
    private float min;
    private float max;
    private float currentValue;


    public RangeFloat(float min, float max)
    {
        this.min = min;
        this.max = max;
        this.currentValue = min;
    }

    public float Current 
    {
        get 
        {
            return currentValue;
        }
    }

    public void add(float value)
    {
        currentValue = Mathf.Clamp(currentValue + value,min,max);
    }

    public void Sub(float value)
    {
        currentValue = Mathf.Clamp(currentValue - value,min,max);
    }
}
