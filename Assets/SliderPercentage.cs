using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderPercentage : MonoBehaviour
{
    public Slider slider; // ������ �� �������
    public Text percentageText;

    void Start()
    {
        // �������� ������� ������
        if (slider == null)
        {
            Debug.LogError("������ �� ������� �� �����������!");
            return;
        }

        if (percentageText == null)
        {
            Debug.LogError("������ �� ����� �� �����������!");
            return;
        }

        // ���������, ��� ��������� �������� ������ ����������
        UpdatePercentageText(slider.value);

        // ��������� ��������� ��� ���������� ������ ��� ��������� �������� ��������
        slider.onValueChanged.AddListener(UpdatePercentageText);
    }

    void UpdatePercentageText(float value)
    {
        // �������� ������� ������ ����� ����������� ������
        if (percentageText != null)
        {
            percentageText.text = Mathf.RoundToInt(value * 100) + "%";
        }
        else
        {
            Debug.LogError("������ �� ����� ����������� ��� ���������� ������!");
        }
    }

    void OnDestroy()
    {
        // ������� ��������� ��� ����������� �������
        if (slider != null)
        {
            slider.onValueChanged.RemoveListener(UpdatePercentageText);
        }
    }
}
