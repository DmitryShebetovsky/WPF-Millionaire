using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_millionaire
{
    public class Question
    {
        string _question;
        List<string> _answer;
        string _trueAnswer;

        public string QuestionStr { get { return _question; } }
        public List<string> Answer { get { return _answer; } }
        public string TrueAnswer { get { return _trueAnswer; } }

        public Question(string question, List<string> answer, string trueAnswer)
        {
            this._question = question;
            this._answer = new List<string>();
            for (int i = 0; i < answer.Count; i++)
            {
                this._answer.Add(answer[i]);
            }
            this._trueAnswer = trueAnswer;
        }
    }
}
