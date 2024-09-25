using UnityEngine;

public class CubeScript : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        transform.eulerAngles += new Vector3(0, Input.GetAxis("Horizontal") / 5.0f, 0);
        transform.position += transform.forward * Input.GetAxis("Vertical") / 40.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Destroy")
        {
            Destroy(collision.gameObject);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
