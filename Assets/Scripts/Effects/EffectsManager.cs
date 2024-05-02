using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    [SerializeField] private List<ContinuousEffect> _continuousEffectsApplied = new List<ContinuousEffect>();
    [SerializeField] private List<OneTimeEffect> _oneTimeEffectsApplied = new List<OneTimeEffect>();

    [SerializeField] private List<ContinuousEffect> _continuousEffects = new List<ContinuousEffect>();
    [SerializeField] private List<OneTimeEffect> _oneTimeEffects = new List<OneTimeEffect>();

    [SerializeField] private CardManager _cardManager;

    private void Awake()
    {
        for (int i = 0; i < _continuousEffects.Count; i++)
        {
            _continuousEffects[i] = Instantiate(_continuousEffects[i]);
        }
        for (int i = 0; i < _oneTimeEffects.Count; i++)
        {
            _oneTimeEffects[i] = Instantiate(_oneTimeEffects[i]);
        }
    }

    [ContextMenu("ShowCards")]
    public void ShowCards()
    {
        List<Effect> effectsToShow = new List<Effect>();

        for (int i = 0; i < _continuousEffectsApplied.Count; i++)
        {
            if (_continuousEffectsApplied[i].Level < 10)
            {
                effectsToShow.Add(_continuousEffectsApplied[i]);
            }
        }

        for (int i = 0; i < _oneTimeEffectsApplied.Count; i++)
        {
            if (_oneTimeEffectsApplied[i].Level < 10)
            {
                effectsToShow.Add(_oneTimeEffectsApplied[i]);
            }
        }

        if (_continuousEffectsApplied.Count < 4)
        {
            effectsToShow.AddRange(_continuousEffects);
        }

        if (_oneTimeEffectsApplied.Count < 4)
        {
            effectsToShow.AddRange(_oneTimeEffects);
        }

        int numberOfCardsToShow = Mathf.Min(effectsToShow.Count, 3);

        int[] randomIndexes = RandomSort(effectsToShow.Count, numberOfCardsToShow);
        List<Effect> effectsForCards = new List<Effect>();

        for (int i = 0; i < randomIndexes.Length; i++)
        {
            int index = randomIndexes[i];
            effectsForCards.Add(effectsToShow[index]);
        }

        _cardManager.ShowCards(effectsForCards);
    }

    private int[] RandomSort(int length, int number)
    {
        int[] array = new int[length];
        int[] result = new int[number];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }

        for (int i = 0; i < array.Length; i++)
        {
            int oladValue = array[i];
            int newIndex = Random.Range(0, array.Length);
            array[i] = array[newIndex];
            array[newIndex] = oladValue;
        }

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = array[i];
        }

        return result;
    }

    public void AddEffect(Effect effect)
    {
        if (effect is ContinuousEffect c_effect)
        {
            if (!_continuousEffectsApplied.Contains(c_effect))
            {
                _continuousEffectsApplied.Add(c_effect);
                _continuousEffects.Remove(c_effect);
            }
        }
        else if (effect is OneTimeEffect o_effect)
        {
            if (!_oneTimeEffectsApplied.Contains(o_effect))
            {
                _oneTimeEffectsApplied.Add(o_effect);
                _oneTimeEffects.Remove(o_effect);
            }
        }

        effect.Activate();

        Time.timeScale = 1;
    }
}
