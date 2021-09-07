using System;
using UnityEngine;

namespace WallToggling
{
    public class WallToggle : MonoBehaviour
    {
        [Header("Visual")]
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] Sprite onSprite;
        [SerializeField] Sprite offSprite;

        [Header("Setings")]
        [SerializeField] private float reenableDelay;
        [SerializeField] private Wall[] walls;
        
        private const string PlayerTag = "Player";
        private const string EnemyTag = "Enemy";
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (ShouldInteractWith(other))
            {
                DisableWalls();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (ShouldInteractWith(other))
            {
                Invoke(nameof(EnableWalls), reenableDelay);
            }
        }

        private void DisableWalls()
        {
            foreach (Wall wall in walls)
            {
                wall.Disable();
            }
        }

        private void EnableWalls()
        {
            foreach (Wall wall in walls)
            {
                wall.Enable();
            }
        }

        private bool ShouldInteractWith(Component other)
        {
            return other.CompareTag(PlayerTag) || other.CompareTag(EnemyTag);
        }
    }
}