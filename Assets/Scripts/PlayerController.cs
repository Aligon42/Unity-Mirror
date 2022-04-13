using UnityEngine;

// D�pendance avec PlayerMotor
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    [SerializeField] private float mouseSensitivityX = 30f;
    [SerializeField] private float mouseSensitivityY = 15f;

    private PlayerMotor motor;

    private void Start()
    {
        // Assign� automatiquement
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        // Calculer lla v�locit� du mouvement de notre joueur
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);

        // On calcule la rotation du joueur en Vector3 
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0, yRot, 0) * mouseSensitivityX;

        motor.Rotate(rotation);

        // On calcule la rotation de la cam�ra en Vector3 
        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0, 0) * mouseSensitivityY;

        motor.RotateCamera(cameraRotation);
    }
}
