using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WobblyGrid : MonoBehaviour
{
    public GameObject Block;
    public GameObject[] BlockList;
    public Material BlockMat;
    public float BlockLength, BlockWidth, GridHeight, SpacingBetween, Scale, Amplitude, Frequency;

    public int StartX, StartZ, GridX, GridZ, GridDivision;
    private int GridSize, SizeX, SizeZ, BlockIndex;

    public bool MakeColors, AnimateBlocks;

    // Start is called before the first frame update
    void Start()
    {
        GridSize = GridX * GridZ;
        BlockList = new GameObject[GridSize];
        SizeX = StartX + GridX;
        SizeZ = StartZ + GridZ;
        for (int x = StartX; x <= SizeX; x++)
        {
            for(int z = StartZ; z <= SizeZ; z++)
            {
                // instantiate objects
                GameObject BlockInstance = (GameObject)Instantiate(Block);
                BlockInstance.transform.parent = this.transform;
                BlockInstance.name = "Block " + BlockIndex;

                // 피라미드 모양으로 하기위해 변수 설정
                float Xtemp;
                float Ztemp;
                if (x > StartX + (GridX / GridDivision))
                {
                    Xtemp = (StartX + (GridX / GridDivision)) - (x - (StartX + (GridX / GridDivision)));
                }
                else
                {
                    Xtemp = x;
                }
                if (z > StartZ + (GridZ / GridDivision))
                {
                    Ztemp = (StartZ + (GridZ / GridDivision)) - (z - (StartZ + (GridZ / GridDivision)));
                }
                else
                {
                    Ztemp = z;
                }

                // 색 생성
                if (MakeColors)
                {
                    float ColorPercentR = Xtemp / SizeX;
                    float ColorPercentG = (Xtemp * Ztemp) / (GridSize / GridDivision);
                    float ColorPercentB = Ztemp / SizeZ;


                    BlockMat.color = new Vector4(ColorPercentR, ColorPercentG, ColorPercentB, 1);
                    BlockInstance.GetComponent<Renderer>().material.color = BlockMat.color;
                }
                // 모양 변형하기
                BlockList[BlockIndex] = BlockInstance;
                BlockList[BlockIndex].transform.position = new Vector3((x-1) * SpacingBetween, (Xtemp * Ztemp) * GridHeight, (z-1) * SpacingBetween);
                BlockList[BlockIndex].transform.localScale = new Vector3(BlockWidth, BlockLength, BlockWidth);
                BlockIndex++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(AnimateBlocks)
        {
            for (int i = 0; i < GridSize; i++)
            {
                float wave = Scale * Mathf.Sin(Time.fixedTime * Amplitude + (i * Frequency));
                float wave2 = Scale * Mathf.PerlinNoise(Time.fixedTime * Amplitude + (i * Frequency), Time.fixedTime * Amplitude + (i * Frequency));
                BlockList[i].transform.position = new Vector3(BlockList[i].transform.position.x, BlockList[i].transform.position.y + (wave * wave2) * Random.Range(1,3), BlockList[i].transform.position.z) ;

            }
        }
    }
}
