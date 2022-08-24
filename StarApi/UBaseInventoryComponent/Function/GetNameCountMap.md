# GetNameCountMap

## 格式

```C++
TMap<FName,int32> GetNameCountMap(const TArray<EInventoryType>& Types);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	获取背包中所有的道具名称与对应的数量。

## 参数

| 名称  | 类型                   | 缺省 | 是否输出 | 描述               |
| ----- | ---------------------- | ---- | -------- | ------------------ |
| Types | TArray<EInventoryType> |      |          | 背包类型的枚举数组 |

## 返回值

| 类型              | 描述                                           |
| ----------------- | ---------------------------------------------- |
| TMap<FName,int32> | 获取的道具名称作为key，数量作为value的TMap结构 |

## 调用位置

​	Client和DS都可以调用。

## 实例

![GetNameCountMapFunction](..\\..\\Resources\\GetNameCountMapFunction.png)
