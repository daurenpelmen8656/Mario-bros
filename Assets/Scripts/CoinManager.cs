using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int geld; // Переменная для хранения количества денег (монет)
    public Text money; // UI текст для отображения количества денег

    // Метод Start вызывается один раз при инициализации
    void Start()
    {
        geld = PlayerPrefs.GetInt("Money", 0); // Получаем сохраненное значение денег из PlayerPrefs, если его нет, то значение по умолчанию - 0
    }

    // Метод Update вызывается каждый кадр
    void Update()
    {
        money.text = PlayerPrefs.GetInt("Money", 0).ToString(); // Обновляем текст UI с текущим значением денег из PlayerPrefs
    }

    // Метод для добавления денег (монет)
    public void Addmoney()
    {
        geld++; // Увеличиваем количество денег на 1
        PlayerPrefs.SetInt("Money", geld); // Сохраняем обновленное количество денег в PlayerPrefs
    }
}
