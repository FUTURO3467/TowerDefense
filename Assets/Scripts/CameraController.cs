
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private bool canMoove = true;

    public float panSpeed = 30f;
    public float panBorder = 10f;
    public float minY = 10f;
    public float maxY = 80f;
    public float scrollSpeed = 5f;
    public float deplaSpeed = 5f;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canMoove = !canMoove;
        }

        if (!canMoove)
        {
            return;
        }

        //vers l'avant
        if (Input.GetKey(KeyCode.Z) || Input.mousePosition.y >= Screen.height- panBorder){
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        //vers l'arri�re
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorder)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        //vers la gauche
        if (Input.GetKey(KeyCode.Q) || Input.mousePosition.x <= panBorder)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        //Vers la droite
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorder)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;


    }
}
