# RemoveItemByCount

## 格式

```C++
virtual bool RemoveItemByCount(const FGuid& UID, const int32 Count, FItemOperateOptions Options);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	从此仓库中移除指定uid的道具，需要传入移除的道具的数量。

## 参数

| 名称    | 类型                | 缺省 | 是否输出 | 描述                                          |
| ------- | ------------------- | ---- | -------- | --------------------------------------------- |
| UID     | FGuid               |      |          | 想移除的道具GUID。                            |
| Count   | int32               |      |          | 移除的数量，若大于道具总数量，则函数返回false |
| Options | FItemOperateOptions |      |          | 移除道具的操作结构体FItemOperateOptions       |

## 返回值

| 类型 | 描述                                  |
| ---- | ------------------------------------- |
| bool | 移除成功后返回true，失败后返回false。 |

## 调用位置

​	只能在DS上调用

## 实例

![RemoveItemByCountFunction](..\\..\\Resources\\RemoveItemByCountFunction.png)
