using UnityEngine;

public class ExperienceLoot : Loot
{
    [SerializeField] private int _experienceValue = 1;

    public override void Take(Collector collector)
    {
        base.Take(collector);

        collector.TakeExperience(_experienceValue);
    }
}
