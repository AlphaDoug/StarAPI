# CheckItem

## 格式

```C++
virtual bool CheckItem(const FItemDef& ItemDef, EInventoryType type = EInventoryType::All);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	检查给定的道具定义结构体中的道具数量在背包中是否大于给出的数量。

## 参数

| 名称    | 类型           | 缺省                | 是否输出 | 描述                                                         |
| ------- | -------------- | ------------------- | -------- | ------------------------------------------------------------ |
| ItemDef | FItemDef       |                     |          | 道具定义结构体，最终会获取此结构体中的品质和Name，去仓库中的指定背包中取指定的品质道具数量，然后和此结构体中的Count进行比对 |
| type    | EInventoryType | EInventoryType::All |          | 背包类型，目前此参数填写任何值都不会影响结果                 |

## 返回值

| 类型 | 描述                                                         |
| ---- | ------------------------------------------------------------ |
| bool | 若仓库中的指定品质道具的数量大于给出的参数中的道具数量，则返回true，否则返回false。 |

## 调用位置

​	

## 实例

![CheckItemFunction](..\\..\\Resources\\CheckItemFunction.png)

