using System.Collections;
using UnityEngine;

public abstract class Loot : MonoBehaviour
{
    [SerializeField] private float _lootJumpHight = 3f;
    [SerializeField] private float _speedModifier = 0.3f;

    private Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    public void Collect(Collector collector)
    {
        _collider.enabled = false;

        StartCoroutine(MoveToCollectorCoroutine(collector));
    }

    private IEnumerator MoveToCollectorCoroutine(Collector collector)
    {
        Vector3 a = transform.position;
        Vector3 b = a + Vector3.up * _lootJumpHight;

        for (float t = 0; t < 1f; t += Time.deltaTime / _speedModifier)
        {
            Vector3 d = collector.transform.position;
            Vector3 c = d + Vector3.up * _lootJumpHight;

            Vector3 position = Bezier.GetPoint(a, b, c, d, t);

            transform.position = position;

            yield return null;
        }

        Take(collector);
    }

    public virtual void Take(Collector collector)
    {
        Destroy(gameObject);
    }
}