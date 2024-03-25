using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarHUDBehaviour : MonoBehaviour
{
    [SerializeField]
    private RawImage _healthBarFG;


    [SerializeField]
    private HealthBehaviour _healthBehaviour;

    private float _maxHealth = 0;
    [SerializeField]
    private Gradient _healthBarGradient;

    [SerializeField]
    private TextMeshProUGUI _healthBarText;
    private void Start()
    {
        Debug.Assert(_healthBarFG);
        Debug.Assert(_healthBehaviour);
        _maxHealth = _healthBehaviour.MaxHealth;
    }
    private void Update()
    {
        if (_healthBarFG == null || _healthBehaviour == null)
        {
            return;
        }
        float health = _healthBehaviour.Health;
        // Min of 1 to ensure no dividing by zero or negative numbers
        float maxHealth = Mathf.Max(1,_healthBehaviour.MaxHealth);
        // Get health as value between 0 & 1
        float healthPercentage = Mathf.Clamp01(health / maxHealth);
        // Set health bar scale
        Vector3 newScale = _healthBarFG.rectTransform.localScale;
        newScale.x = healthPercentage;
        _healthBarFG.rectTransform.localScale = newScale;

        // Set health bar color
        _healthBarFG.color = _healthBarGradient.Evaluate(healthPercentage);
        _healthBarText.color = _healthBarFG.color;
    }
}
