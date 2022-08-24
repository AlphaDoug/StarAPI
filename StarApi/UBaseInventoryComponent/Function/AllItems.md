# AllItems

## 格式

```C++
virtual int32 AllItems(TArray<UItem*>& list, const FName& rowName = "", EInventoryType type = EInventoryType::All,EItemQuality Quality= EItemQuality::None);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	获取所有符合rowName的道具，此接口和上面的接口区别为可以获取所有的道具。

## 参数

| 名称    | 类型           | 缺省                | 是否输出 | 描述               |
| ------- | -------------- | ------------------- | -------- | ------------------ |
| list    | TArray<UItem*> |                     | 是       | 获取的道具实例数组 |
| rowName | FName          | ""                  |          | 道具ID             |
| type    | type           | EInventoryType::All |          | 背包类型           |
| Quality | Quality        | EItemQuality::None  |          | 道具品质           |

## 返回值

| 类型  | 描述           |
| ----- | -------------- |
| int32 | 获取的道具数量 |

## 调用位置

​	DS和Client均可。

## 实例

![AllItemsFunction](..\\..\\Resources\\AllItemsFunction.png)
