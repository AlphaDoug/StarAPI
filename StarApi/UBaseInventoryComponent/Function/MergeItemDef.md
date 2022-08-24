# MergeItemDef

## 格式

```C++
static void MergeItemDef(UPARAM(Ref) TArray<FItemDef>& Items,bool bRecheckQuality = true,bool bClearZero = true);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	将道具定义的结构体进行合并，主要功能是将相同RowName的定义结构体合并为一个。

## 参数

| 名称            | 类型             | 缺省 | 是否输出 | 描述                                      |
| --------------- | ---------------- | ---- | -------- | ----------------------------------------- |
| Items           | TArray<FItemDef> |      |          | 想要合并的道具定义结构体。                |
| bRecheckQuality | bool             | true |          | 是否重新检查品质，即品质为All的会剔除掉。 |
| bClearZero      | bool             | true |          | 是否清除数量为0的定义                     |

## 返回值

| 类型 | 描述 |
| ---- | ---- |
| void | 无   |

## 调用位置

​	Client和DS都可以调用。	

## 实例

![MergeItemDefFunction](..\\..\\Resources\\MergeItemDefFunction.png)
