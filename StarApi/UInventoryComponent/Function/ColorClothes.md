# ColorClothes

## 格式

```C++
void ColorClothes(const TArray<FItemColor>& Colors, AMasterBuildPart* buildPart);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	时装染色接口。

## 参数

| 名称      | 类型                | 缺省 | 是否输出 | 描述                   |
| --------- | ------------------- | ---- | -------- | ---------------------- |
| Colors    | TArray<FItemColor>& |      |          | 道具染色配置结构体数组 |
| buildPart | AMasterBuildPart    |      |          | 染色发起的建筑实体     |

## 返回值

| 类型 | 描述 |
| ---- | ---- |
| void | 无   |

## 调用位置

| 调用位置        | 是否可以调用           |
| --------------- | ---------------------- |
| Client          | 可以调用，但是无效果   |
| DedicatedServer | 可以，应该在此进行调用 |

## 实例

![ColorClothesFunction](..\\..\\Resources\\ColorClothesFunction.png)
