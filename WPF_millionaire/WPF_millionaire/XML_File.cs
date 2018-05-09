using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WPF_millionaire
{
    class XML_File
    {
        XmlDocument _doc;
        List<string> _answer;
        string _question;
        string _trueAnswer;

        public void Read(List<Question> list)
        {
            try
            {
                _answer = new List<string>();

                _doc = new XmlDocument();
                _doc.Load("XMLFile1.xml");

                var gameXML = _doc.DocumentElement;

                foreach (XmlNode questionXML in gameXML.ChildNodes)
                {
                    _answer.Clear();
                    _question = questionXML["question"].InnerText;
                    foreach (XmlNode answerXML in questionXML["answers"].ChildNodes)
                    {
                        _answer.Add(answerXML.FirstChild.Value);
                        if (answerXML.Attributes.Count > 0)
                        {
                            _trueAnswer = answerXML.FirstChild.Value;
                        }
                    }
                    list.Add(new Question(_question, _answer, _trueAnswer));
                }

            }
            catch (System.Xml.XmlException)
            {
            }
            catch (System.NullReferenceException)
            {
            }

        }
    }

    
}
