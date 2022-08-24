# SetItemCustomParam

## 格式

```C++
virtual bool SetItemCustomParam(const FGuid& uid, const FString& key, int32 param);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	设置指定道具的自定义数据。

## 参数

| 名称  | 类型    | 缺省 | 是否输出 | 描述                       |
| ----- | ------- | ---- | -------- | -------------------------- |
| uid   | FGuid   |      |          | 道具的GUID                 |
| key   | FString |      |          | 自定义数据的键。           |
| param | int32   |      |          | 自定义数据的值，只能是整数 |

## 返回值

| 类型 | 描述                                 |
| ---- | ------------------------------------ |
| bool | 目前此接口固定返回false，应该是有bug |

## 调用位置

​	只能在DS上调用

## 实例

![SetItemCustomParamFunction](..\\..\\Resources\\SetItemCustomParamFunction.png)
