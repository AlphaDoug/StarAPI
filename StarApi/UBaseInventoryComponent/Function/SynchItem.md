# SynchItem

## 格式

```C++
void SynchItem(UItem* pItem = nullptr, bool bSendImmediate = true);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	同步道具的更改，一般不会在蓝图中进行调用。

## 参数

| 名称           | 类型  | 缺省    | 是否输出 | 描述                         |
| -------------- | ----- | ------- | -------- | ---------------------------- |
| pItem          | UItem | nullptr |          | 想要同步的道具实体           |
| bSendImmediate | bool  | true    |          | 是否立刻进行同步，默认为true |

## 返回值

| 类型 | 描述 |
| ---- | ---- |
| void | 无   |

## 调用位置

​	DS和Client均可以调用，但是若在Client中进行调用的话，不会通知DS，只会在本地进行广播。所以一般在DS中进行调用。

## 实例

​	项目中暂无蓝图中调用此函数。
