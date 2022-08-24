# GetClothStr

## 格式

```C++
FString GetClothStr(bool bShowArmor, bool isHideCloth = false);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	获取当前角色服饰的字符串。

## 参数

| 名称        | 类型 | 缺省  | 是否输出 | 描述                           |
| ----------- | ---- | ----- | -------- | ------------------------------ |
| bShowArmor  | bool |       |          | 是否按照显示盔甲进行拼接字符串 |
| isHideCloth | bool | false |          | 是否按照隐藏服饰进行拼接字符串 |

## 返回值

| 类型    | 描述               |
| ------- | ------------------ |
| FString | 服饰拼接后的字符串 |

## 调用位置

| 调用位置        | 是否可以调用 |
| --------------- | ------------ |
| Client          | 可以         |
| DedicatedServer | 可以         |

## 实例

![GetClothStrFunction](..\\..\\Resources\\GetClothStrFunction.png)