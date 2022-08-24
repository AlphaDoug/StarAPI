# ClearAllItems

## 格式

```C++
void ClearAllItems(EInventoryType type);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	将指定类型的背包中的所有道具全部清除（数量置为0），若不填写背包类型，则表示清除所有类型的背包。

## 参数

| 名称 | 类型           | 缺省 | 是否输出 | 描述             |
| ---- | -------------- | ---- | -------- | ---------------- |
| type | EInventoryType |      |          | 清除的背包类型。 |

## 返回值

| 类型 | 描述 |
| ---- | ---- |
| void | 无   |

## 调用位置

​	只能在DS上进行调用。

## 实例

​	