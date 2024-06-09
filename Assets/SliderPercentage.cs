using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderPercentage : MonoBehaviour
{
    public Slider slider; // Ссылка на слайдер
    public Text percentageText;

    void Start()
    {
        // Проверка наличия ссылок
        if (slider == null)
        {
            Debug.LogError("Ссылка на слайдер не установлена!");
            return;
        }

        if (percentageText == null)
        {
            Debug.LogError("Ссылка на текст не установлена!");
            return;
        }

        // Убедитесь, что начальное значение текста правильное
        UpdatePercentageText(slider.value);

        // Добавляем слушателя для обновления текста при изменении значения слайдера
        slider.onValueChanged.AddListener(UpdatePercentageText);
    }

    void UpdatePercentageText(float value)
    {
        // Проверка наличия ссылки перед обновлением текста
        if (percentageText != null)
        {
            percentageText.text = Mathf.RoundToInt(value * 100) + "%";
        }
        else
        {
            Debug.LogError("Ссылка на текст отсутствует при обновлении текста!");
        }
    }

    void OnDestroy()
    {
        // Убираем слушателя при уничтожении объекта
        if (slider != null)
        {
            slider.onValueChanged.RemoveListener(UpdatePercentageText);
        }
    }
}
