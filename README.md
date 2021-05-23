关于换装
====

在龙骨（DragonBones）官方的例子中，给出了换装的演示。
但我感觉有点复杂，看着费劲（也许是我太笨了）。

最主要的问题是骨架结构太复杂了，很多细节也没有提到要怎么做？

加入我有两套套装，套装的各个零件可以互换的话，那么需要创建很多个**龙骨项目文件（.dbproj）**。
每个龙骨项目文件中都只放了一个套装的一个零件。
（官方提供的演示中似乎就是这么组织的）
从软件工程的角度来看，这样做会增加美术和技术的开发难度。

美术人员无法从单个**龙骨项目文件**中看到服装的全貌，只能观察每一个项目文件后，在脑海中拼接出完整的样子。
当然实际工作中也有可能是先在一个项目文件中拼出整图，调完动画，最后再将每个零件复制到新的项目文件中。
但不管怎么做，骨骼动画稍微复杂一点，整个工程就变得非常不可控。

所以我在这里使用了另外一个办法，就是通过**“元件” + “Unity 预制体”**的方式来实现换肤。

要实现骨骼动画，一般的做法是将**插槽（Slot）**放置到相应的**骨骼（Bone）**下。
骨骼动，插槽跟着动。插槽里又带着**图片（也称作纹理 Texture）**，所以我们就会看到图片在动。

但是要实现换装，就不能将插槽放到骨骼下了。
只能将插槽放到**根骨骼（Root）**下，
并且必须将插槽设置成**“网格”**，然后绑定到某个骨骼上。
这是实现换装的前提条件。
