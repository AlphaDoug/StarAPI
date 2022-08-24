# GetEquipedItemBySlot

## 格式

```C++
UItem* GetEquipedItemBySlot(const EEquipmentSlot Slot);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	根据装备槽位来获取当前装备的道具

## 参数

| 名称 | 类型           | 缺省 | 是否输出 | 描述                                             |
| ---- | -------------- | ---- | -------- | ------------------------------------------------ |
| Slot | EEquipmentSlot |      |          | EEquipmentSlot枚举类型，表示想要获取的装备槽位。 |

## 返回值

| 类型  | 描述       |
| ----- | ---------- |
| UItem | 装备的实体 |

## 调用位置

​	

| 调用位置        | 是否可以调用 |
| --------------- | ------------ |
| Client          | 可以         |
| DedicatedServer | 可以         |



## 实例

![GetEquipedItemBySlotFunction](..\\..\\Resources\\GetEquipedItemBySlotFunction.png)
