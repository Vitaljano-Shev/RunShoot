using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health info")]
    [SerializeField] private Image _healthImageUI;
    [SerializeField] private float _maxHeath, _currentHealth;
    [SerializeField] private float _regenerateHealthAmount, _regenerateHealthTimer;

    [Header("Damage Info")]
    [SerializeField] private float _damageResistanceTimer;

    private int _currentSceneIndex;
    private bool _canTakeDamage = true, _canRegenerateHealth = false;
    private Coroutine _damageResistanceTimerCoroutine, _regenerateHealthTimerCoroutine;


    private void Start()
    {
        _currentHealth = _maxHeath;
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void FixedUpdate()
    {
        if (_canRegenerateHealth)
        {
            _currentHealth += _regenerateHealthAmount;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHeath);
            RefreshHealthUI();
        } 
    }

    public void DealDamage(float damage)
    {
        if (_canTakeDamage)
        {
            _currentHealth -= damage;
            RefreshHealthUI();
            if (_currentHealth <= 0)
            {
                SceneManager.LoadSceneAsync(_currentSceneIndex);
            }
            
            _canTakeDamage = false;
            _damageResistanceTimerCoroutine = StartCoroutine(DamageResistanceTimerCoroutine(_damageResistanceTimer));

        }

        _canRegenerateHealth = false;
        _regenerateHealthTimerCoroutine = StartCoroutine(RegenerateHealthTimerCoroutine(_regenerateHealthTimer));
    
    }

    private IEnumerator DamageResistanceTimerCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        _canTakeDamage = true;
    }

    private IEnumerator RegenerateHealthTimerCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        _canRegenerateHealth = true;
    }

    private void RefreshHealthUI()
    {
        _healthImageUI.fillAmount = _currentHealth/_maxHeath;
    }

}
