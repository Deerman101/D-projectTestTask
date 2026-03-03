using UnityEngine;
using Zenject;
using System.Collections.Generic;

/* Доп. пояснение изменений и преимуществ DI подхода см. в GameManager.cs */

// Интерфейс для реализации игрока
interface IPlayer
{
    int Health { get; set; }
    int Lives { get; set; }
    string Nickname { get; set; }
    string[] Skills { get; set; }
    IEquipment Equipment { get; }
    void InitializePlayer();
}

// Класс игрока, реализующий интерфейс (расширяем через  интерфейс)
public class Player : IPlayer
{
    public int Health { get; set; }
    public int Lives { get; set; }
    public string Nickname { get; set; }
    public string[] Skills { get; set; }
    public IEquipment Equipment { get; private set; }

    // Конструктор с DI
    [Inject]
    public Player(IEquipment equipment)
    {
        Equipment = equipment;
    }

    public void InitializePlayer()
    {
        Health = 100;
        Lives = 3;
        Nickname = "Джон";
        Skills = new string[] { "Удар ножом", "Одиночный выстрел", "Пробежка" };
        // Экипировка инжектируется через DI
    }
}

// Интерфейс экипировки
public interface IEquipment
{
    void AddItem(IItem item);
}

// Реализация экипировки
public class Equipment : IEquipment
{
    private List<IItem> items = new List<IItem>();

    public void AddItem(IItem item)
    {
        items.Add(item);
    }
}

// Интерфейс предметов
public interface IItem
{
    string Name { get; }
}

// Оружие
public class Weapon : IItem
{
    public string Name { get; }
    public int Ammo { get; set; }

    public Weapon(string name, int ammo)
    {
        Name = name;
        Ammo = ammo;
    }
}

// Парашют
public class Parachute : IItem
{
    public string Name { get; } = "Parachute";
}

// Ракетный ранец
public class RocketPack : IItem
{
    public string Name { get; } = "RocketPack";
    public int Charges { get; set; }

    public RocketPack(int charges)
    {
        Charges = charges;
    }
}