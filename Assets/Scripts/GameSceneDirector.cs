using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneDirector : MonoBehaviour
{
    //UI関連
    [SerializeField] Text textTurnInfo;
    [SerializeField] Text textResultInfo;
    [SerializeField] Button buttonTitle;
    [SerializeField] Button buttonRematch;
    [SerializeField] Button buttonEvolutionApply;
    [SerializeField] Button buttonEvolutionCancel;

    //ゲーム設定
    const int PlayerMax = 2;
    int boardWidth;
    int boardHeight;

    //タイルのプレハブ
    [SerializeField] GameObject PrefabTile;

    //ユニットのプレハブ
    [SerializeField] List<GameObject> prefabUnits;

    //初期配置
    int[,] boardSetting =//[,]2次元配列を表すらしい
    {
        {4,0,1,0,0,0,11,0,14},
        {5,2,1,0,0,0,11,13,15},
        {6,0,1,0,0,0,11,0,16},
        {7,0,1,0,0,0,11,0,17},
        {8,0,1,0,0,0,11,0,18},
        {7,0,1,0,0,0,11,0,17},
        {6,0,1,0,0,0,11,0,16},
        {5,3,1,0,0,0,11,12,15},
        {4,0,1,0,0,0,11,0,14}
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //UI関連初期設定
        buttonTitle.gameObject.SetActive(false);
        buttonRematch.gameObject.SetActive(false);
        buttonEvolutionApply.gameObject.SetActive(false);
        buttonEvolutionCancel.gameObject.SetActive(false);
        textResultInfo.text = "";

        //ボードサイズ
        boardWidth = boardSetting.GetLength(0);
        boardHeight = boardSetting.GetLength(1);

        // ボードのタイルを生成
        for (int i = 0; i < boardWidth; i++)
        {
            for (int j = 0; j < boardHeight; j++)
            {
                float x = i - boardWidth / 2;
                float y = j - boardWidth / 2;
                Vector3 pos = new Vector3(x, 0, y);
                // タイルの生成
                GameObject tile = Instantiate(PrefabTile, pos, Quaternion.identity);
                //tile.name = $"Tile_{j}_{i}";
                //tile.transform.SetParent(this.transform);

                //ユニットの作成
                int type = boardSetting[i,j]%10;
                int player = boardSetting[i,j]/10;

                if (0==type)continue;//空白マス、continueはbreakみたいに抜けずに、次のループへ行く

                //初期化
                pos.y = 2.7f;
                GameObject prefab = prefabUnits[type-1];
                GameObject unit = Instantiate(prefab, pos, Quaternion.Euler(0, (player-1)*(-180), 0));
                unit.transform.localScale *= 0.5f; // 大きさを0.5倍にする
                unit.AddComponent<Rigidbody>();
                unit.AddComponent<BoxCollider>();

                //TODO ユニットの初期化
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
