using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Injection : MonoBehaviour
{
    // Start is called before the first frame update
    const float velocity_max = 15.0f;   //射出速度の最大値
    const float air_resistance_max = 0.1f;  //空気抵抗係数の最大値
    bool is_shot=false;
    float injection_pitch = 0f; //射角
    float injection_yaw = 0f;   //旋回角
    Vector3 init_pos = Vector3.zero;    //リングの初期位置
    Quaternion init_rot = Quaternion.identity;  //リングの初期姿勢
    Quaternion parent_init_rot = Quaternion.identity;   //プラダンの初期姿勢
    Rigidbody rb;
    Vector3 injection_vector = Vector3.zero;    //射出方向ベクトル
    GameObject parent;
    Vector3[] poll_position_list = {new Vector3(0f,0f,0f),          //type3Pole
                                    new Vector3(1.3f,0f,-1.3f),     //type2Pole0
                                    new Vector3(-1.3f,0f,-1.3f),    //type2Pole1
                                    new Vector3(-1.3f,0f,1.3f),     //type2Pole2
                                    new Vector3(1.3f,0f,1.3f),      //type2Pole3
                                    new Vector3(3.2f,0f,-3.2f),     //type1Pole0
                                    new Vector3(0f,0f,-3.2f),       //type1Pole1
                                    new Vector3(-3.2f,0f,-3.2f),    //type1Pole2
                                    new Vector3(-3.2f,0f,3.2f),     //type1Pole3
                                    new Vector3(0f,0f,3.2f),        //type1Pole4
                                    new Vector3(3.2f,0f,3.2f)};     //type1Pole5
    
    [SerializeField,Range(0f,velocity_max)]
        float injection_speed = 5.0f;
    
    [SerializeField,Range(0f,air_resistance_max)]
        float air_resistance = 0.05f;
    
        TMP_InputField input_velocity;
        TMP_InputField input_air_resistance;

    public void SetVelocity(){
        string str_velocity = input_velocity.text;
        injection_speed = Mathf.Clamp(float.Parse(str_velocity),0f,velocity_max);
    }
    
    public void SetAirResistance(){
        string str_air_resistance = input_air_resistance.text;
        air_resistance = Mathf.Clamp(float.Parse(str_air_resistance),0f,air_resistance_max);
    }

    void Start()
    {
        parent = transform.parent.gameObject;
        init_pos = transform.position;
        init_rot = transform.rotation;
        parent_init_rot = parent.transform.rotation;
        rb = GetComponent<Rigidbody>();
        input_velocity = GameObject.Find("velocity").GetComponent<TMP_InputField>();
        input_air_resistance = GameObject.Find("airResistance").GetComponent<TMP_InputField>();
        injection_pitch = parent.transform.localEulerAngles.x;
        injection_yaw = parent.transform.localEulerAngles.y;
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        float dx=0f;
        float dz=0f;
        if(Input.GetKeyUp(KeyCode.Space)&&!is_shot){
            injection_vector = -transform.forward;
            rb.isKinematic = false;
            rb.velocity = injection_speed*injection_vector;
            is_shot=true;
            
        }
        if(Input.GetKeyUp(KeyCode.R)){
            rb.velocity = Vector3.zero;
            parent.transform.rotation = parent_init_rot;
            transform.position = init_pos;
            transform.rotation = init_rot;

            rb.isKinematic = true;
            is_shot=false;
            
        }
        if(Input.GetKeyUp(KeyCode.A)&&!is_shot){
            dx = parent.transform.position.x-poll_position_list[0].x;
            dz = parent.transform.position.z-poll_position_list[0].z;
            parent.transform.rotation = Quaternion.Euler(injection_pitch,Mathf.Atan2(dx,dz)*Mathf.Rad2Deg,0f);
        }
        if(Input.GetKeyUp(KeyCode.B)&&!is_shot){
            dx = parent.transform.position.x-poll_position_list[1].x;
            dz = parent.transform.position.z-poll_position_list[1].z;
            parent.transform.rotation = Quaternion.Euler(injection_pitch,Mathf.Atan2(dx,dz)*Mathf.Rad2Deg,0f);
        }
        if(Input.GetKeyUp(KeyCode.C)&&!is_shot){
            dx = parent.transform.position.x-poll_position_list[2].x;
            dz = parent.transform.position.z-poll_position_list[2].z;
            parent.transform.rotation = Quaternion.Euler(injection_pitch,Mathf.Atan2(dx,dz)*Mathf.Rad2Deg,0f);
        }
        if(Input.GetKeyUp(KeyCode.D)&&!is_shot){
            dx = parent.transform.position.x-poll_position_list[3].x;
            dz = parent.transform.position.z-poll_position_list[3].z;
            parent.transform.rotation = Quaternion.Euler(injection_pitch,Mathf.Atan2(dx,dz)*Mathf.Rad2Deg,0f);
        }
        if(Input.GetKeyUp(KeyCode.E)&&!is_shot){
            dx = parent.transform.position.x-poll_position_list[4].x;
            dz = parent.transform.position.z-poll_position_list[4].z;
            parent.transform.rotation = Quaternion.Euler(injection_pitch,Mathf.Atan2(dx,dz)*Mathf.Rad2Deg,0f);
        }
        if(Input.GetKeyUp(KeyCode.F)&&!is_shot){
            dx = parent.transform.position.x-poll_position_list[5].x;
            dz = parent.transform.position.z-poll_position_list[5].z;
            parent.transform.rotation = Quaternion.Euler(injection_pitch,Mathf.Atan2(dx,dz)*Mathf.Rad2Deg,0f);
        }
        if(Input.GetKeyUp(KeyCode.G)&&!is_shot){
            dx = parent.transform.position.x-poll_position_list[6].x;
            dz = parent.transform.position.z-poll_position_list[6].z;
            parent.transform.rotation = Quaternion.Euler(injection_pitch,Mathf.Atan2(dx,dz)*Mathf.Rad2Deg,0f);
        }
        if(Input.GetKeyUp(KeyCode.H)&&!is_shot){
            dx = parent.transform.position.x-poll_position_list[7].x;
            dz = parent.transform.position.z-poll_position_list[7].z;
            parent.transform.rotation = Quaternion.Euler(injection_pitch,Mathf.Atan2(dx,dz)*Mathf.Rad2Deg,0f);
        }
        if(Input.GetKeyUp(KeyCode.I)&&!is_shot){
            dx = parent.transform.position.x-poll_position_list[8].x;
            dz = parent.transform.position.z-poll_position_list[8].z;
            parent.transform.rotation = Quaternion.Euler(injection_pitch,Mathf.Atan2(dx,dz)*Mathf.Rad2Deg,0f);
        }
        if(Input.GetKeyUp(KeyCode.J)&&!is_shot){
            dx = parent.transform.position.x-poll_position_list[9].x;
            dz = parent.transform.position.z-poll_position_list[9].z;
            parent.transform.rotation = Quaternion.Euler(injection_pitch,Mathf.Atan2(dx,dz)*Mathf.Rad2Deg,0f);
        }
        if(Input.GetKeyUp(KeyCode.K)&&!is_shot){
            dx = parent.transform.position.x-poll_position_list[10].x;
            dz = parent.transform.position.z-poll_position_list[10].z;
            parent.transform.rotation = Quaternion.Euler(injection_pitch,Mathf.Atan2(dx,dz)*Mathf.Rad2Deg,0f);
        }
    }
    void FixedUpdate(){
        rb.AddForce(-rb.velocity*air_resistance);
    }
}