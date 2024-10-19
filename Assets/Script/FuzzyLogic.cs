using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FuzzyLogic : MonoBehaviour
{
    public Slider healthbar;
    public TextMeshProUGUI healthValue;
    // Array of HealthStates
    [SerializeField]
    private HealthState[] healthStates;
    // We use a dictionary to properly identify the HealthState based on an enum
    private Dictionary<HealthStateEnum, HealthState> healthStateMap;

    private void Start()
    {
        UpdateHealth(100);
        healthStateMap = new();
        foreach (var state in healthStates)
        {
            healthStateMap.Add(state.HealthStateEnum, state);
        }
    }

    private void Update()
    {
        CastSpell();
    }

    
    public void UpdateHealth(float value)
    {
        healthValue.text = value.ToString("00.00");
        healthbar.value = value;
        // Perform the evaluation of the fuzzy logic here
        foreach (var state in healthStates)
        {
            state.Evaluate(value);
        }
    }

    private void CastSpell()
    {
        // We use boolean logic to perform specific actions based
        // on the evaluation of the fuzzy logic
        float critical = healthStateMap[HealthStateEnum.Critical].CurrentValue;
        float hurt = healthStateMap[HealthStateEnum.Hurt].CurrentValue;
        // Basically translates to "if we're more critical than hurt, heal"
        if (critical > hurt)
        {
            Debug.Log("Cast healing spell");
        }
        // You can also use something like: 
        // if(critical >= 0.80f)
        // for checking a "very" critical moment
    }
}
