# FacilityChange

## 格式

```c++
DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FFacilityInventoryChange, bool, success);
FFacilityInventoryChange FacilityChange;
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #E36DE7;">事件</span>	

​	设施仓库中的道具发生更改时调用的委托。Client和DS都会执行。

## 参数

| 名称      | 类型 | 缺省 | 描述         |
| --------- | ---- | ---- | ------------ |
| hitObject | bool |      | 更改是否成功 |

## 实例