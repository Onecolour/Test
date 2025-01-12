using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSound : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    private AudioSource audioSource;

    public float maxDistance = 10f; // Максимальное расстояние звука
    public float minDistance = 1f;  // Минимальное расстояние для максимальной громкости

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < maxDistance)
        {
            // Рассчитываем громкость в зависимости от расстояния
            float volume = 1 - Mathf.Clamp01((distance - minDistance) / (maxDistance - minDistance));
            audioSource.volume = volume; // Устанавливаем громкость
        }
        else
        {
            audioSource.volume = 0; // За пределами maxDistance звук отключается
        }
    }
}

