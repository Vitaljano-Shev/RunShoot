using UnityEngine;
using UnityEngine.UI;

public class SimpleTimer : MonoBehaviour
{
    [Header("Bullet UI")]
    [SerializeField] private Image _fillAmountImage;

    private bool _startTimer = false;
    private float _timer,_currentTime;

    private void Start()
    {
        //gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_startTimer)
        {
            _currentTime -= Time.deltaTime;
            _currentTime = Mathf.Clamp(_currentTime, 0, _timer);
            RefreshUI();
        }
    }

    public void StartTimer(float timer, Color fillAmountImageColor)
    {
        _fillAmountImage.color = fillAmountImageColor;
        SetAndActivateTimer(timer);
    }

    public void StartTimer(float timer)
    {
        SetAndActivateTimer(timer);
    }

    private void SetAndActivateTimer(float timer)
    {
        _currentTime = timer;
        gameObject.SetActive(true);
        _timer = timer;
        _startTimer = true;
    }

    public void StopTimer()
    {
        _startTimer = false;
        gameObject.SetActive(false);
    }

    private void RefreshUI()
    {
        _fillAmountImage.fillAmount = _currentTime / _timer;
        if (_currentTime == 0) StopTimer();
    }

}
