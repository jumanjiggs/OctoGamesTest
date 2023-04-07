using Zenject;

namespace CodeBase.Services
{
    public class RegisterGameControl : MonoInstaller
    {
        public GameControl GameControl;

        public override void InstallBindings()
        {
            var gameControl = Container.InstantiatePrefabForComponent<GameControl>(GameControl);
            Container.Bind<GameControl>().FromInstance(gameControl).AsSingle().NonLazy();
        }
    }
}