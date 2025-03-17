using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//駒のタイプ
public enum UnitType
{
    None = -1,
    Hu = 1,
    Kaku,
    Hisha,
    Kyousha,
    Keima,
    Gin,
    Kin,
    Ou,
    //成り駒
    Tokin,
    RyuMa,
    RyuOu,
    Narikyou,
    Narikei,
    NariGin

}

public enum FieldStatus
{
    None = -1,
    OnBoard,
    Captured
}

public enum MoveType
{
    None = -1,
    Hu,
    Kaku,
    Hisha,
    Kyousha,
    Keima,
    Gin,
    Kin,
    Ou

}

public class NewMonoBehaviourScript : MonoBehaviour
{
    //このユニットのプレイヤー番号
    public int Player;
    //ユニットの種類
    public UnitType UnitType, OldUnitType;
    //ユニットの状態
    public FieldStatus FieldStatus;
    //成りテーブル
    Dictionary<UnitType, UnitType> evolutionTable = new Dictionary<UnitType, UnitType>()
        {
            {UnitType.Hu,UnitType.Tokin},
            {UnitType.Kyousha,UnitType.Narikyou},
            {UnitType.Keima,UnitType.Narikei},
            {UnitType.Gin,UnitType.NariGin},
            {UnitType.Kaku,UnitType.RyuMa},
            {UnitType.Hisha,UnitType.RyuOu},
            {UnitType.Kin,UnitType.None},
            {UnitType.Ou,UnitType.None}
        };

    //成り済みかどうか
    public bool isEvolved;
    //ユニット選択/非選択のy座標
    public const float SelectUnitY=1.5f;
    public const float UnSelectUnitY=0.7f;

    //おいてる場所のインデックス
    public Vector2Int Pos;
    //選択される前y座標
    float OldPosY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //初期設定
    public void Init(int player,int unittype,GameObject tile,Vector2Int pos){
        this.Player=player;
    }
}
