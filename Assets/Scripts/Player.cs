using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag=="End")
        {
            Application.LoadLevel("End");
        }

    }


    Rigidbody2D PlayerRigdbody2D;
    [Header("目前水平速度")]
    public float SpeedX;

    [Header("目前水平方向")]
    public float horizontalDirection;//數值會在-1到1之間

    [Header("最大水平速度")]
    public float MaxSpeedX;


    public void ControSpeed()
    {
        SpeedX = PlayerRigdbody2D.velocity.x;
        SpeedY = PlayerRigdbody2D.velocity.y;
        float newspeedX = Mathf.Clamp(SpeedX, -MaxSpeedX, MaxSpeedX);
        PlayerRigdbody2D.velocity = new Vector2(newspeedX, SpeedY);
    }


    const string HORIZONTAL = "Horizontal";
    [Header("水平推力")]
    [Range(0,150)]
    public float xForce;

    float SpeedY;//目前垂直速度

    [Header("垂直向上推力")]
    public float yForce;
    public bool Jumpkey
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }

    void TryJump()
    {
        if (IsGround && Jumpkey)
        {
            PlayerRigdbody2D.AddForce(Vector2.up*yForce);
        }
    }

    [Header("感應地板距離")]
    [Range(0,0.5f)]
    public float distance;

    [Header("偵測地板的射線起點")]
    public Transform GroundCheck;

    [Header("地板圖層")]
    public LayerMask GroundLayer;

    public bool grounded;
    //在玩家底部設一條很短的射線 如果有打到地板 代表玩家正踩著地板
    bool IsGround
    {
        get
        {
            Vector2 start = GroundCheck.position;
            Vector2 end = new Vector2(start.x, start.y - distance);

            Debug.DrawLine(start, end, Color.blue);
            grounded = Physics2D.Linecast(start, end,GroundLayer);
            return grounded;
        }
    }
	// Use this for initialization
	void Start () {
        PlayerRigdbody2D = GetComponent<Rigidbody2D>();
        
	}
	/// <summary>
    /// 水平移動
    /// </summary>
    void MovementX()
    {
        horizontalDirection = Input.GetAxis(HORIZONTAL);
        PlayerRigdbody2D.AddForce(new Vector2(xForce*horizontalDirection,0));
    }
	// Update is called once per frame
	void Update () {
        MovementX();
        //SpeedX = PlayerRigdbody2D.velocity.x;
        ControSpeed();
        TryJump();
    }
}
