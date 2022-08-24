# TransferItemTo

## 格式

```C++
virtual ErrorID TransferItemTo(UBaseInventoryComponent* To, const FGuid& UID, int32 Count = 1, int32 method = -1, AMasterBuildPart* buildPart = nullptr);
```

## 简介

<span style="padding: 4px 6px; font-size: 12px; display: inline-block; color: #FFFFFF; background: #FFC547;">函数</span>

​	将指定GUID的道具从当前的背包中转移到另一个背包中，其中后面两个参数是用来进行事件发送，日志记录的。

## 参数

| 名称      | 类型                    | 缺省    | 是否输出 | 描述                                                         |
| --------- | ----------------------- | ------- | -------- | ------------------------------------------------------------ |
| To        | UBaseInventoryComponent |         |          | 想要转移的目标仓库。                                         |
| UID       | FGuid                   |         |          | 道具实体的GUID。                                             |
| Count     | int32                   | 1       |          | 想要转移的数量。                                             |
| method    | int32                   | -1      |          | 转移方式，对应事件途径枚举EventMethod，默认为-1，若当前仓库是载具的，则此方式会被覆盖为Method_VehicleTakeOut（载具取出126）；若当前仓库是设施的，则此方式会被覆盖为Method_Facility_Take（从设施交互物取出102）；若当前的设施组件有“Product”Tag，则此方式会覆盖为Method_Facility_Product（从设施产出栏中取出110）。 |
| buildPart | AMasterBuildPart        | nullptr |          | 目标背包所属建筑，一般不填写，由程序自动进行赋值。           |

## 返回值

| 类型    | 描述       |
| ------- | ---------- |
| ErrorID | 通用错误码 |

## 调用位置

​	只能在DS上进行调用。

## 实例

![TransferItemToFunction](..\\..\\Resources\\TransferItemToFunction.png)