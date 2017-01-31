using System.Collections;
using UnityEngine;

namespace Materials {
    public class ScrollingTexture : MonoBehaviour {
        public Material m_Texture;
        public Vector2 m_Direction;

        private Renderer m_Renderer;

        // TODO: Make a class that does this so other scripts can use it in the future
        private static ScrollingTexture m_Instance;

        void Awake() {
            if (m_Instance == null) {
                m_Instance = FindObjectOfType<ScrollingTexture>();
            } else {
                Destroy(this);
            }
        }
        // Note: How does the user know which script will get deleted (From testing it seems like it goes bottom->up from the hierarchy)
        // End of TODO

        void Start() {
            m_Renderer = GetComponent<Renderer>();
        }

        void Update() {
            OffsetTexture();
        }

        private void OffsetTexture() {
            m_Texture.mainTextureOffset += m_Direction / 100f; // Incase they put in 1 which will look like its not moving
            // Just resets it back to 0 so the material won't get absurbly large numbers in the offset
            if (m_Texture.mainTextureOffset.x >= 1) {
                m_Texture.mainTextureOffset = new Vector2(0, m_Texture.mainTextureOffset.y);
            }
            if (m_Texture.mainTextureOffset.y >= 1) {
                m_Texture.mainTextureOffset = new Vector2(m_Texture.mainTextureOffset.x, 0);
            }
        }
    }
}