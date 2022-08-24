# GetCurrentFashions

## 格式

```C++
void GetCurrentFashions(TMap<EEquipmentSlot, FGuid>& Fashions);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	获取当前的时装

## 参数

| 名称     | 类型                        | 缺省 | 是否输出 | 描述                                               |
| -------- | --------------------------- | ---- | -------- | -------------------------------------------------- |
| Fashions | TMap<EEquipmentSlot, FGuid> |      | 是       | 当前的时装数据，key为穿戴的槽位，value为道具的guid |

## 返回值

| 类型 | 描述 |
| ---- | ---- |
| void | 无   |

## 调用位置

| 调用位置        | 是否可以调用 |
| --------------- | ------------ |
| Client          | 可以         |
| DedicatedServer | 可以         |

## 实例

![GetCurrentFashionsFunction](..\\..\\Resources\\GetCurrentFashionsFunction.png)
