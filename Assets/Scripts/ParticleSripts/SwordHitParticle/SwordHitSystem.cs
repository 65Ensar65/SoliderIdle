using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitSystem : Base
{
    public void GetActiveParticle()
    {
        e_objectPool.ActivePoolObject(ObjectTag.SwordParticle, transform);
    }

    public void GetReturnParticle()
    {
        e_objectPool.ReturnPoolObject(ObjectTag.SwordParticle, gameObject);
    }
}
