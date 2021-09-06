using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSlot : RotationHsvSampler
{
    private Orb linkedOrb = null;
    public Orb LinkedOrb { get => linkedOrb; }
    
    public void LinkOrb(Orb orb)
    {
        linkedOrb = orb;
    }

    public void UnlinkOrb()
    {
        linkedOrb = null;
    }

    private void OnDestroy()
    {
        if (linkedOrb != null)
        {
            Orb orb = linkedOrb;
            linkedOrb.UnsubscribeFromOrbslot();
            Destroy(orb.gameObject);
        }
        
    }


}
