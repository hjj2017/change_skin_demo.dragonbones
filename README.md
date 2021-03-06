关于换装
====

操作全过程的视频地址：
https://www.bilibili.com/video/BV13K4y1V7QP

----

在龙骨（DragonBones）官方的例子中，给出了换装的演示。
但我感觉有点复杂，看着费劲（也许是我太笨了）。

最主要的问题是骨架结构太复杂了，很多细节也没有提到要怎么做？

假如我有两套套装，套装的各个零件可以互换的话，那么需要创建很多个 **龙骨项目文件（.dbproj）** 。
每个龙骨项目文件中都只放了一个套装的一个零件。
（官方提供的演示中似乎就是这么组织的）
从软件工程的角度来看，这样做会增加美术和技术的开发难度。

美术人员无法从单个 **龙骨项目文件** 中看到服装的全貌，只能观察每一个项目文件后，在脑海中拼接出完整的样子。
当然实际工作中也有可能是先在一个项目文件中拼出整图，调完动画，最后再将每个零件复制到新的项目文件中。
但不管怎么做，骨骼动画稍微复杂一点，整个工程就变得非常不可控。

所以我在这里使用了另外一个办法，就是通过 **“元件” + “Unity 预制体”** 的方式来实现换肤。

要实现骨骼动画，一般的做法是将 **插槽（Slot）** 放置到相应的 **骨骼（Bone）** 下。
骨骼动，插槽跟着动。插槽里又带着 **图片（也称作纹理 Texture）** ，所以我们就会看到图片在动。

但是要实现换装，就不能将插槽放到骨骼下了。
只能将插槽放到 **根骨骼（Root）** 下，
并且必须将插槽设置成 **“网格”** ，然后绑定到某个骨骼上。
这是实现换装的前提条件。

----

另外，官方的代码中有这样几句：

```CSharp
UnityFactory.factory.LoadDragonBonesData(dragonBonesJSONPath);
UnityFactory.factory.LoadTextureAtlasData(textureAtlasJSONPath);
UnityFactory.factory.BuildArmatureComponent("body");
```

这几句其实我不是很满意。

UnityFactory 拥有一个全局的成员变量 factory，而且还提供了 LoadXxx 函数，
这让我感觉工程很不可控。
因为可能会导致资源不被及时释放，
开发工程师可能会在用完资源之后忘记释放资源……
而 factory 又是个全局对象，
这确实是风险太高了！

而如果写成：

```CSharp
UnityFactory factory = new UnityFactory();
factory.LoadDragonBonesData(dragonBonesJSONPath);
factory.LoadTextureAtlasData(textureAtlasJSONPath);
factory.BuildArmatureComponent("body");
```

这样就会安心许多。
因为 factory 只是一个局部变量，
大概率上不会导致严重问题。

到底要不要把 UnityFactory 升格为全局的单例对象，
这个决定权应该交给开发者。
而不是框架擅自为我们做主……

这是从工程角度看代码引起的担忧，
应该不是所有人都像我一样会产生这样的忧虑……

----

## 通过元件组织换装资源

在龙骨 5.6.3 版本中，支持元件功能。
元件，可以理解为：在一个龙骨项目中可以存在多个骨架。骨架结构是否必须相同，这个没有约束。
我们可以利用元件来组织换装资源。
打开 Player_MissDie_.dbproj 文件中，可以看到 3 个元件。
- `Hair`，发型；
- `HeadAndFace`，头和表情；
- `_Default`，默认，这是完整的骨架；

为了方便展示，我只做了头部，只换装两个部位：发型和脸部。
这个例子掌握之后，再理解复杂骨架，就不是问题了。
