# DoFireCost

## 格式

```C++
virtual bool DoFireCost(const FGuid& uid, EFireType fireType, float fireCD, FName bulletName = NAME_None);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	枪械道具开火后进行相应子弹消耗

## 参数

| 名称       | 类型      | 缺省      | 是否输出 | 描述                                   |
| ---------- | --------- | --------- | -------- | -------------------------------------- |
| uid        | FGuid     |           |          | 道具枪械的GUID                         |
| fireType   | EFireType |           |          | EFireType类型，开火方式枚举类型。      |
| fireCD     | float     |           |          | 开火的冷却时间                         |
| bulletName | FName     | NAME_None |          | 开火后使用的子弹道具ID，默认不使用子弹 |

## 返回值

| 类型 | 描述             |
| ---- | ---------------- |
| bool | 开火消耗是否成功 |

## 调用位置

​	只能在DS上进行调用。

## 实例

​	项目中暂无蓝图调用。
