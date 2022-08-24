# GetItemsArrayWithConfig

## 格式

```C++
void GetItemsArrayWithConfig(TSet<FName> WhiteList, bool bUseWhiteList, TArray<UItem*>& Outitem, EInventoryType type = EInventoryType::Item);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	使用指定的白名单配置项进行获取道具。

## 参数

| 名称          | 类型           | 缺省                 | 是否输出 | 描述                     |
| ------------- | -------------- | -------------------- | -------- | ------------------------ |
| WhiteList     | TSet<FName>    |                      |          | 白名单列表               |
| bUseWhiteList | bool           |                      |          | 是否使用白名单           |
| Outitem       | TArray<UItem*> |                      | 是       | 获取到的道具             |
| type          | EInventoryType | EInventoryType::Item |          | 背包类型，默认为道具背包 |

## 返回值

| 类型 | 描述 |
| ---- | ---- |
| void | 无   |

## 调用位置

​	Client和DS都可以调用。

## 实例

​	项目中暂无蓝图中调用此函数的位置
