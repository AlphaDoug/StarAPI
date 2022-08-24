# GetNextBagExpandInfo

## 格式

```C++
bool GetNextBagExpandInfo(EInventoryType type, FBagExpandItem& info);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	获取下一等级背包扩展信息。

## 参数

| 名称 | 类型           | 缺省 | 是否输出 | 描述         |
| ---- | -------------- | ---- | -------- | ------------ |
| type | EInventoryType |      |          | 背包类型     |
| info | FBagExpandItem |      | 是       | 背包扩展信息 |

## 返回值

| 类型 | 描述                                   |
| ---- | -------------------------------------- |
| bool | 是否可以找到数据，对应是否可以升级背包 |

## 调用位置

| 调用位置        | 是否可以调用 |
| --------------- | ------------ |
| Client          | 可以         |
| DedicatedServer | 可以         |

## 实例

![GetNextBagExpandInfoFunction](..\\..\\Resources\\GetNextBagExpandInfoFunction.png)
