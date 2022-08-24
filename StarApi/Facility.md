# 导航目录





# 结构说明

## 1.类继承关系

​	建筑部件是一个Actor，建筑部件绝大部分时候无法直接种植在场景中，都是通过建筑的方式在场景中生成；建筑部件的类继承如下：

​	Actor→BaseActor→MasterBuildPart→FacilityBase

​	建筑部件从策划逻辑上分为两类：

- 结构部件：除了功能设施以外的所有部件都为结构部件，结构部件类型均为AMasterBuildPart的子类，比如地板，地基，墙等等。
- 功能设施：设施的类型为AFacilityBase，继承AmasterBuildPart，并且实现了接口IInteractionInterface的OnInteract方法，以实现交互逻辑，比如组装台，熔炉等。

## 2.**交互接口**

​	交互接口属于接口类，任何想要通过客户端点击实现客户端交互功能的Actor都需要继承并且实现该接口。

- 交互接口的继承方法：

  注意如果在创建Actor时选择继承了BaseActor及其子类，创建的Actor将自动继承Interaction Interface（交互接口）以及Stars Unit Interface两个接口。只有以Actor为基类创建子类时，才需要手动添加交互接口。

  手动添加交互接口时，首先选中Class Setting，然后在Details面板中的Interfaces选项中，选择Add，添加想要的接口即可。

- 接口在FacilityBase类中的整体流程：

![Building_1](Resources\Building_1.png)

视频测试

<iframe height=498 width=510 src="Resources/录制_2022_06_05_23_47_49_919.mp4">


## 3.交互接口包含的方法

### 3.1 交互接口方法的实现

​	继承或添加了Interaction Interface交互接口的类会在Graphs面板中显示这个接口可用的所有方法。

![Building_2](Resources\Building_2.png)

​	右键单击特定的方法可以对接口进行实现（implenment event），没有在蓝图中实现的接口会按默认的方式执行。

### 3.2 交互接口方法的种类

| 返回值 | 函数名称           | 简介                         |
| -----: | ------------------ | :--------------------------- |
|   void | GetNameBoard       | 获取姓名版信息。             |
|        | GetInteractInfo    | 获取交互信息。               |
|        | GetInteractionType | 点击交互后获取到的可交互选项 |
|        | OnInteract         |                              |
|        |                    |                              |

- GetNameBoard

- - 作用：获取姓名版信息，当摄像机射线打中时会调用该方法，属于摄像机所属Character的本地客户端逻辑。

- GetInteractInfo

- - 作用：获取交互信息，摄像机所属的Character的本地客户端逻辑；该交互信息指游戏中出现的交互列表；
  - 输入参数：
    - Vertical Dis：玩家与设施的垂直距离。当该距离大于允许交互的最小高度差时，会将bool变量Can Interact设为true。
  - 返回值：
    - Can Interact：决定是否允许交互。
    - Display Name
    - Style：决定交互类型的图标
  - 蓝图中实现

- - ![Building_3](Resources\Building_3.png)

  - 
