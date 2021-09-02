using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Identifier : MonoBehaviour
{
    [SerializeField] Identity identity;

    public virtual Identity Identity { get => identity; }

}
