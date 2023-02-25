using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionDirect : MonoBehaviour, IMovePosition {

    private Vector3 movePosition;

    public void SetMovePosition(Vector3 movePosition) {
        this.movePosition = movePosition;
    }

    private void Update() {
        Vector3 moveDir = (movePosition - transform.position).normalized;
        if (Vector3.Distance(movePosition, transform.position) < 1f) moveDir = Vector3.zero;
        GetComponent<IMoveVelocity>().SetVelocity(moveDir);
    }
}
