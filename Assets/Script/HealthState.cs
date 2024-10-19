using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum HealthStateEnum
{
    Healthy,
    Hurt,
    Critical
}
public class HealthState : MonoBehaviour
{
    [SerializeField]
    private HealthStateEnum healthStateEnum;
    [SerializeField]
    private Image healthFill;
    [SerializeField]
    private TextMeshProUGUI healthText;
    [SerializeField]
    private AnimationCurve truthCurve;
    
    private float healthValue;
    private float _currentValue;

    public HealthStateEnum HealthStateEnum => healthStateEnum;
    public float CurrentValue => _currentValue;

    public void Evaluate(float value)
    {
        // Calling the Evaluate function of the animation curve will
        // return a value from 0-1
        // Take note that we set the animation curve's time to be 0-100
        _currentValue = truthCurve.Evaluate(value);
        // Set the fill
        healthFill.fillAmount = _currentValue;
        healthText.text = (_currentValue * 100f).ToString("00.00");
    }
}
