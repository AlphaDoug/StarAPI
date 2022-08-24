# GetItemUseCounter

## 格式

```C++
int32 GetItemUseCounter(const FName& name);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	查询指定ID的道具使用计数。

## 参数

| 名称 | 类型  | 缺省 | 是否输出 | 描述              |
| ---- | ----- | ---- | -------- | ----------------- |
| name | FName |      |          | 查询的道具rowName |

## 返回值

| 类型  | 描述               |
| ----- | ------------------ |
| int32 | 指定道具的使用计数 |

## 调用位置

| 调用位置        | 是否可以调用 |
| --------------- | ------------ |
| Client          | 可以         |
| DedicatedServer | 可以         |

## 实例

![GetItemUseCounterFunction](..\\..\\Resources\\GetItemUseCounterFunction.png)
