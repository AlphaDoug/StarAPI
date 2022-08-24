# CheckBagFilling

## 格式

```C++
virtual bool CheckBagFilling(TArray<FItemDef> const& ItemList, TArray<FItemDef>& OutItemList);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	把一些道具放进背包仓库中后，会有多少道具放不下，此方法不会真的向仓库中添加道具。

## 参数

| 名称        | 类型             | 缺省 | 是否输出 | 描述                     |
| ----------- | ---------------- | ---- | -------- | ------------------------ |
| ItemList    | TArray<FItemDef> |      |          | 清除的背包类型。         |
| OutItemList | TArray<FItemDef> |      | 是       | 剩余没有放下的道具列表。 |

## 返回值

| 类型 | 描述                                |
| ---- | ----------------------------------- |
| bool | 若全放下了则返回false，否则返回true |

## 调用位置

​	只能在DS上进行调用。

## 实例

​	