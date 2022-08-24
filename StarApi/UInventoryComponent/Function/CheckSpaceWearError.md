# CheckSpaceWearError

## 格式

```C++
bool CheckSpaceWearError(UItem* item, bool bWear, int32& error);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	检查穿脱时装是否有错误

## 参数

| 名称  | 类型  | 缺省 | 是否输出 | 描述                          |
| ----- | ----- | ---- | -------- | ----------------------------- |
| item  | UItem |      |          | 装备道具的实体                |
| bWear | bool  |      |          | bool类型，true为穿，false为脱 |
| error | int32 |      | 是       | 返回的错误ID，为ErrorID类型   |

## 返回值

| 类型 | 描述                              |
| ---- | --------------------------------- |
| bool | 若检查通过则返回true否则返回false |

## 调用位置

| 调用位置        | 是否可以调用 |
| --------------- | ------------ |
| Client          | 可以         |
| DedicatedServer | 可以         |

## 实例

暂无
