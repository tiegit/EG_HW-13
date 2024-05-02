using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private GameObject _cardManagerParent;
    [SerializeField] private Card[] _effectCards;

    [SerializeField] private EffectsManager _effectsManager;

    private void Awake()
    {
        for (int i = 0; i < _effectCards.Length; i++)
        {
            _effectCards[i].Initialize(_effectsManager, this);
        }
    }

    private void Start()
    {
        Hide();
    }

    public void ShowCards(List<Effect> effects)
    {
        _cardManagerParent.SetActive(true);

        for (int i = 0; i < effects.Count; i++)
        {
            _effectCards[i].Show(effects[i]);
        }
    }

    public void Hide()
    {
        _cardManagerParent.SetActive(false);
    }
}
