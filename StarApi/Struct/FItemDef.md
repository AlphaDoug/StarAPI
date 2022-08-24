# FItemDef

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">结构体</span>

道具定义的结构体，一般用来进行道具的发放，移除等操作。

## 属性

|     数据类型 | 属性名称        | 简介                                          |
| -----------: | :-------------- | :-------------------------------------------- |
|        FName | ItemName        | 道具ID，对应道具表，坐骑表等广义道具的RowName |
|        int32 | Count           | 道具数量                                      |
| EItemQuality | OverRideQuality | 道具最终品质，可以覆盖原有的品质              |
|    EItemType | Type            | 道具类型                                      |

