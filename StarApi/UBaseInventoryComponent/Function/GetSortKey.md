# GetSortKey

## 格式

```C++
float GetSortKey(const FGuid& uid);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	获取指定道具的排序值，返回值越小排序越靠前。

## 参数

| 名称 | 类型  | 缺省 | 是否输出 | 描述       |
| ---- | ----- | ---- | -------- | ---------- |
| uid  | FGuid |      |          | 道具的GUID |

## 返回值

| 类型  | 描述   |
| ----- | ------ |
| float | 排序值 |

## 调用位置

​	Client和DS都可以调用。

## 实例

![GetSortKeyFunction](..\\..\\Resources\\GetSortKeyFunction.png)
