
using UnityEngine;
using System.Collections;

public class JoystickControl : MonoBehaviour
{
    
    //动画控制
    private Animator AnimatorController;

    //移动速度与跳跃力度
    public float jumpSpeed;
    public float crashSpeed;
    bool first=true;

    //音效
    public AudioClip jump;
    public AudioClip dead;

    //粒子系统
    public ParticleSystem JumpParticles_Floor;
    public ParticleSystem JumpParticles_doubleJump;
    public ParticleSystem Particles_DeathBoom;

    void OnEnable()
    {
        //按住摇杆
        EasyJoystick.On_JoystickMove += OnJoystickMove;
        //松开摇杆
        EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
        //按下button
        EasyButton.On_ButtonDown += On_ButtonDown;

    }
    //重新载入场景时，按钮重置
    void OnDisable()
    {
        EasyJoystick.On_JoystickMove -= OnJoystickMove;
        EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
        EasyButton.On_ButtonDown -= On_ButtonDown;
    }

    //移动摇杆结束  
    void OnJoystickMoveEnd(MovingJoystick move)
    {
        if (GameManager.getInstance().GAMESTATE == GameManager.getInstance().PLAYING)
            if (move.joystickName == "MoveJoystick")
            {
                //停止时，角色恢复速度0
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            }
    }

    //移动摇杆中  
    void OnJoystickMove(MovingJoystick move)
    {
		if ((GameManager.getInstance().GAMESTATE == GameManager.getInstance().PLAYING)&&(GameManager.getInstance().IfCanMove==true))
        {
            if (move.joystickName != "MoveJoystick")
            {
                return;
            }
            //获取摇杆中心偏移的坐标  
            float joyPositionX = move.joystickAxis.x;
            //摇杆偏左向左移并转向，同理向右
            if (joyPositionX > 0)
            {
                transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
                GetComponent<Rigidbody2D>().velocity = new Vector2(crashSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
                GetComponent<Rigidbody2D>().velocity = new Vector2(-crashSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }

    //按下button时
    void On_ButtonDown(string buttonName)
    {
        if ((GameManager.getInstance().GAMESTATE == GameManager.getInstance().PLAYING) && (GameManager.getInstance().IfCanMove == true))
        {
            //如果按下的是JumpButton  
            if (buttonName == "JumpButton")
            {
                //二连跳判断
                if (GameManager.getInstance().jumpFlag && GameManager.getInstance().jumptime < 2)
                {
                    GameManager.getInstance().jumptime++;
                    AudioSource.PlayClipAtPoint(jump, this.transform.position);
                    //第一下起跳粒子效果
                    if (GameManager.getInstance().jumptime == 1)
                    {
                        JumpParticles_Floor.Emit(20);
                    }
                    //第二下起跳粒子效果
                    if (GameManager.getInstance().jumptime == 2)
                    {
                        JumpParticles_doubleJump.Emit(10);
                        GameManager.getInstance().jumpFlag = false;
                    }
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
                }
            }
        }
    }
}