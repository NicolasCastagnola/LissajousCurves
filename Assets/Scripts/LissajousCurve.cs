using UnityEngine;
public class LissajousCurve : MonoBehaviour
{
    private float _currentTime;
    private Vector3 finalPosition;
    
    [Header("EQUATION VALUES")]
    public float X = 4f;
    public float Y = 2f;
    public float α = 4f;
    public float β = 6f;
    public float delta = 2f;
    public TrailRenderer TrailRenderer { get; private set; }
    public void Start() => TrailRenderer = GetComponent<TrailRenderer>();
    public void Update() => CalculateStandardLissajousCurve();
    private void CalculateStandardLissajousCurve()
    {
        _currentTime = Time.time;
        
        finalPosition = transform.position;
        
        finalPosition.x = X * Mathf.Sin(α * _currentTime + delta);
        finalPosition.y = Y * Mathf.Sin(β * _currentTime);

        transform.position = finalPosition;
    }
}
