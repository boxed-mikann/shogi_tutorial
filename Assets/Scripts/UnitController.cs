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

public class UnitController : MonoBehaviour
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
        this.Player=player;//this.は省略できる
        this.UnitType=(UnitType) unittype;
        //取られた時、元に戻る用
        this.OldUnitType=(UnitType) unittype;
        //駒の状態
        this.FieldStatus=FieldStatus.OnBoard;
        //成りが無ければ進化終了
        if(UnitType.None==evolutionTable[this.UnitType]){
            this.isEvolved=true;
        }
        transform.eulerAngles = getAngles(player);
        Move(tile,pos);

    }

    //指定されたプレイヤー番号の向き
    Vector3 getAngles(int player){
        return new Vector3(0, (player-1)*(-180), 0);
    }

    public void Move(GameObject tile,Vector2Int tileindex)
    {
        //少し浮かせて新しい場所へ
        Vector3 pos = tile.transform.position;
        pos.y=UnSelectUnitY;
        transform.position=pos;

        this.Pos=tileindex;
    }

    //選択時の処理
    public void Select(bool select=true){
        Vector3 pos =transform.position;
        bool iskinematic = true;
        if(select)
        {
            this.OldPosY=pos.y;
            pos.y=SelectUnitY;
        }
        else{
            pos.y=UnSelectUnitY;
            //持ち駒について
            if(this.FieldStatus==FieldStatus.Captured)
            {
                pos.y=OldPosY;
                iskinematic=true;
            }
        }

        GetComponent<Rigidbody>().isKinematic=iskinematic;
        transform.position=pos;

    }
}
