using System;
using UnityEngine;

public enum TrailPreset { White, Green, Red, Blue, Rainbow }
public class LissajousCurve : MonoBehaviour
{
    private float _currentTime;
    private Vector3 finalPosition;
    
    [Header("TRAIL VALUES")]
    public float speedMultiplier;
    [Header("EQUATION VALUES")]
    public float A;
    public float B;
    public float α;
    public float β;
    public float delta;
    public TrailRenderer TrailRenderer { get; private set; }
    public void Start() => TrailRenderer = GetComponent<TrailRenderer>();
    public void Update() => CalculateStandardLissajousCurve();
    private void CalculateStandardLissajousCurve()
    {
        _currentTime = Time.time * speedMultiplier;
        
        finalPosition = transform.position;

        finalPosition.x = A * Mathf.Sin(α * _currentTime + delta);
        finalPosition.y = B * Mathf.Sin(β * _currentTime);

        transform.position = finalPosition;
    }
}
