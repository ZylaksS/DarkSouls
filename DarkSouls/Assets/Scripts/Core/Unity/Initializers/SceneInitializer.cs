using UnityEngine;

namespace Game.Core
{
    public class SceneInitializer : MonoBehaviour
    {
        [SerializeField] private CompositeRoot[] compositeRoots;
        
        protected virtual void Awake()
        {
            ComposeCompositeRoots();
        }
        
        private void ComposeCompositeRoots()
        {
            foreach (CompositeRoot compositeRoot in compositeRoots)
            {
                compositeRoot.Compose();
            }
        }
    }
}
