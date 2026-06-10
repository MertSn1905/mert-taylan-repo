using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 300f; // Mouse hassasiyetimiz

    public Transform camTarget; // Kameranýn baktýðý hedefi buraya atayacaðýz
    private float xRotation = 0f; // Yukarý/aþaðý bakma açýmýz

    private Animator anim;
    private CharacterController controller;
    public GameManager gameManager;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        // Mouse imlecini oyun ekranýna kilitle ve gizle (Ekranda görünmesin)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // 1. MOUSE ÝLE ETRAFA BAKMA (NÝÞAN ALMA)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Saða/Sola fare hareketi karakterin tamamýný döndürür
        transform.Rotate(Vector3.up * mouseX);

        // Yukarý/Aþaðý fare hareketi sadece kameranýn hedefini (kafayý) döndürür
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -60f, 60f); // Kafayý fazla geriye kýrmasýn diye sýnýr
        camTarget.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 2. HAREKET SÝSTEMÝ (W,A,S,D ile tam yönlü hareket)
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Hem ileri/geri hem saða/sola yürüme
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move.normalized * speed * Time.deltaTime);

        // Yerçekimi
        if (!controller.isGrounded)
        {
            controller.Move(Vector3.down * 9.81f * Time.deltaTime);
        }

        // 3. ANÝMASYON
        if (x != 0 || z != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        // 4. ATEÞ ETME (Sol Týk)
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f))
        {
            Debug.Log("Vurulan Obje: " + hit.collider.gameObject.name);

            if (hit.collider.gameObject.name.Contains("Sphere") || hit.collider.CompareTag("Target"))
            {
                gameManager.WinGame();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameManager.LoseGame();
        }
    }
}
