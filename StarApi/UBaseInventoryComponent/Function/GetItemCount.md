# GetItemCount

## 格式

```C++
virtual int32 GetItemCount(const FName& name = NAME_None, EInventoryType type = EInventoryType::All,EItemQuality quality = EItemQuality::None);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	获取指定RowName和指定品质的道具在此仓库中的数量

## 参数

| 名称    | 类型           | 缺省                | 是否输出 | 描述                                         |
| ------- | -------------- | ------------------- | -------- | -------------------------------------------- |
| name    | FName          | NAME_None           |          | 道具ID                                       |
| type    | EInventoryType | EInventoryType::All |          | 背包类型，目前此参数填写任何值都不会影响结果 |
| quality | EItemQuality   | EItemQuality::None  |          | 获取的品质，默认值为All，即所有品质都计数。  |

## 返回值

| 类型  | 描述                          |
| ----- | ----------------------------- |
| int32 | 道具数量，若没有此道具则为0。 |

## 调用位置

​	Client和DS都可以调用。

## 实例

![GetItemCountFunction](..\\..\\Resources\\GetItemCountFunction.png)
