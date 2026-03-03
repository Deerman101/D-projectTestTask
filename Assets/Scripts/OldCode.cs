//using System;
//using System.Collections.Generic;
//using UnityEngine;

//public class OldCode : MonoBehaviour
//{
//    void Start()
//    {
//        Player player = Player.Instance; // Получаем экземпляр класса Player
              
//        // Инициализируем игрока
//        player.Health = 100;
//        player.Lives = 3;
//        player.Nickname = "John";
//        player.Skills = new string[] { "Skill1", "Skill2", "Skill3" };
//        player.Equipment = new Equipment();
//        Debug.Log("Здоровье игрока: " + player.Health);
//        Debug.Log("Никнейм игрока: " + player.Nickname);
//        Equipment equipment = player.Equipment;

//        ((IEquipment)equipment).AddItem(new Weapon("Винтовка", 50));
//        ((IEquipment)equipment).AddItem(new Parachute());
//        ((IEquipment)equipment).AddItem(new RocketPack(3)); // Ракетный ранец с 3 зарядами
//        Console.ReadKey();
//    }
//}


//// Класс игрока
//public class Player
//{
//    private static Player _instance;
//    public int Health { get; set; }
//    public int Lives { get; set; }
//    public string Nickname { get; set; }
//    // Таблица навыков
//    public string[] Skills { get; set; }
//    // Экипировка
//    public Equipment Equipment { get; /*private*/ set; }
//    public Player()
//    {
//        _instance = this;
//    }
//    public static Player Instance
//    {
//        get
//        {
//            if (_instance == null)
//            {
//                _instance = new Player();
//            }
//            return _instance;
//        }
//    }
//}

//// Интерфейс для экипировки
//interface IEquipment
//{
//    void AddItem(Item item);
//}
//// Реализация экипировки
//public class Equipment : IEquipment
//{
//    List<Item> items = new List<Item>();
//    void IEquipment.AddItem(Item item)
//    {
//        items.Add(item);
//    }
//}
//// Предмет экипировки
//abstract class Item
//{
//    protected string name;
//    public Item(string name)
//    {
//        this.name = name;
//    }
//}
//// Оружие
//class Weapon : Item
//{
//    int ammo;
//    public Weapon(string name, int ammo) : base(name)
//    {
//        this.ammo = ammo;
//    }
//}
//// Парашют
//class Parachute : Item
//{
//    public Parachute() : base("Parachute")
//    {
//    }
//}
//// Ракетный ранец
//class RocketPack : Item
//{
//    int charges;
//    public RocketPack(int charges) : base("RocketPack")
//    {
//        this.charges = charges;
//    }
//}