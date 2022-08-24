# PeekItem

## 格式

```C++
UItem* PeekItem();
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	从仓库中一个背包中取出一个道具，返回取出的道具。

## 参数

| 名称 | 类型 | 缺省 | 描述 |
| ---- | ---- | ---- | ---- |

## 返回值

| 类型  | 描述                                                         |
| ----- | ------------------------------------------------------------ |
| UItem | 仓库中有道具，则返回第一个取得的道具，若仓库中没有道具则返回空指针。 |

## 调用位置

​	服务器客户端均可，因为背包中的道具每次发生更改后都会自动同步给客户端。

## 实例

![PeekItemFunction](..\\..\\Resources\\PeekItemFunction.png)