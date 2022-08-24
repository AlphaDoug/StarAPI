# ChangeWearFashions

## 格式

```C++
void ChangeWearFashions(const TArray<FGuid>& WearIds,const TArray<FGuid>& UnWearIds);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	穿上时装或装备和脱下时装或装备，若在客户端调用，则需要走RPC到服务端执行。

## 参数

| 名称      | 类型           | 缺省 | 是否输出 | 描述                              |
| --------- | -------------- | ---- | -------- | --------------------------------- |
| WearIds   | TArray<FGuid>& |      |          | 想要穿上的装备 TArray<FGuid>&类型 |
| UnWearIds | TArray<FGuid>& |      |          | 想要脱下的装备 TArray<FGuid>&类型 |

## 返回值

| 类型 | 描述 |
| ---- | ---- |
| void | 无   |

## 调用位置

| 调用位置        | 是否可以调用                    |
| --------------- | ------------------------------- |
| Client          | 可以，但是需要走RPC到服务端执行 |
| DedicatedServer | 可以                            |

## 实例

![ChangeWearFashionsFunction](..\\..\\Resources\\ChangeWearFashionsFunction.png)
