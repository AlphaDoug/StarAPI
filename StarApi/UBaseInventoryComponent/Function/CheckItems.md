# CheckItems

## 格式

```C++
virtual bool CheckItems(const TArray<FItemDef>& ItemDefs, EInventoryType type = EInventoryType::All);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	检查给定的道具定义结构体数组中的每个元素的道具数量在背包中是否都大于给出的数量。

## 参数

| 名称     | 类型             | 缺省 | 是否输出 | 描述                                                         |
| -------- | ---------------- | ---- | -------- | ------------------------------------------------------------ |
| ItemDefs | TArray<FItemDef> |      |          | 道具定义结构体数组，最终会获取此结构体数组中的每个元素品质和Name，去仓库中的指定背包中取指定的品质道具数量，然后和此结构体中的Count进行比对，需要所有的都满足大于条件后才会通过检查。 |
| type     | EInventoryType   |      |          | 背包类型，目前此参数填写任何值都不会影响结果                 |

## 返回值

| 类型 | 描述                                                         |
| ---- | ------------------------------------------------------------ |
| bool | 若仓库中的指定品质道具的数量大于数组中所有参数中的道具数量，则返回true，否则返回false。 |

## 调用位置

​	Client和DS都可以调用。

## 实例

![CheckItemsFunction](..\\..\\Resources\\CheckItemsFunction.png)
