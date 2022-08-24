# UBaseInventoryComponent

## 1 基类

UStarsActorComponent

## 2 简介

​	所有背包对象的基类都是此类，此类中定义了基础的背包仓库中一些操作函数和相应的数据属性。

​	此基类中有一个属性m_Bags，用来存储此仓库中所有的道具，此属性为一个TMap类型，Key为背包类型，Value为一个背包数据结构体，所有的道具实体对象都放在这个TMap的Value中的结构体中。

## 3 属性

| 数据类型 | 属性名称                                             | 简介                       |
| -------: | :--------------------------------------------------- | :------------------------- |
|     bool | [CanTransferItemIn](Attributes\\CanTransferItemIn.html) | 仓库是否可以转移进入道具   |
|    int32 | [BagFullErrorId](Attributes\\BagFullErrorId.html)       | 背包满包的ErrorID          |
|     bool | [ForceStack](Attributes\\ForceStack.html)               | 是否强制堆叠               |
|    int32 | [StackOverride](Attributes\\StackOverride.html)         | 堆叠覆盖数量               |
|     bool | [Allowadd](Attributes\\Allowadd.html)                   | 是否允许重复添加相同的道具 |

## 4 函数

|                                         返回值 | 函数名称                                                     | 简介                                                         |
| ---------------------------------------------: | ------------------------------------------------------------ | :----------------------------------------------------------- |
|                                           bool | [CheckBagTotalSize](Function\\CheckBagTotalSize.html)         | 检查背包是否可以放下指定一些类型道具                         |
|                  [ErrorID](..\\Enum\\ErrorID.html) | [CheckBagSize](Function\\CheckBagSize.html)                     | 检查背包是否可以放下指定一种道具                             |
|                                           bool | [CheckBagFilling](Function\\CheckBagFilling.html)               | 把一些道具放进背包仓库中后，会有多少道具放不下               |
|                  [ErrorID](..\\Enum\\ErrorID.html) | [TransferItemTo](Function\\TransferItemTo.html)                 | 将指定GUID的道具从当前的背包中转移到另一个背包中             |
|                                           void | [ClearAllItems](Function\\ClearAllItems.html)                   | 将指定类型的背包中的所有道具全部清除                         |
|                                          UItem | [PeekItem](Function\\PeekItem.html)                             | 从仓库中一个背包中取出一个道具                               |
|                                           void | [MakeExtItemLog](Function\\MakeExtItemLog.html)                 | 记录额外的道具操作log                                        |
|                                          int32 | [AllItemCount](Function\\AllItemCount.html)                     | 获取指定背包类型中的所有道具数量                             |
|                                    TSet<FName> | [GetWhiteList](Function\\GetWhiteList.html)                     | 获取背包的白名单列表                                         |
|                                           bool | [CheckItem](Function\\CheckItem.html)                           | 检查给定道具的数量在背包中是否大于给出的数量                 |
|                                           bool | [CheckItems](Function\\CheckItems.html)                         | 检查给定一些道具的数量在背包中是否大于给出的数量             |
|                                          int32 | [GetItemCount](Function\\GetItemCount.html)                     | 获取指定ID和品质的道具在此仓库中的数量                       |
|                                          int32 | [GetInventoryCapacity](Function\\GetInventoryCapacity.html)     | 取指定类型背包的最大容量                                     |
|                                          int32 | [GetOccupiedCapacity](Function\\GetOccupiedCapacity.html)       | 取指定类型背包已使用的容量                                   |
|                              TMap<FName,int32> | [GetNameCountMap](Function\\GetNameCountMap.html)               | 获取指定的几种类型背包中的道具名称与数量                     |
|      TArray<[FItemDef](..\\Struct\\FItemDef.html)> | [GetNameCountArray](Function\\GetNameCountArray.html)           | 获取指定的几种类型背包中的道具名称与数量                     |
|                                          int32 | [FillAmmo](Function\\FillAmmo.html)                             | 给枪械类型的道具添加子弹                                     |
|                                          int32 | [GetMaxAmmo](Function\\GetMaxAmmo.html)                         | 获取指定开火模式的最大子弹数量                               |
|                                           bool | [DoFireCost](Function\\DoFireCost.html)                         | 枪械道具开火后进行相应子弹消耗                               |
|                                           bool | [SetItemCustomParam](Function\\SetItemCustomParam.html)         | 设置指定道具的自定义数据                                     |
|                                          float | [GetSortKey](Function\\GetSortKey.html)                         | 获取指定道具的排序值                                         |
|                                      UItemBase | [GetItemBase](Function\\GetItemBase.html)                       | 获取指定道具的模板                                           |
|                                          int32 | [AddItemByName](Function\\AddItemByName.html)                   | 根据道具定义结构体添加指定数量的一种道具                     |
|                                          int32 | [AddItemsByName](Function\\AddItemsByName.html)                 | 根据道具定义结构体添加指定数量的一些道具                     |
|                                          int32 | [RemoveItemByName](Function\\RemoveItemByName.html)             | 根据道具定义结构体从仓库中移除指定数量的道具                 |
|                                          int32 | [RemoveItemsByName](Function\\RemoveItemsByName.html)           | 根据道具定义结构体从仓库中移除指定数量的一些道具             |
|                                          int32 | [AddItem](Function\\AddItem.html)                               | 向此仓库中添加道具实体                                       |
| bool,TArray<[FItemDef](..\\Struct\\FItemDef.html)> | [AddItemTry](Function\\AddItemTry.html)                         | 向此仓库中尽可能添加道具直到放不下，然后得到剩余放不下的道具 |
|                                          int32 | [RemoveItem](Function\\RemoveItem.html)                         | 从此仓库中全部移除指定uid的道具                              |
|                                           bool | [RemoveItemByCount](Function\\RemoveItemByCount.html)           | 从此仓库中移除一定数量的指定uid的道具                        |
|                                          UItem | [GetItem](Function\\GetItem.html)                               | 根据道具GUID从指定类型的背包中获取道具实体                   |
|                                          UItem | [GetItemByName](Function\\GetItemByName.html)                   | 根据道具RowName从指定类型的背包中获取道具实体                |
|                           TArray<UItem*>, bool | [AllItems](Function\\AllItems.html)                             | 获取所有符合rowName的道具                                    |
|                                           void | [SynchItem](Function\\SynchItem.html)                           | 同步道具的更改                                               |
|                                           void | [MergeItemDef](Function\\MergeItemDef.html)                     | 将道具定义的结构体进行合并                                   |
|                                           void | [DecreaseItemDurability](Function\\DecreaseItemDurability.html) | 减少道具的耐久度                                             |
|                                          float | [GetDurabilityMaxByName](Function\\GetDurabilityMaxByName.html) | 获取指定id的道具的最大耐久度                                 |
|                                           void | [CheckItemExpire](Function\\CheckItemExpire.html)               | 检查道具是否超时                                             |

## 5 事件

|                   事件类型 | 事件名称                                                     | 简介                                 |
| -------------------------: | :----------------------------------------------------------- | :----------------------------------- |
| FOnInventoryItemReplicated | [OnInventoryItemReplicated](Event\\OnInventoryItemReplicated.html) | 仓库中道具发生变化后的同步事件       |
|   FFacilityInventoryChange | [FacilityChange](Event\\FacilityChange.html)                  | 设施仓库中的道具发生变化后的同步事件 |

 



