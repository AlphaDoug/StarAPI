# GetItemBase

## 格式

```C++
UItemBase* GetItemBase(const FName& rowName);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	获取指定道具的模板。

## 参数

| 名称    | 类型  | 缺省 | 是否输出 | 描述     |
| ------- | ----- | ---- | -------- | -------- |
| rowName | FName |      |          | 道具的ID |

## 返回值

| 类型      | 描述                       |
| --------- | -------------------------- |
| UItemBase | ItemBase类型的道具模板对象 |

## 调用位置

​	Client和DS都可以调用。

## 实例

​	暂未在蓝图中使用
