using System;
using UnityEngine;

namespace WallToggling
{
    public class Wall : MonoBehaviour
    {
        private Collider2D collider;

        private void Start()
        {
            collider = GetComponent<Collider2D>();
        }

        public void Disable()
        {
            ToggleCollision(false);
        }

        public void Enable()
        {
            ToggleCollision(true);
        }

        private void ToggleCollision(bool state)
        {
            collider.enabled = state;
        }
    }
}