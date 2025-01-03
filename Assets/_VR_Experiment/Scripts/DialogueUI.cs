using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MySampleEx
{
    /// <summary>
    /// 대화 창 구현 클래스
    /// </summary>
    /// 대화 데이터 파일 읽기
    /// 대화 데이터 UI 적용
    public class DialogueUI : MonoBehaviour
    {
        #region Variables
        // XML
        public string xmlFile = "Dialogue/Dialogue";    // Path
        private XmlNodeList allNodes;

        // Dialogue 에셋 저장용 Collection
        private Queue<Dialogue> dialogues = new();

        // UI
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI sentenceText;
        public GameObject npcImage;
        public GameObject nextButton;

        // 최적화
        private IEnumerator dialogueCor;
        #endregion

        private void Start()
        {
            // xml 데이터 파일 읽기
            LoadDialogueXml(xmlFile);

            StartDialogue(0);
        }

        private void Initialize()
        {
            dialogues.Clear();
            npcImage.SetActive(false);
            nameText.text = "";
            sentenceText.text = "";
        }

        // Xml 데이터 읽기
        private void LoadDialogueXml(string path)
        {
            TextAsset xmlFile = Resources.Load<TextAsset>(path);
            
            XmlDocument xmlDoc = new();
            xmlDoc.LoadXml(xmlFile.text);
            allNodes = xmlDoc.SelectNodes("root/Dialogue");
        }

        // 대화 시작하기
        public void StartDialogue(int dialogueIndex)
        {
            Initialize();

            foreach (XmlNode node in allNodes)
            {
                int num = int.Parse(node["number"].InnerText);
                if (num == dialogueIndex)
                {
                    Dialogue dialogue = new()
                    {
                        number = num,
                        character = int.Parse(node["character"].InnerText),
                        name = node["name"].InnerText,
                        sentence = node["sentence"].InnerText,
                    };

                    dialogues.Enqueue(dialogue);
                }
            }

            // 첫 번째 대화를 보여준다
            DrawNextDialogue();
        }

        // 다음 대화를 보여준다 - (큐)dialogue에서 하나 꺼내어 보여주기
        public void DrawNextDialogue()
        {
            // dialogues Check
            if (dialogues.Count == 0)
            {
                EndDialogue();
                return;
            }

            // dialogues에서 하나 꺼내기
            Dialogue dialogue = dialogues.Dequeue();

            if (dialogue.character > 0)
            {
                npcImage.SetActive(true);
                npcImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(
                    "Dialogue/Npc/npc0" + dialogue.character.ToString());
            }
            else // dialogue.character <= 0
            {
                npcImage.SetActive(false);
            }

            nameText.text = dialogue.name;
            //sentenceText.text = dialogue.sentence;
            if (dialogueCor != null)
            {
                StopCoroutine(dialogueCor);
                dialogueCor = null;
            }
            dialogueCor = typingSentence(dialogue.sentence);
            StartCoroutine(dialogueCor);
        }

        // 텍스트 타이핑 연출
        IEnumerator typingSentence(string typingText)
        {
            sentenceText.text = "";

            foreach (char letter in typingText)
            {
                sentenceText.text += letter;
                yield return new WaitForSeconds(0.02f);
            }

            yield break;
        }

        // 대화 종료
        public void EndDialogue()
        {
            Initialize();

            // 대화 종료 시 이벤트 처리
            this.gameObject.SetActive(false);
        }

        #region Buttons
        public void Dialogue_Zero()
        {
            StartDialogue(0);
        }
        public void Dialogue_One()
        {
            StartDialogue(1);
        }
        public void Dialogue_Two()
        {
            StartDialogue(2);
        }
        #endregion
    }
}