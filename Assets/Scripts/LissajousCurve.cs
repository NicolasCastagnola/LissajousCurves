using UnityEngine;
public class LissajousCurve : MonoBehaviour
{
    private float _currentTime;
    private Vector3 finalPosition;
    
    [Header("EQUATION VALUES")]
    [Range(0,20)] public float X = 4f;
    [Range(0,20)] public float Y = 4f;
    [Range(0,20)] public float α = 5f;
    [Range(0,20)] public float β = 4f;
    
    [Range(0,20)] public float delta = 2.3f;
    
    public TrailRenderer TrailRenderer { get; private set; }
    
    public void Start()
    {
        TrailRenderer = GetComponent<TrailRenderer>();
        
        CalculateStandardLissajousCurve();
    }
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
