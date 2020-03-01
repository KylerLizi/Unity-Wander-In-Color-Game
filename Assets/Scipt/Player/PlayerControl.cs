using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public bool IsGrounded;
    private GameObject monster;
    public GameObject DeadPic;//死亡图片
    public GameObject ActiveCheckpoint;//复活点
    public GameObject victory;//通关成功

    //动画控制
    private Animator AnimatorController;

    //音效
    public AudioClip jump;
    public AudioClip dead;

    //移动速度与跳跃力度
    public float jumpSpeed;
    public float crashSpeed;
    bool first = true;

    //粒子系统
    public ParticleSystem JumpParticles_Floor;
    public ParticleSystem JumpParticles_doubleJump;
    public ParticleSystem Particles_DeathBoom;

    void Awake()
    {
        AnimatorController = GetComponent<Animator>();
        GameManager.getInstance().jumptime = 0;
        monster = GameObject.Find("monster");
        ActiveCheckpoint = GameObject.Find("CheckPoint_1");
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameManager.getInstance().GAMESTATE == GameManager.getInstance().PLAYING) && (GameManager.getInstance().IfCanMove == true))
        {//二连跳判断
            if (GameManager.getInstance().jumpFlag && GameManager.getInstance().jumptime < 2)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    iJump();
                }
            }
            //左右移动(电脑端)
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 2000f * Time.deltaTime);
                GetComponent<Rigidbody2D>().velocity = new Vector2(crashSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-crashSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            //转向
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
            }
        }
    }

    void FixedUpdate()
    {
        //存储人物速度状态，控制动画
        AnimatorController.SetFloat("HorizontalSpeed", this.GetComponent<Rigidbody2D>().velocity.x * this.GetComponent<Rigidbody2D>().velocity.x);
        AnimatorController.SetFloat("VerticalSpeed", this.GetComponent<Rigidbody2D>().velocity.y);
        AnimatorController.SetBool("Grounded", IsGrounded);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Dead")
        {
            IsGrounded = false;
            iDead();
        }
        if (other.gameObject.tag == "Ground")
        {
            IsGrounded = true;
            GameManager.getInstance().IfCanMove = true;
        }
        if(other.gameObject.tag == "Pass")//过关
        {
            GameManager.getInstance().GAMESTATE = GameManager.getInstance().PREPARING;
            victory.SetActive(true);
            Time.timeScale = 0;
        }

    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && IsGrounded == true)
        {
            IsGrounded = false;
        }
    }

    IEnumerator Wait(float waitTime)//时间等待函数
    {
        yield return new WaitForSeconds(waitTime);
    }

    public void iDead()
    {
        if (GameManager.getInstance().GAMESTATE == GameManager.getInstance().PLAYING)//播放死亡音效
            AudioSource.PlayClipAtPoint(dead, this.transform.position);
        Instantiate(DeadPic, this.transform.position, transform.rotation);//弹出死亡图片
                                                                          //this.gameObject.SetActive(false);//人物消失
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;//死亡时速度变为0
                                                                 //重置跳跃次数
        GameManager.getInstance().jumptime = 0;
        GameManager.getInstance().jumpFlag = true;
        GameManager.getInstance().IfCanMove = false;

        StartCoroutine(Wait(5));
        this.gameObject.transform.position = ActiveCheckpoint.transform.position;
        //GameManager.getInstance().GAMESTATE = GameManager.getInstance().GAMEOVER;
    }

    public void iJump()
    {
        GameManager.getInstance().jumptime++;
        AudioSource.PlayClipAtPoint(jump, this.transform.position);
        if (GameManager.getInstance().jumptime == 1)
            JumpParticles_Floor.Emit(20);//起跳粒子
        if (GameManager.getInstance().jumptime == 2)
        {
            JumpParticles_doubleJump.Emit(10);
            GameManager.getInstance().jumpFlag = false;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
    }
}