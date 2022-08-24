# CheckBagSize

## 格式

```C++
virtual ErrorID CheckBagSize(const FItemDef& item, EInventoryType type = EInventoryType::All);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	检查一个有指定数量的道具，是否可以放进某个类型的背包仓库中，背包类型默认为All，若为All则会检测此道具配置属性中的背包类型。

## 参数

| 名称 | 类型           | 缺省               | 是否输出 | 描述                   |
| ---- | -------------- | ------------------ | -------- | ---------------------- |
| Item | FItemDef       |                    |          | 道具定义FItemDef结构体 |
| type | EInventoryType | EInventoryType:All |          | 要检测的背包类型       |

## 返回值

| 类型    | 描述             |
| ------- | ---------------- |
| ErrorID | 通用错误码枚举值 |

## 调用位置

​	服务器客户端均可，因为背包中的道具每次发生更改后都会自动同步给客户端。

## 实例

![CheckBagTotalSizeFunction](..\\..\\Resources\\CheckBagSizeFunction.png)