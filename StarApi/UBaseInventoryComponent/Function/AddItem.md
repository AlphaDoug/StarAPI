# AddItem

## 格式

```C++
int32 AddItem(UItem* pItem,  FItemOperateOptions Options);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	向此仓库中添加道具实体，和上面的添加道具接口的区别在于此接口添加的道具是现在已经存在的，上面的接口的道具是需要从道具定义结构体创建的。

## 参数

| 名称    | 类型                                                         | 缺省 | 是否输出 | 描述                                      |
| ------- | ------------------------------------------------------------ | ---- | -------- | ----------------------------------------- |
| pItem   | UItem                                                        |      |          | 道具实例                                  |
| Options | [FItemOperateOptions](..\\..\\Struct\\FItemOperateOptions.html) |      |          | 道具添加时的操作结构体FItemOperateOptions |

## 返回值

| 类型  | 描述            |
| ----- | --------------- |
| int32 | ErrorID枚举类型 |

## 调用位置

​	只能在DS上调用。

## 实例

​	项目中暂未在蓝图中有此函数。
