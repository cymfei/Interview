using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChoiceQuestion
{
    /// <summary>
    /// 返回答案
    /// </summary>
    /// <returns></returns>
    List<ChoiceQuestionData> ChoiceQuestionDataList = new List<ChoiceQuestionData>(); 
    /// <summary>
    /// 选择问题
    /// </summary>
    /// <param name="questindex">问题索引</param>
    /// <param name="seleceindex">选择索引</param>
    /// <returns></returns>
    bool Answer(int questindex,int seleceindex)  
    {
        foreach(ChoiceQuestionData data in ChoiceQuestionDataList)
        {
            if (data.id == questindex && data.isRight == seleceindex)
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// 问题展示的类型
    /// </summary
    public enum QuestionType
    {
        Text = 0,
        Audio,
        Texture,
        Video,
    }
}
/// <summary>
/// 题的数据结构
/// </summary>
public class ChoiceQuestionData
{
    public string describe = string.Empty;                 //题的描述
    public int id = -1;                                    //题的id
    public ChoiceQuestion.QuestionType Questype;           //资源类型
    public string url = string.Empty;                      //下载地址
    public int isRight = 0;                                //正确答案索引
    public int answernum = 0;                              //正确答案数量
}
