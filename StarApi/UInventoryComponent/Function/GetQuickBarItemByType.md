# GetQuickBarItemByType

## 格式

```C++
FGuid GetQuickBarItemByType(EQuickBarType Type);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	根据快捷栏类型获取快捷栏的道具

## 参数

| 名称 | 类型          | 缺省 | 是否输出 | 描述             |
| ---- | ------------- | ---- | -------- | ---------------- |
| Type | EQuickBarType |      |          | 快捷栏的枚举类型 |

## 返回值

| 类型  | 描述                                                   |
| ----- | ------------------------------------------------------ |
| FGuid | 装备的实体GUID，若没有这个快捷栏的道具则返回空的guid。 |

## 调用位置

| 调用位置        | 是否可以调用 |
| --------------- | ------------ |
| Client          | 可以         |
| DedicatedServer | 可以         |

## 实例

![GetQuickBarItemByTypeFunction](..\\..\\Resources\\GetQuickBarItemByTypeFunction.png)
