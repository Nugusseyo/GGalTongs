using UnityEngine;

[CreateAssetMenu(fileName = "TestSkill", menuName = "SkillSO/TestSkill")]
public class TestSkill : SkillSO
{
    protected override void Active()
    {
        Debug.Log("qweqweqweqweqw");
    }
}
