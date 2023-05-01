using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class UI_CurveController : MonoBehaviour
{
    [SerializeField] private Toggle clearTrailToggle;
    [SerializeField] private TMP_Text version;

    [SerializeField] private LissajousCurve _lissajousCurve;
    [SerializeField, Header("Sliders")] private Slider XSlider, YSlider, αSlider, βSlider, deltaSlider;
    [SerializeField, Header("Current Values")] private TMP_Text XCurrentSliderValue, YCurrentSliderValue, αCurrentSliderValue, βCurrentSliderValue, deltaCurrentSliderValue;

    private void OnEnable()
    {
        version.text = $" VER. {Application.version}";
        
        XSlider.onValueChanged.AddListener(x => {
            XCurrentSliderValue.text = x.ToString("0.0",CultureInfo.InvariantCulture);
            _lissajousCurve.X = x;
            
            if (clearTrailToggle.isOn) _lissajousCurve.TrailRenderer.Clear();
        });

        YSlider.onValueChanged.AddListener(x => {
            YCurrentSliderValue.text = x.ToString("0.0",CultureInfo.InvariantCulture);
            _lissajousCurve.Y = x;
            
            if (clearTrailToggle.isOn) _lissajousCurve.TrailRenderer.Clear();
        });

        αSlider.onValueChanged.AddListener(x => {
            αCurrentSliderValue.text = x.ToString("0.0",CultureInfo.InvariantCulture);
            _lissajousCurve.α = x;
            
            if (clearTrailToggle.isOn) _lissajousCurve.TrailRenderer.Clear();
        });

        βSlider.onValueChanged.AddListener(x => {
            βCurrentSliderValue.text = x.ToString("0.0",CultureInfo.InvariantCulture);
            _lissajousCurve.β = x;
            
            if (clearTrailToggle.isOn) _lissajousCurve.TrailRenderer.Clear();

        });

        deltaSlider.onValueChanged.AddListener(x => {
            deltaCurrentSliderValue.text = x.ToString("0.0",CultureInfo.InvariantCulture);
            _lissajousCurve.delta = x;
            
            if (clearTrailToggle.isOn) _lissajousCurve.TrailRenderer.Clear();
        });
    }
}