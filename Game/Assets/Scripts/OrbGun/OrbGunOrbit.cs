using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbGunOrbit : MonoBehaviour
{
    [Header("Runtime")]
    public float roatateSpeed=-2;


    [Header("Setup")]
    [SerializeField] private GameObject orbSlotPrefab;
    [Range(0,360)]
    public float angleBeetwen=24;
    public float orbitRadius=1.5f;
    public bool setupClockwise=true;

    public bool isHSVclockwise=true;
    public Color baseColor=Color.red;



    private void FixedUpdate()
    {
        transform.Rotate(0, 0, roatateSpeed);
    }


    public void ClearSlots()
    {
        while (transform.childCount > 0)
        {
            var child = transform.GetChild(0);
            child.parent = null;
            DestroyImmediate(child.gameObject);
        }
    }
    private OrbSlot setupSlot(int index)
    {
        Vector3 position = Vector3.right*orbitRadius;

        Quaternion rot= Quaternion.AngleAxis(angleBeetwen * index, setupClockwise?Vector3.forward:Vector3.back);
        position = transform.rotation * rot * position;


        GameObject go= Instantiate(orbSlotPrefab, position + transform.position, Quaternion.identity, transform);
        OrbSlot slot = go.GetComponent<OrbSlot>();

        slot.SetupBaseColor(baseColor, (index * angleBeetwen) / 360, isHSVclockwise);
        return slot;
    }

    
    
    public IEnumerable<OrbSlot> setupSlots(int count)
    {

        if (orbSlotPrefab?.GetComponent<OrbSlot>() == null)
        {
            Debug.LogWarning("orbSlotPrefab is not asigned with an orb slot");
            yield break;
        }

        ClearSlots();
        for(int i = 0; i < count; i++)
        {
            yield return setupSlot(i);
        }
    }

    public OrbSlot AddOrbSlot()
    {
        return setupSlot(transform.childCount);
    }

    public void RemoveOrbSlot()
    {
        if (transform.childCount > 0)
        {
            Transform child = transform.GetChild(transform.childCount - 1);
            child.parent = null;
            DestroyImmediate(child.gameObject);
        }
    }



    [ContextMenu("Setup 3 Slots")]
    private void  setup3()
    {
        setupSlots(3);
    }

    [ContextMenu("Clear Slots")]
    private void menuClearSlots()
    {
        ClearSlots();
    }




    [ContextMenu("Add Orb Slot")]
    private void menuAddOrbSlot()
    {
        AddOrbSlot();
    }
    [ContextMenu("Remove Orb Slot")]
    private void menuRemoveOrbSlot()
    {
        RemoveOrbSlot();
    }


}
