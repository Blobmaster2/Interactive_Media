using UnityEngine;

public class ThirdPersonCameraCollision : MonoBehaviour
{
    public Transform referenceTransform;
    public float collisionOffset = 0.3f; //To prevent Camera from clipping through Objects
    public float cameraSpeed = 15f; //How fast the Camera should snap into position if there are no obstacles

    Vector3 defaultPos;
    Vector3 directionNormalized;
    Transform parentTransform;
    float defaultDistance;

    void Start()
    {
        defaultPos = transform.localPosition;
        directionNormalized = defaultPos.normalized;
        parentTransform = transform.parent;
        defaultDistance = Vector3.Distance(defaultPos, Vector3.zero);

        //Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // LateUpdate is called after Update
    void LateUpdate()
    {
        Vector3 currentPos = defaultPos;
        RaycastHit hit;
        Vector3 dirTmp = parentTransform.TransformPoint(defaultPos) - referenceTransform.position;
        if (Physics.SphereCast(referenceTransform.position, collisionOffset, dirTmp, out hit, defaultDistance))
        {
            if (hit.collider.isTrigger == false && hit.collider.gameObject.layer != 7 && hit.collider.gameObject.layer != 9)
            {
                currentPos = (directionNormalized * (hit.distance - collisionOffset));

                transform.localPosition = currentPos;
            }
            else
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, currentPos, Time.deltaTime * cameraSpeed);
            }
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, currentPos, Time.deltaTime * cameraSpeed);
        }
    }
}