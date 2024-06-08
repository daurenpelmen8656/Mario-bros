using UnityEngine;

public class Strelbaboy : MonoBehaviour
{
    public GameObject laserPrefab; // ������ ������
    public Transform firePoint; // �����, ������ ����� �������� �����
    public float fireRate = 2f; // �������� �������� (�������� � �������)
    public float triggerPositionX = 0f; // ������� �� ��� X, ����� ����������� ������� ���� ������ ��������
    public float triggerPositionY = 0f; // ������� �� ��� Y, ����� ����������� ������� ���� ������ ��������

    private float nextFireTime = 0f;
    private bool canShoot = false;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player has the tag 'Player'.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // ���������, ������� �� ����� ��������� ����������
            if (player.position.x > triggerPositionX && player.position.y > triggerPositionY)
            {
                if (!canShoot)
                {
                    Debug.Log("Player has crossed the trigger positions. CanShoot is now true.");
                }
                canShoot = true;
            }
            else
            {
                if (canShoot)
                {
                    Debug.Log("Player has not crossed the trigger positions. CanShoot is now false.");
                }
                canShoot = false;
            }
        }

        // ��������, ���� ����� �������� � ����� ��������
        if (canShoot && Time.time >= nextFireTime)
        {
            Debug.Log("Shooting laser!");
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        if (laserPrefab != null)
        {
            Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
            Debug.Log("Laser instantiated at: " + firePoint.position);
        }
        else
        {
            Debug.LogError("Laser prefab is null! Make sure you have assigned the laser prefab in the inspector.");
        }
    }
}
