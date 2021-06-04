using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class OrbGun : MonoBehaviour
{
    [Header("Settings")]
    public int MaxOrbCount = 3;
    public int SlotCount=15;
    public float OrbRespawnCooldown=1.5f;
    public float OrbShootStrength = 6;


    [Header("Refrences")]
    [SerializeField]private GameObject orbPrefab;
    [SerializeField] OrbGunOrbit orbit;
    [SerializeField] Transform orbShootSource;
    
    private List<OrbSlot> slots;

    private Queue<Orb> orbs;


    private bool canSpawnOrb()
    {
        return orbs.Count < slots.Count && orbs.Count < MaxOrbCount;
    }

    private float lastCreateTimestamp;
    private void Update()
    {
        if (canSpawnOrb())
        {
            if(lastCreateTimestamp+ OrbRespawnCooldown < Time.time)
            {
                CreateAndEnqueueOrb();
                lastCreateTimestamp = Time.time;
            }
        }
    }



    void Awake()
    {
        slots = new List<OrbSlot>();
        orbs = new Queue<Orb>();

        if (orbit == null)
        {
            orbit = GetComponentInChildren<OrbGunOrbit>();
        }
        if (orbit == null)
        {
            Debug.LogWarning($"No {nameof(OrbGunOrbit)} component");
            enabled = false;
        }

    }

    
    public int GetSlotCount()
    {
        return slots.Count;
    }

    private void OnEnable()
    {
        Setup();
    }
    private void OnDisable()
    {
        CleanUp();
    }

    private void Setup()
    {
        orbit.transform.rotation = Quaternion.identity;
        AddOrbSlots(SlotCount);
    }

    private void CleanUp()
    {
        slots.Clear();
        orbit.ClearSlots();
    }

    public void AddOrbSlots(int count)
    {
        slots.AddRange(orbit.setupSlots(count));
    }

    public OrbSlot AddOrbSlot()
    {
        var  slot =orbit.AddOrbSlot();
        slots.Add(slot);
        return slot;
    }


    
    public Orb CreateAndEnqueueOrb()
    {
        if (canSpawnOrb()==false) { return null; }

        if (orbPrefab?.GetComponent<Orb>() == null) {

            Debug.LogWarning($"Orb prefab has no {nameof(Orb)} component");
            return null;
        }


        IEnumerable<OrbSlot> filterSlots = slots.Where((s) => { return s.LinkedOrb == null; });
        
        OrbSlot slot= filterSlots.ElementAt(Random.Range(0, filterSlots.Count()));

        GameObject orbGO =Instantiate(orbPrefab, slot.transform.position, Quaternion.identity);
        Orb orb = orbGO.GetComponent<Orb>();

        orb.SubscribeToOrbslot(slot);

        orbs.Enqueue(orb);

        return orb;
    }

    
    public Orb DequeueFirsOrb()
    {
        if (orbs.Count == 0) { return null; }

        Orb orb = orbs.Dequeue();

        return orb;

    }

    private void ShotOrb(Orb orb)
    {
        orb.StartShoot(orbShootSource, OrbShootStrength);
    }


    public void ShootOrb()
    {
        var orb = DequeueFirsOrb();
        if (orb != null)
        {
            ShotOrb(orb);
        }
        
    }




}
