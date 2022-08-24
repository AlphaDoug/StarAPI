# GetItem

## 格式

```C++
UItem* GetItem(const FGuid& uid, EInventoryType type = EInventoryType::All);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	根据道具GUID从指定类型的背包中获取道具实体。

## 参数

| 名称 | 类型 | 缺省                | 是否输出 | 描述                                                         |
| ---- | ---- | ------------------- | -------- | ------------------------------------------------------------ |
| uid  |      |                     |          | 道具GUID。                                                   |
| type |      | EInventoryType::All |          | 背包类型枚举值，若填写all，则会从所有的背包中寻找符合uid的道具 |

## 返回值

| 类型  | 描述                                                         |
| ----- | ------------------------------------------------------------ |
| UItem | 若可以成功获取到道具，则返回道具实体指针UItem*，否则返回空指针。 |

## 调用位置

​	Client和DS都可以调用。

## 实例

![GetItemFunction](..\\..\\Resources\\GetItemFunction.png)