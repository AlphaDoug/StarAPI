# AddItemsByName

## 格式

```C++
virtual int32 AddItemsByName(const TArray<FItemDef>& Items,  FItemOperateOptions Options);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	根据道具定义结构体添加指定数量的一些道具。

## 参数

| 名称    | 类型                                                       | 缺省 | 是否输出 | 描述                     |
| ------- | ---------------------------------------------------------- | ---- | -------- | ------------------------ |
| Items   | TArray< [FItemDef](..\\..\\Struct\\FItemDef.html) >             |      |          | 道具的定义模板结构体数组 |
| Options | [FItemOperateOptions](..\\..\\Struct\\FItemOperateOptions.html) |      |          | 道具添加时的操作结构体   |

## 返回值

| 类型  | 描述           |
| ----- | -------------- |
| int32 | 通用错误码类型 |

## 调用位置

​	只能在DS上进行调用。

## 实例

![](..\\..\\Resources\\AddItemsByNameFunction.png)
