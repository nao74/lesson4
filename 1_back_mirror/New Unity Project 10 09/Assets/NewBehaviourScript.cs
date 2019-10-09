using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private Rigidbody PlayerRigid;
    public GameObject Player;
    public float Jump;
    public float MoveSpeed;
    private Vector3 velocity;

    bool jumpFlag = false;

    bool R_Move = false;
    bool L_Move = false;
    bool Up_Move = false;
    bool Down_Move = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigid = Player.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // 移動
        velocity = Vector3.zero;

        if (R_Move == true)
        {
            velocity.x += MoveSpeed;
        }
        else if (L_Move == true)
        {
            velocity.x -= MoveSpeed;
        }
        else if (Up_Move == true)
        {
            velocity.z += MoveSpeed;
        }
        else if (Down_Move == true)
        {
            velocity.z -= MoveSpeed;
        }


        //速度ベクトルの長さを1秒でMoveSpeedだけ進むようにする
        velocity = velocity.normalized * MoveSpeed * Time.deltaTime;

        if (velocity.magnitude > 0) //左右どちらかに移動している時
        {
            transform.position += velocity;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            R_Move = true;
        }
        else
        {
            R_Move = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            L_Move = true;
        }
        else
        {
            L_Move = false;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Up_Move = true;
        }
        else
        {
            Up_Move = false;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Down_Move = true;
        }
        else
        {
            Down_Move = false;
        }

        // ジャンプ
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpFlag == false)
            {
                PlayerRigid.AddForce(transform.up * Jump);
                jumpFlag = true;
            }
        }


    }

    // 当たり判定
    private void OnCollisionEnter(Collision collision) //当たったら
    {
        if (collision.gameObject.CompareTag("Grand"))// 地上にいたらジャンプ可
        {
            jumpFlag = false;
        }
    }
}
