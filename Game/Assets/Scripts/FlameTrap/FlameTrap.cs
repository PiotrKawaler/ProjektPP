using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum FlameStateEnum
{
    Hidden = 0,
    Spark = 1,
    Flame = 2,
}


public class FlameTrap : MonoBehaviour,IDamageSource
{
    [Header("Transforms")]
    [SerializeField] Transform damageSource;

    [Header("Refrences")]
    [SerializeField] Collider2D flameCollider;
    [SerializeField] Animator flameAnimator;
    [SerializeField] AgroController flameAgro;

    [Header("Settings")]
    [SerializeField] DamagePacket damagePacket;
    [SerializeField] float startOffset = 0;
    [SerializeField] float hiddenTime = 3;
    [SerializeField] float sparkTime = 1;
    [SerializeField] float flameTime = 1;


    private FlameStateEnum state;
    private float countdown;


    FlameStateEnum nextState(FlameStateEnum state)
    {
        return (FlameStateEnum)(((int)state + 1) % 3);
    }

    private void Awake()
    {
        countdown = startOffset;

        if (flameCollider==null || flameAnimator == null)
        {
            this.enabled = false;
            Debug.LogWarning($"Missing refrences {nameof(FlameTrap)}");
        }

        if (flameAgro)
        {
            flameAgro.onAggroEvent += OnFlameEnter;
        }

    }
    private void OnDestroy()
    {
        if (flameAgro)
        {
            flameAgro.onAggroEvent -= OnFlameEnter;
        }
    }


    void OnFlameEnter(GameObject target)
    {
        var damageReciver=  target.GetComponent<DamageRecieverBase>();

        damageReciver.ReciveDamage(damagePacket, this);

    }




    void onSetState(FlameStateEnum newState)
    {
        switch (newState)
        {
            case FlameStateEnum.Hidden:
                flameCollider.enabled = false;
                flameAnimator.SetInteger("FlameStateEnum", (int)newState);
                break;
            case FlameStateEnum.Spark:
                flameCollider.enabled = false;
                flameAnimator.SetInteger("FlameStateEnum", (int)newState);
                break;
            case FlameStateEnum.Flame:
                flameCollider.enabled = true;
                flameAnimator.SetInteger("FlameStateEnum", (int)newState);
                break;
            default:
                break;
        }
    }


    float getCountdown(FlameStateEnum state)
    {
        switch (state)
        {
            case FlameStateEnum.Hidden:
                return hiddenTime;
            case FlameStateEnum.Spark:
                return sparkTime;
            case FlameStateEnum.Flame:
                return flameTime;
            default:
                return 0;
        }
    }


    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            state = nextState(state);
            onSetState(state);
            countdown = getCountdown(state);
        }
    }

    public Vector2 GetDamagePosition()
    {
        return damageSource != null ? damageSource.position : transform.position;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
