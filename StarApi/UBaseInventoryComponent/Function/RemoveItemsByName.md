# RemoveItemsByName

## 格式

```C++
virtual int32 RemoveItemsByName(const TArray<FItemDef>& Items,  FItemOperateOptions Options);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	根据道具定义结构体从仓库中移除指定数量的一些道具。

## 参数

| 名称    | 类型                | 缺省 | 是否输出 | 描述                     |
| ------- | ------------------- | ---- | -------- | ------------------------ |
| Items   | TArray<FItemDef>    |      |          | 道具的定义模板结构体数组 |
| Options | FItemOperateOptions |      |          | 道具移除时的操作结构体   |

## 返回值

| 类型  | 描述            |
| ----- | --------------- |
| int32 | ErrorID枚举类型 |

## 调用位置

​	只能在DS上调用。

## 实例

![RemoveItemsByNameFunction](..\\..\\Resources\\RemoveItemsByNameFunction.png)
