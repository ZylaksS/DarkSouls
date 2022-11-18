using Game.Core;

namespace DarkSouls.Initializers
{
    public class GameSceneInitializer : SceneInitializer
    {
        [Inject] private InputHandler inputHandler;

        protected override void Awake()
        {
            this.Inject();
            base.Awake();
        }

        private void OnEnable()
        {
            inputHandler.Enable();
        }

        private void OnDisable()
        {
            inputHandler.Disable();
        }

        private void Update()
        {
            inputHandler.Tick();
        }
    }
}