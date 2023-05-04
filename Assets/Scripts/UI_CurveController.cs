using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class UI_CurveController : MonoBehaviour
{
    [SerializeField] private List<Gradient> _colorGradients;
    [SerializeField] private TMP_Dropdown trailDropdown;
    [SerializeField] private Toggle clearTrailToggle;
    [SerializeField] private TMP_Text version;

    [SerializeField] private LissajousCurve _lissajousCurve;
    [SerializeField, Header("Sliders")] private Slider XSlider, YSlider, αSlider, βSlider, deltaSlider, speedSlider, trailTime;
    [SerializeField, Header("Current Values")] private TMP_Text XCurrentSliderValue, YCurrentSliderValue, αCurrentSliderValue, βCurrentSliderValue, deltaCurrentSliderValue,speedCurrentSliderValue, trailRefreshCurrentSliderValue ;

    private void OnEnable()
    {
        //DROPDOWN
        trailDropdown.ClearOptions();
        string[] enumNames = Enum.GetNames(typeof(TrailPreset));
        trailDropdown.AddOptions(new List<string>(enumNames));
        trailDropdown.onValueChanged.AddListener(x => _lissajousCurve.TrailRenderer.colorGradient = _colorGradients[x]);
        
        //SLIDERS
        trailTime.onValueChanged.AddListener(x => 
        {
            trailRefreshCurrentSliderValue.text = x.ToString("0.0", CultureInfo.InvariantCulture);
            _lissajousCurve.TrailRenderer.time = x;
            
            if (clearTrailToggle.isOn) _lissajousCurve.TrailRenderer.Clear();
        });
        speedSlider.onValueChanged.AddListener(x => 
        {
            speedCurrentSliderValue.text = x.ToString("0.0", CultureInfo.InvariantCulture);
            _lissajousCurve.speedMultiplier = x;
            
            if (clearTrailToggle.isOn) _lissajousCurve.TrailRenderer.Clear();
        });
        XSlider.onValueChanged.AddListener(x => 
        {
            XCurrentSliderValue.text = x.ToString("0.0", CultureInfo.InvariantCulture);
            _lissajousCurve.A = x;
            
            if (clearTrailToggle.isOn) _lissajousCurve.TrailRenderer.Clear();
        });
        YSlider.onValueChanged.AddListener(x =>
        {
            YCurrentSliderValue.text = x.ToString("0.0", CultureInfo.InvariantCulture);
            _lissajousCurve.B = x;
            
            if (clearTrailToggle.isOn) _lissajousCurve.TrailRenderer.Clear();
        });
        αSlider.onValueChanged.AddListener(x =>
        {
            αCurrentSliderValue.text = x.ToString("0.0", CultureInfo.InvariantCulture);
            _lissajousCurve.α = x;
            
            if (clearTrailToggle.isOn) _lissajousCurve.TrailRenderer.Clear();
        });
        βSlider.onValueChanged.AddListener(x => 
        {
            βCurrentSliderValue.text = x.ToString("0.0", CultureInfo.InvariantCulture);
            _lissajousCurve.β = x;
            
            if (clearTrailToggle.isOn) _lissajousCurve.TrailRenderer.Clear();

        });
        deltaSlider.onValueChanged.AddListener(x => 
        {
            deltaCurrentSliderValue.text = x.ToString("0.0", CultureInfo.InvariantCulture);
            _lissajousCurve.delta = x;
            
            if (clearTrailToggle.isOn) _lissajousCurve.TrailRenderer.Clear();
        });

        //VERSION
        version.text = $" VER. {Application.version}";
    }
}