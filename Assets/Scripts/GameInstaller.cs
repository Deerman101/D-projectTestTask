using UnityEngine;
using Zenject;

/* Доп. пояснение изменений и преимуществ DI подхода см. в GameManager.cs */

// Zenject Installer для регистрации зависимостей (контейнер IoC)
public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // Регистрация Player как AsSingle в контейнере
        Container.Bind<IPlayer>().To<Player>().AsSingle();

        // Регистрация Equipment
        Container.Bind<IEquipment>().To<Equipment>().AsTransient();

        // Регистрация предметы с параметрами
        Container.Bind<IItem>().WithId("Weapon").To<Weapon>().FromInstance(new Weapon("Винтовка", 50));
        Container.Bind<IItem>().WithId("Parachute").To<Parachute>().AsTransient();
        Container.Bind<IItem>().WithId("RocketPack").To<RocketPack>().FromInstance(new RocketPack(3));
    }
}
