using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode JumpCode = KeyCode.Space;
    private const KeyCode AttackCode = KeyCode.Mouse0;

    private bool _isJump = false;
    private bool _isAttack = false;

    private void Update()
    {
        if (Input.GetKeyDown(JumpCode))
            _isJump = true;

        if (Input.GetKey(AttackCode))
            _isAttack = true;
    }

    public bool IsJump()
    {
        bool isJump = _isJump;
        _isJump = false;

        return isJump;
    }

    public bool IsAttack()
    {
        bool isAttack = _isAttack;
        _isAttack = false;

        return isAttack;
    }
}