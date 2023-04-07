using Zenject;

namespace CodeBase.Services
{
    public class RegisterKillsCounter : MonoInstaller
    {
        public KillsCounter killsCounter;
        
        public override void InstallBindings() => 
            BindCounter();

        private void BindCounter() => 
            Container.Bind<KillsCounter>().FromInstance(killsCounter).AsSingle().NonLazy();
    }
}