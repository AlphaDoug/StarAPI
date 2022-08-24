# UInventoryComponent

## 1 基类

[UBaseInventoryComponent](..\\UBaseInventoryComponent\\UBaseInventoryComponent.html)

## 2 简介

​	玩家角色背包为UInventoryComponent，继承于继承背包UBaseInventoryComponent，玩家背包类中会定义自己特有的一些API。

​	此背包类中，除了自己特有API之外，也会有父类的所有API。

## 3 属性

| 数据类型 | 属性名称                                | 简介                     |
| -------: | :-------------------------------------- | :----------------------- |
|    FGuid |[UsingItem](Attributes\\UsingItem.html)| 当前正在读条使用的道具。 |

## 4 函数

|                                                 返回值 | 函数名称                                                     | 简介                                                         |
| -----------------------------------------------------: | ------------------------------------------------------------ | :----------------------------------------------------------- |
|                                                   void |[SetShowArmor](Function\\SetShowArmor.html)                 | 设置是否展示太空服盔甲。                                     |
|                                                  UItem |[GetEquipedItemBySlot](Function\\GetEquipedItemBySlot.html) | 根据装备槽位来获取当前装备的道具                             |
|                                                  FGuid |[GetEquipItemGuidBySlot](Function\\GetEquipItemGuidBySlot.html)| 根据装备槽位来获取当前装备的道具的GUID                       |
|                                                  FGuid |[GetQuickBarItemByIndex](Function\\GetQuickBarItemByIndex.html)| 根据快捷栏索引获取快捷栏的道具                               |
|                                                  FGuid |[GetQuickBarItemByType](Function\\GetQuickBarItemByType.html)| 根据快捷栏类型获取快捷栏的道具                               |
|                                                  int32 |[GetQuickBarWeaponIndexByUid](Function\\GetQuickBarWeaponIndexByUid.html)| 根据道具GUID获取快捷栏的索引，若道具不在快捷栏中返回-1       |
|                                                   void |[RefreshCharacterMeshes](Function\\RefreshCharacterMeshes.html)| 刷新角色的mesh                                               |
|                                         TArray<UItem*> |[GetDurabilityEquip](Function\\GetDurabilityEquip.html)     | 获取所有待修理的道具                                         |
|                                                   bool |[IsUseSpaceWear](Function\\IsUseSpaceWear.html)             | 是否使用太空服                                               |
|                                                   bool |[CheckSpaceWearError](Function\\CheckSpaceWearError.html)   | 检查穿脱时装是否有错误                                       |
|                                                   void |[GetCurrentFashions](Function\\GetCurrentFashions.html)     | 获取当前的时装                                               |
|                                                   bool |[OperateItem](Function\\OperateItem.html)                   | 操作道具，背包中所有道具的操作全部经由此接口进行，比如放入快捷栏，移出快捷栏等等。 |
|                                                   void |[ServerReformWeaponProp](Function\\ServerReformWeaponProp.html)| 只能在服务端进行调用，重铸武器词条                           |
|                                                   void |[ChangeWearFashions](Function\\ChangeWearFashions.html)     | 穿上时装或装备和脱下时装或装备，只能在服务端进行调用。       |
|                                                   void |[RequestRefreshStorage](Function\\RequestRefreshStorage.html)| 请求刷新仓库，此函数只能在服务端调用。                       |
|                                                   bool |[CheckWeaponCountMoreThanTwo](Function\\CheckWeaponCountMoreThanTwo.html)| 获取道具背包中所有包含了“qiangxie”的tag道具，若道具数量大于2则返回true，否则返回false。 |
|                                                   void |[ServerDropAllIndustryResources](Function\\ServerDropAllIndustryResources.html)| 丢弃所有工业背包中的道具，只能在服务端进行调用。             |
|                                                   bool |[CheckIndustryBagFull](Function\\CheckIndustryBagFull.html) | 监测当前工业资源背包时候已经满了。                           |
| TSet<[EEquipmentSlot](..\\Enum\\EEquipmentSlot.html)> |[CheckAvailableEquipSlot](Function\\CheckAvailableEquipSlot.html)| 获取当前可用的装备槽位。                                     |
|                                                   void |[ColorClothes](Function\\ColorClothes.html)                 | 时装染色接口。                                               |
|                                                FString |[GetClothStr](Function\\GetClothStr.html)                   | 获取当前角色服饰的字符串。                                   |
|                                                FString |[GetClothStrDisHeadAndBody](Function\\GetClothStrDisHeadAndBody.html)| 获取当前角色服饰的字符串。                                   |
|                                                FString |[TryOnEquip](Function\\TryOnEquip.html)                     | 道具装备试穿。                                               |
|                                                FString |[TryOnFashion](Function\\TryOnFashion.html)                 | 道具时装试穿。                                               |
|                                                   bool |[MakeItemColorInt](Function\\MakeItemColorInt.html)         | 构建道具的颜色结构体，从道具的自定义数据中取指定的三个值进行构建。 |
|                                                  int32 |[GetItemUseCounter](Function\\GetItemUseCounter.html)       | 查询指定ID的道具使用计数。                                   |
|                                                   void |[SetItemUseCounter](Function\\SetItemUseCounter.html)       | 设置指定ID的道具使用计数。                                   |
|                                                   bool |[GetNextBagExpandInfo](Function\\GetNextBagExpandInfo.html) | 获取下一等级背包扩展信息。                                   |
|                                                  int32 |[PlayerLevel](Function\\PlayerLevel.html)                   | 获取当前玩家的等级。                                         |
|                                                   void |[DeductDurabilityWhenDie](Function\\DeductDurabilityWhenDie.html)| 玩家死亡后扣除装备耐久度。                                   |
|                                                   void |[ServerUseIndustryPack](Function\\ServerUseIndustryPack.html)| 请求使用工业资源包道具，只能在服务器调用。                   |

## 5 事件

|                 事件类型 | 事件名称                                                     | 简介                   |
| -----------------------: | :----------------------------------------------------------- | :--------------------- |
| FOnItemUserCounterUpdate |[OnItemUserCounterUpdate](Event\\OnItemUserCounterUpdate.html)| 道具使用计数更新后触发 |
|      FOnShowArmorChanged |[OnShowArmorChanged](Event\\OnShowArmorChanged.html)        | 盔甲更改后触发         |