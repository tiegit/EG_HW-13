using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private float _distanceToCollect = 2f;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private ExperienceManager _experienceManager;

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _distanceToCollect, _layerMask, QueryTriggerInteraction.Ignore);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent(out Loot loot))
            {
                loot.Collect(this );
            }
        }
    }

    public void TakeExperience(int value)
    {
        _experienceManager.AddExperience(value);
    }
}
