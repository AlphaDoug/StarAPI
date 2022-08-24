# OnItemUserCounterUpdate

## 格式

```c++
DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnItemUserCounterUpdate,TSet<FName>,ItemNameSet);
FOnItemUserCounterUpdate OnItemUserCounterUpdate;
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #E36DE7;">事件</span>	

​	当道具使用计数更新后触发的事件广播委托。

## 参数

| 名称        | 类型        | 缺省 | 描述                 |
| ----------- | ----------- | ---- | -------------------- |
| ItemNameSet | TSet<FName> |      | 计数更新的道具ID列表 |

## 实例