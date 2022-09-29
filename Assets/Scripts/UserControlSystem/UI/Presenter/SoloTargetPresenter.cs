using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoloTargetPresenter : MonoBehaviour, ITargetInfo
{
    [SerializeField] ISelectable _target;

    [SerializeField] TextMeshProUGUI _targetName;
    [SerializeField] Image _targetImage;
    [SerializeField] TextMeshProUGUI _targetHP;
    [SerializeField] Image _healthBgr;
    [SerializeField] Image _healthFill;

    public void SetTarget(ISelectable target)
    {
        _target = target;

        UpdateInfo();
    }

    public void UpdateInfo()
    {
        if (_target.Health <= 0)
        {
            _target = null;
            gameObject.SetActive(false);
            return;
        }

        _targetName.text = _target.ObjectName;
        _targetImage.sprite = _target.Icon;
        _healthFill.rectTransform.localScale = new Vector3(_target.Health / _target.MaxHealth, 1, 1);
        _targetHP.text = $"{_target.Health}/{_target.MaxHealth}";
        Color color = Color.Lerp(Color.red, Color.green, _target.Health / _target.MaxHealth);
        _healthBgr.color = color * 0.5f;
        _healthFill.color = color;
    }
}