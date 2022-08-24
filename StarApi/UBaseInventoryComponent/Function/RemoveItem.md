# RemoveItem

## 格式

```C++
virtual int32 RemoveItem(const FGuid& uid, FItemOperateOptions Options);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	从此仓库中移除指定uid的道具，全部移除，不管有多少数量。

## 参数

| 名称    | 类型                | 缺省 | 是否输出 | 描述                 |
| ------- | ------------------- | ---- | -------- | -------------------- |
| uid     | FGuid               |      |          | 道具GUID             |
| Options | FItemOperateOptions |      |          | 移除道具的操作结构体 |

## 返回值

| 类型  | 描述          |
| ----- | ------------- |
| int32 | ErrorID枚举值 |

## 调用位置

​	只能在DS上进行调用。

## 实例

​	项目中蓝图没有调用此函数。
