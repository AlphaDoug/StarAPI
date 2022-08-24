# GetMaxAmmo

## 格式

```C++
int32 GetMaxAmmo(const FGuid& uid, int32 modeIndex = -1);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	获取指定开火模式的最大子弹数量，开火模式为ItemHold表中配置的FireMode的数据。

## 参数

| 名称      | 类型  | 缺省 | 是否输出 | 描述                                                         |
| --------- | ----- | ---- | -------- | ------------------------------------------------------------ |
| uid       | FGuid |      |          | 道具枪械的GUID                                               |
| modeIndex | int32 | -1   |          | 开火模式的索引，若此参数小于零，则按照当前的开火模式进行获取。 |

## 返回值

| 类型  | 描述            |
| ----- | --------------- |
| int32 | ErrorID枚举类型 |

## 调用位置

​	Client和DS都可以调用。

## 实例

![GetMaxAmmoFunction](..\\..\\Resources\\GetMaxAmmoFunction.png)
