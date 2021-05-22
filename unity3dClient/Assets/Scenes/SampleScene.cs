using DragonBones;

using System.Collections;

using UnityEngine;

public class SampleScene : MonoBehaviour
{
    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        StartCoroutine(ChangeSkin_XC());
    }

    /// <summary>
    /// ( 携程方式 ) 修改皮肤
    /// </summary>
    /// <returns>枚举迭代器</returns>
    private IEnumerator ChangeSkin_XC()
    {
        WaitForSeconds wait = new WaitForSeconds(2);
        yield return wait;

        // 找到 Player 对象
        GameObject player = GameObject.Find("/Player");

        ////////////////////////////////
        // 换到猫女的发型
        // 
        GameObject goHair = Resources.Load<GameObject>("Playerz/Player_CatGirl_/Skin/Hair");
        goHair = GameObject.Instantiate<GameObject>(goHair);
        goHair.SetActive(false); 
        // XXX 注意: 我们只是借助 Prefab 取得上面的皮肤数据, 并不真正要使用它!
        // 所以直接隐藏即可...

        // 通过龙骨代码中提供的 UnityFactory, 替换皮肤.
        // 这段代码和龙骨官方提供的 Demo 几乎一样,
        // 不同的地方在于: 我们是通过 Prefab 的实例对象中的龙骨数据来获得皮肤...
        // 关于 Prefab, 我们是否可以将其设置为 Bundle?
        // 这样就可以将全部资源放到 CDN 服务器上...
        UnityFactory.factory.ReplaceSkin(
            player.GetComponentInChildren<UnityArmatureComponent>().armature,
            goHair.GetComponent<UnityArmatureComponent>().armature.armatureData.defaultSkin
        );

        Destroy(goHair);
        yield return wait;

        ////////////////////////////////
        // 换到猫女的表情
        // 
        GameObject goHeadAndFace = Resources.Load<GameObject>("Playerz/Player_CatGirl_/Skin/HeadAndFace");
        goHeadAndFace = GameObject.Instantiate<GameObject>(goHeadAndFace);
        goHeadAndFace.SetActive(false);

        UnityFactory.factory.ReplaceSkin(
            player.GetComponentInChildren<UnityArmatureComponent>().armature,
            goHeadAndFace.GetComponent<UnityArmatureComponent>().armature.armatureData.defaultSkin
        );

        Destroy(goHeadAndFace);
        yield return wait;

        ////////////////////////////////
        // 换到 MissDie 的发型
        // 
        goHair = Resources.Load<GameObject>("Playerz/Player_MissDie_/Skin/Hair");
        goHair = GameObject.Instantiate<GameObject>(goHair);
        goHair.SetActive(false);

        UnityFactory.factory.ReplaceSkin(
            player.GetComponentInChildren<UnityArmatureComponent>().armature,
            goHair.GetComponent<UnityArmatureComponent>().armature.armatureData.defaultSkin
        );

        Destroy(goHair);
        yield return wait;
    }
}
