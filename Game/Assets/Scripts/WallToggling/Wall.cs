using System;
using UnityEngine;

namespace WallToggling
{
    public class Wall : MonoBehaviour
    {

        

        private Collider2D collider;
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField] Sprite onSprite;
        [SerializeField] Sprite offSprite;


        private void Start()
        {
            collider = GetComponent<Collider2D>();
            if (spriteRenderer == null)
            {
                spriteRenderer = GetComponent<SpriteRenderer>();
            }
        }

        public void Disable()
        {
            ToggleCollision(false);
            spriteRenderer.sprite = offSprite;
        }

        public void Enable()
        {
            ToggleCollision(true);
            spriteRenderer.sprite = onSprite;
        }

        private void ToggleCollision(bool state)
        {
            collider.enabled = state;
        }
    }
}