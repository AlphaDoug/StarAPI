# GetOccupiedCapacity

## 格式

```C++
virtual int32 GetOccupiedCapacity(EInventoryType type = EInventoryType::Item);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	获取指定类型背包已使用的容量。

## 参数

| 名称 | 类型           | 缺省                 | 是否输出 | 描述     |
| ---- | -------------- | -------------------- | -------- | -------- |
| type | EInventoryType | EInventoryType::Item |          | 背包类型 |

## 返回值

| 类型  | 描述           |
| ----- | -------------- |
| int32 | 剩余的背包容量 |

## 调用位置

​	Client和DS都可以调用。

## 实例

![GetOccupiedCapacityFunction](..\\..\\Resources\\GetOccupiedCapacityFunction.png)
