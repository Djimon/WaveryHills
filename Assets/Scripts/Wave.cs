using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave {

    public float Center { get; private set; }
    public Color Color { get; private set; }
    public float HalfWidth { get; private set; }
    public float Amplitude { get; private set; }
    public float DecreasePerSecond { get; private set; }
    public float SpreadSpeed { get; private set; }

    public Wave(float center, Color color, float width, float amplitude, float decreasePerSecond, float spreadSpeed)
    {
        this.Center = center;
        this.Color = color;
        this.HalfWidth = width * 0.5F;
        this.Amplitude = amplitude;
        this.DecreasePerSecond = decreasePerSecond;
        this.SpreadSpeed = spreadSpeed;
    }

    public void Update()
    {
        Center += SpreadSpeed * Time.deltaTime;
        Amplitude -= DecreasePerSecond * Time.deltaTime;
    }

    public float GetSample(float x)
    {
        if (x < Center - HalfWidth || Center + HalfWidth < x)
            return 0;
        else
            return (Mathf.Cos( ( x - Center ) * Mathf.PI / HalfWidth ) + 1) * Amplitude;
    }

}
