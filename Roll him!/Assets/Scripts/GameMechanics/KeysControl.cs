using UnityEngine;
using UnityEngine.SceneManagement;

public class KeysControl : MonoBehaviour
{
    [Header("- - - - - - Vector3 - - - - - -")]
    [SerializeField] private Vector3 moveDirection;

    [Space(10)]
    [Header("- - - - - - KeyCode - - - - - -")]
    [SerializeField] private KeyCode keyOne;
    [SerializeField] private KeyCode keyTwo;

    /*AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }*/

    private void FixedUpdate()
    {
        if (Input.GetKey(keyOne))
        {
            GetComponent<Rigidbody>().velocity += moveDirection;
        }

        else if (Input.GetKey(keyTwo))
        {
            GetComponent<Rigidbody>().velocity -= moveDirection;
        }

        else if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
