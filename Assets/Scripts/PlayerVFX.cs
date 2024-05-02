using UnityEngine;

public class PlayerVFX : MonoBehaviour
{
    [SerializeField] private GameObject _levelUpEffectPrefab;
    [SerializeField] private ExperienceManager _experienceManager;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = GetComponent<Transform>();
        _experienceManager.LevelUp += OnLevelUp;
    }

    private void OnLevelUp()
    {
        GameObject newVFX = Instantiate(_levelUpEffectPrefab, transform.position, transform.rotation, _playerTransform);

        Destroy(newVFX, 2);
    }

    private void OnDestroy()
    {
        _experienceManager.LevelUp -= OnLevelUp;
    }
}
