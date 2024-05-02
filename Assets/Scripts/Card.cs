using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private Image _iconBackground;
    [SerializeField] private Button _button;

    [SerializeField] private Sprite _continuousEffectSprite;
    [SerializeField] private Sprite _oneTimeEffectSprite;

    private EffectsManager _effectsManager;
    private CardManager _cardManager;

    private Effect _effect;

    public void Initialize(EffectsManager effectsManage, CardManager cardManager)
    {
        _effectsManager = effectsManage;
        _cardManager = cardManager;

        _button.onClick.AddListener(Click);
    }

    public void Show(Effect effect)
    {
        _effect = effect;

        _nameText.text = _effect.name;
        _descriptionText.text = _effect.Description;
        _iconImage.sprite = _effect.Sprite;
        _levelText.text = _effect.Level.ToString();

        if (effect is ContinuousEffect)
        {
            _iconBackground.sprite = _continuousEffectSprite;
        }
        else if (effect is OneTimeEffect)
        {
            _iconBackground.sprite = _oneTimeEffectSprite;
        }
    }

    private void Click()
    {
        _effectsManager.AddEffect(_effect);
        _cardManager.Hide();
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(Click);
    }
}
