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
    /// ( Я�̷�ʽ ) �޸�Ƥ��
    /// </summary>
    /// <returns>ö�ٵ�����</returns>
    private IEnumerator ChangeSkin_XC()
    {
        WaitForSeconds wait = new WaitForSeconds(2);
        yield return wait;

        // �ҵ� Player ����
        GameObject player = GameObject.Find("/Player");

        ////////////////////////////////
        // ����èŮ�ķ���
        // 
        GameObject goHair = Resources.Load<GameObject>("Playerz/Player_CatGirl_/Skin/Hair");
        goHair = GameObject.Instantiate<GameObject>(goHair);
        goHair.SetActive(false); 
        // XXX ע��: ����ֻ�ǽ��� Prefab ȡ�������Ƥ������, ��������Ҫʹ����!
        // ����ֱ�����ؼ���...

        // ͨ�����Ǵ������ṩ�� UnityFactory, �滻Ƥ��.
        // ��δ�������ǹٷ��ṩ�� Demo ����һ��,
        // ��ͬ�ĵط�����: ������ͨ�� Prefab ��ʵ�������е��������������Ƥ��...
        // ���� Prefab, �����Ƿ���Խ�������Ϊ Bundle?
        // �����Ϳ��Խ�ȫ����Դ�ŵ� CDN ��������...
        UnityFactory.factory.ReplaceSkin(
            player.GetComponentInChildren<UnityArmatureComponent>().armature,
            goHair.GetComponent<UnityArmatureComponent>().armature.armatureData.defaultSkin
        );

        Destroy(goHair);
        yield return wait;

        ////////////////////////////////
        // ����èŮ�ı���
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
        // ���� MissDie �ķ���
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
