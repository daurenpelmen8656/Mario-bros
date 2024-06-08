using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int geld; // ���������� ��� �������� ���������� ����� (�����)
    public Text money; // UI ����� ��� ����������� ���������� �����

    // ����� Start ���������� ���� ��� ��� �������������
    void Start()
    {
        // �������� ����������� �������� ����� �� PlayerPrefs, ���� ��� ���, �� �������� �� ��������� - 0
    }

    // ����� Update ���������� ������ ����
    void Update()
    {
        money.text = geld.ToString(); // ��������� ����� UI � ������� ��������� �����
    }

    // ����� ��� ���������� ����� (�����)
    public void Addmoney()
    {
        geld++; // ����������� ���������� ����� �� 1
        PlayerPrefs.SetInt("Money", geld); // ��������� ����������� ���������� ����� � PlayerPrefs
    }
}
