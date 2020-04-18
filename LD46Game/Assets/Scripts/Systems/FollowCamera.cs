using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform followTarget;
    Rigidbody2D playerRigidBody;
    public float smoothSpeed = 4f;
    public Vector2 offset;
    public Vector2 threshold;

    private void Start() {
        threshold = CalcThreshold();
        playerRigidBody = followTarget.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate() {
        Vector2 follow = followTarget.transform.position;
        float xDiff = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDiff = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPos = transform.position;
        if (Mathf.Abs(xDiff) >= threshold.x) {
            newPos.x = follow.x;
        }
        if (Mathf.Abs(yDiff) >= threshold.y) {
            newPos.y = follow.y;
        }
        //float moveSpeed = playerRigidBody.velocity.magnitude > smoothSpeed ? playerRigidBody.velocity.magnitude : smoothSpeed;
        //transform.position = Vector3.MoveTowards(transform.position,newPos,moveSpeed * Time.deltaTime);
        transform.position = newPos;
    }
    Vector3 CalcThreshold() {
        Rect aspect = Camera.main.pixelRect;
        Vector2 thresh = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        thresh.x -= offset.x;
        thresh.y -= offset.y;
        return thresh;
    }
    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Vector2 border = CalcThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }
}
