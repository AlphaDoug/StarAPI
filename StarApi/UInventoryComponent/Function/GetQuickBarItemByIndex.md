# GetQuickBarItemByIndex

## 格式

```C++
FGuid GetQuickBarItemByIndex(const int32 Index);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	根据快捷栏索引获取快捷栏的道具

## 参数

| 名称  | 类型  | 缺省 | 是否输出 | 描述                            |
| ----- | ----- | ---- | -------- | ------------------------------- |
| Index | int32 |      |          | 快捷栏的索引，从左到右从0开始。 |

## 返回值

| 类型  | 描述     |
| ----- | -------- |
| FGuid | 道具GUID |

## 调用位置

| 调用位置        | 是否可以调用 |
| --------------- | ------------ |
| Client          | 可以         |
| DedicatedServer | 可以         |

## 实例

![GetQuickBarItemByIndexFunction](..\\..\\Resources\\GetQuickBarItemByIndexFunction.png)
