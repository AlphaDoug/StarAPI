# MakeExtItemLog

## 格式

```C++
virtual void MakeExtItemLog(const FName& name, int32 count, int32 method, const FString& Param1, AMasterBuildPart* BuildPart = nullptr);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	从记录额外的道具操作log，最终会触发事件和传给后端以记录log。目前基类中此函数为一个空函数，只有玩家身上的背包子类会重写此函数。

## 参数

| 名称      | 类型             | 缺省    | 描述             |
| --------- | ---------------- | ------- | ---------------- |
| name      | FName            |         | 道具ID           |
| count     | int32            |         | 要道具操作的数量 |
| method    | int32            |         | 道具操作的方式   |
| Param1    | FString          |         | 日志的参数1      |
| BuildPart | AMasterBuildPart | nullptr | 日志中的建筑对象 |

## 调用位置

​	只能在DS上进行调用，因为此函数最后会调用UStarsActorComponent上的PushLogEvent函数，此函数中会对Authority进行判断。若在客户端调用，此函数将不会有任何效果。

## 实例

![MakeExtItemLogFunction](..\\..\\Resources\\MakeExtItemLogFunction.png)