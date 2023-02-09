using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGrid : MonoBehaviour
{
    public GameObject testPrefab;
    public Grid testGrid;
    public Camera mainCamera;

    public GameObject moveTestCube;

    void Awake() {
        testGrid = new Grid(5, 6, new Vector3(0f, 0f, 0f));
    }
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            Vector3 pos = GetMouseWorldPosition();
            // pos = new Vector3(pos.x, pos.y, testPrefab.transform.position.z);

            if (pos.x != 0f && pos.y != 0f && pos.z != 0f) {
                pos = testGrid.WorldPosToGridPos(pos);
                pos = new Vector3(pos.x, pos.y, testPrefab.transform.position.z);
                // Instantiate(testPrefab, GetMouseWorldPosition(), Quaternion.identity);
                Instantiate(testPrefab, pos, testPrefab.transform.rotation);
            }
        }

        Vector3 mouseWorldPos = GetMouseWorldPosition();
        Vector3 clipPos = testGrid.WorldPosToGridPos(mouseWorldPos);
        clipPos = new Vector3(clipPos.x, clipPos.y, testPrefab.transform.position.z);
        moveTestCube.transform.position = clipPos;
    }

    public Vector3 GetMouseWorldPosition() {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit)) {  // 6 = mouseColliderLayerMask{ //if(Physics.Raycast(ray, out RaycastHit raycastHit, 999f, 6))
            print("rayHitPoint");
            return raycastHit.point;
        }
        else {
            return Vector3.zero;
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        if (testGrid != null) { 

            for (int y = 0; y < testGrid.NumRows; y++) {
                for(int x = 0; x < testGrid.NumColumns; x++){
                    Gizmos.DrawSphere(testGrid.GetWorldPositionFromIndex(x,y), 0.05f);
                }
            }
        }
    }
}
