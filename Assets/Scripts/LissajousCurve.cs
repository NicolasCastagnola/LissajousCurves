using System;
using UnityEngine;

public enum TrailPreset { White, Green, Red, Blue, Rainbow }

public class LissajousCurve : MonoBehaviour
{
    private float _currentTime;
    private Vector3 finalPosition;
    
    [Header("TRAIL VALUES")]
    public float speedMultiplier;
    public float trailDuration;
    
    [Header("EQUATION VALUES")]
    public float X;
    public float Y;
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

        finalPosition.x = X * Mathf.Sin(α * _currentTime + delta);
        finalPosition.y = Y * Mathf.Sin(β * _currentTime);

        transform.position = finalPosition;
    }
    public void SetTrailColor(TrailPreset trailPreset)
    {
        switch (trailPreset)
        {
            case TrailPreset.White:
                break;
            
            case TrailPreset.Green:
                break;
            
            case TrailPreset.Red:
                break;
            
            case TrailPreset.Blue:
                break;
            
            case TrailPreset.Rainbow:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(trailPreset), trailPreset, null);
        }
    }
}
