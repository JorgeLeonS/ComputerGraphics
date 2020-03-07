using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public GameObject bcPrefab;
    static int PARTS =16;
    BasicCube[] body= new BasicCube[PARTS];
    float[] rotationsX;
    float[] directions;
    public enum PART_NAME {
        HIP, TORSO, NECK,HEAD,
        R_SHOULDER, R_ARM,R_HAND, 
        L_SHOULDER,L_ARM,L_HAND,
        R_THIGH,R_LEG, R_FOOT, 
        L_THIGH, L_LEG,L_FOOT}
    
    public static Matrix4x4 opScale(float sx, float sy, float sz)
    {
        Matrix4x4 sm = Matrix4x4.identity;
        sm[0, 0] = sx;
        sm[1, 1] = sy;
        sm[2, 2] = sz;
        return sm;
    }
    public static Matrix4x4 opTranslate(float tx, float ty, float tz)
    {
        Matrix4x4 tm = Matrix4x4.identity;
        tm[0, 3] = tx;
        tm[1, 3] = ty;
        tm[2, 3] = tz;
        return tm;
    }
    public void TransformMesh(Mesh m, Matrix4x4 t)
    {
        Vector3[] points = m.vertices;
        int total = points.Length;
        for (int i = 0; i < total; i++)
        {
            Vector4 v = new Vector4(points[i].x,
                                    points[i].y,
                                    points[i].z, 1);
            v = t * v;
            points[i] = new Vector3(v.x, v.y, v.z);
        }
        m.vertices = points;
        m.RecalculateNormals();
    }

    public static Matrix4x4 initialPose(PART_NAME part){
        Matrix4x4 transform= Matrix4x4.identity;
        Matrix4x4 scale=Matrix4x4.identity;
        Matrix4x4 translate=Matrix4x4.identity;

        switch(part){
            case PART_NAME.HIP:
                scale = opScale(2.0f,1.0f,5.0f);
                transform=scale;
            break;
            //Upper body
            case PART_NAME.TORSO:
                scale = opScale(2.0f,6.0f,5.0f);
                translate = opTranslate(0.0f,7f,0.0f);
                transform=translate*scale;
            break;
            case PART_NAME.NECK:
                scale = opScale(2.0f,1.0f,1.0f);
                translate = opTranslate(0.0f,14f,0.0f);
                transform=translate;
            break;
            case PART_NAME.HEAD:
                scale = opScale(2.0f,2.0f,2.0f);
                translate = opTranslate(0.0f,17f,0.0f);
                transform=translate*scale;
            break;
            case PART_NAME.R_SHOULDER:
                scale = opScale(2.0f,1.0f,1.0f);
                translate = opTranslate(0.0f,12f,6f);
                transform=translate*scale;
            break;
            //Right
        
            case PART_NAME.R_ARM:
                scale = opScale(2.0f,1.0f,5.0f);
                translate = opTranslate(0.0f,12f,12f);
                transform=translate*scale;
            break;
            case PART_NAME.R_HAND:
                scale = opScale(2.0f,1.0f,1.0f);
                translate = opTranslate(0.0f,12f,18f);
                transform=translate*scale;
            break;
            //Left
            case PART_NAME.L_SHOULDER:
                scale = opScale(2.0f,1.0f,1.0f);
                translate = opTranslate(0.0f,12f,-6f);
                transform=translate*scale;
            break;
            case PART_NAME.L_ARM:
                scale = opScale(2.0f,1.0f,5.0f);
                translate = opTranslate(0.0f,12f,-12f);
                transform=translate*scale;
            break;
            case PART_NAME.L_HAND:
                scale = opScale(2.0f,1.0f,1.0f);
                translate = opTranslate(0.0f,12f,-18f);
                transform=translate*scale;
            break;
            //Bottom Right
            case PART_NAME.R_THIGH:
                scale = opScale(2.0f,3.0f,1.0f);
                translate = opTranslate(0.0f,-4f,4f);
                transform=translate*scale;
            break;
            case PART_NAME.R_LEG:
                scale = opScale(2.0f,3.0f,1.0f);
                translate = opTranslate(0.0f,-10f,4f);
                transform=translate*scale;
            break;
            case PART_NAME.R_FOOT:
                scale = opScale(2.0f,1.0f,1.0f);
                translate = opTranslate(0.0f,-14f,4f);
                transform=translate*scale;
            break;
            //Bottom Left
            case PART_NAME.L_THIGH:
                scale = opScale(2.0f,3.0f,1.0f);
                translate = opTranslate(0.0f,-4f,-4f);
                transform=translate*scale;
            break;
            case PART_NAME.L_LEG:
                scale = opScale(2.0f,3.0f,1.0f);
                translate = opTranslate(0.0f,-10f,-4f);
                transform=translate*scale;
            break;
            case PART_NAME.L_FOOT:
                scale = opScale(2.0f,1.0f,1.0f);
                translate = opTranslate(0.0f,-14f,-4f);
                transform=translate*scale;
            break;
        };
        return transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<PARTS;i++){
            body[i]= Instantiate(bcPrefab).GetComponent<BasicCube>();
            
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
        for(int i=0;i<PARTS;i++){
            body[i].resetPoints();
            TransformMesh(body[i].getMesh(),initialPose((PART_NAME)i));
        }
        
    }
}
