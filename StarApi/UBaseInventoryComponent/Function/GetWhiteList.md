# GetWhiteList

## 格式

```C++
virtual TSet<FName> GetWhiteList() { return TSet<FName>(); }
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	获取背包的白名单列表，只有设施和载具仓库中会对此函数进行重写已实现具体逻辑，默认返回空列表。

## 参数

| 名称 | 类型 | 缺省 | 是否输出 | 描述 |
| ---- | ---- | ---- | -------- | ---- |

## 返回值

| 类型        | 描述             |
| ----------- | ---------------- |
| TSet<FName> | 白名单道具ID列表 |

## 调用位置

​	Client和DS都可以调用。

## 实例

![GetWhiteListFunction](..\\..\\Resources\\GetWhiteListFunction.png)
