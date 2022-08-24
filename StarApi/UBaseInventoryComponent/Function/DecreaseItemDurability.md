# DecreaseItemDurability

## 格式

```C++
virtual void DecreaseItemDurability(UItem* pItem);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	减少道具的耐久度，只有在玩家背包中进行了实现

## 参数

| 名称  | 类型  | 缺省 | 是否输出 | 描述                   |
| ----- | ----- | ---- | -------- | ---------------------- |
| pItem | UItem |      |          | 减少耐久度的道具实例。 |

## 返回值

| 类型 | 描述 |
| ---- | ---- |
| void | 无   |

## 调用位置

​	只能在DS上调用。

## 实例

![DecreaseItemDurabilityFunction](..\\..\\Resources\\DecreaseItemDurabilityFunction.png)
