# CheckBagTotalSize

## 格式

```C++
virtual bool CheckBagTotalSize(const TArray<FItemDef>& Items);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	检查背包仓库是否可以放下指定一些道具。

## 参数

| 名称  | 类型             | 缺省 | 是否输出 | 描述                                 |
| ----- | ---------------- | ---- | -------- | ------------------------------------ |
| Items | TArray<FItemDef> |      |          | FItemDef数组，可以在蓝图中进行定义。 |

## 调用位置

​	服务器客户端均可，因为背包中的道具每次发生更改后都会自动同步给客户端。

## 返回值

| 类型 | 描述                                |
| ---- | ----------------------------------- |
| bool | 若可以放下则返回true，否则返回false |

## 实例

![CheckBagTotalSizeFunction](..\\..\\Resources\\CheckBagTotalSizeFunction.png)