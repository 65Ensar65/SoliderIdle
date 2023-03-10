using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUpgradeController : ISpawnUpgradable
{
    private float repeating;
    public void GetSpawnUpgradeController()
    {
        repeating -= 0.05f;
    }

    public void SetSpawnUpgradeParameters(ObjectSpawnController repeating)
    {
        this.repeating = repeating.Repeating;
    }
}
