using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    // Инъекции через Zenject
    [Inject]
    private IPlayer _player; 
    [Inject(Id = "Weapon")]
    private IItem _weapon; 
    [Inject(Id = "Parachute")]
    private IItem _parachute;
    [Inject(Id = "RocketPack")]
    private IItem _rocketPack;

    void Start()
    {
        // Реализация через интерфейс
        _player.InitializePlayer();

        // Добавление экипировки (параметры заданы в "рантайме" через DI)
        _player.Equipment.AddItem(_weapon);
        _player.Equipment.AddItem(_parachute);
        _player.Equipment.AddItem(_rocketPack);

        // Демонстрация
        Debug.Log($"Здоровье игрока: {_player.Health}");
        Debug.Log($"Никнейм игрока: {_player.Nickname}");
        Debug.Log($"Оружие: {_weapon.Name}, Патроны: {((Weapon)_weapon).Ammo}");
        Debug.Log($"Ракетный ранец: {_rocketPack.Name}, Заряды: {((RocketPack)_rocketPack).Charges}");

        UpdatePlayerHealth(20);
    }

    // Метод для изменения атрибута из "другой части программы" (легко изменяемо на любой другой)
    public void UpdatePlayerHealth(int newHealth)
    {
        _player.Health = newHealth;
        Debug.Log($"Обновленное здоровье: {_player.Health}");
    }
}

/* 
 * Итак, по-итогу: избавился от синглтона, вместо него теперь модульный DI подход, class Player реализован через интерфейс, SOLID соблюдён, вывод результатов реализвоал,
 * показал также, что можно менять свойства игрока в "рантайме". Все задания вроде как выполнены.
 * Преимущества: 
 *   1. можно легко масштабировать, не создавая макаронный код;
 *   2. можно нормально тестировать через mock;
 *   3. отсутствие статики;
 *   4. параметры экипровки можно легко менять в "рантайме". И легко создавать новые элементы экипировки.
 */