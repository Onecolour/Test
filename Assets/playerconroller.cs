using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Скорость движения персонажа
    public float sensitivity = 2f; // Чувствительность мыши

    private Rigidbody rb; // Ссылка на компонент Rigidbody
    private Transform cameraTransform; // Ссылка на камеру
    private float rotationX = 0f; // Угол поворота по оси X (вверх/вниз)

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;

        // Блокируем и скрываем курсор
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Получение ввода мыши
        float mouseX = Input.GetAxis("Mouse X") * sensitivity; // Горизонтальный поворот
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity; // Вертикальный поворот

        // Управление поворотом персонажа по горизонтали
        transform.Rotate(0, mouseX, 0);

        // Управление поворотом камеры по вертикали
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Ограничиваем угол обзора вверх/вниз
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        // Движение персонажа
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * moveVertical + transform.right * moveHorizontal;
        rb.velocity = movement * speed + new Vector3(0, rb.velocity.y, 0);
    }
}
