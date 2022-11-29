using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Net.Mime.MediaTypeNames;

namespace 윈폼계산기
{
    public partial class Form1 : Form
    {

        // 계산기에서 사용할  전역 변수 선언
        double num1, num2; // 두 수 저장할 변수  
        string buff = "";         // 임시 보관 할 변수
        string output = "";      // 임시 출력 할 변수
        char oper;               // 연산자 저장할 변수 + , - , * , /
        double result;          // 결과 값 저장할 변수 

        bool first = true;
        //숫자 버튼 클릭 이벤트
        private void bt_num_Click(object sender, EventArgs e)
        {//숫자 버튼들의 Click 이벤트를 전부 동일한 이벤트에 연결시켜 사용한다.
            Button btn = (Button)sender; //버튼 이벤트 객체 생성
            buff += btn.Text;        //buff 에 해당 버튼의 글자를 이어붙여 넣는다.
            output += btn.Text;      //출력 output변수도 위와 동일
            textBox1.Text = output;  //계산기 메인 텍스트 창에 숫자를 추가한다

            if (first)
            {
                num1 = Convert.ToDouble(output);
            }
            else
            {
                string[] nums = buff.Split(oper);
                num2 = Convert.ToDouble(nums[1]);
            }
        }

        //연산 기호 클릭 이벤트
        private void bt_oper_Click(object sender, EventArgs e)
        {//숫자 버튼들의 Click 이벤트를 전부 동일한 이벤트에 연결시켜 사용한다.
            Button btn = (Button)sender; //버튼 이벤트 객체 생성
            buff += btn.Text;        //buff 에 해당 버튼의 글자를 이어붙여 넣는다.
            output += btn.Text;      //출력 output변수도 위와 동일
            first = false;
            textBox1.Text = output;  //계산기 메인 텍스트 창에 숫자를 추가한다
            oper = Convert.ToChar(btn.Text);
        }


        private void bt_clear_Click(object sender, EventArgs e)
        {
            first = true;
            Button btn = (Button)sender; //버튼 이벤트 객체 생성
            buff = "";        //buff 내용 삭제
            output = "";      //출력 변수 내용 삭제
            result = 0;
            oper = '\u0000'; //char 의 초기화는 ""로 불가능함
            textBox1.Text = output;
        }

        //계산 버튼 클릭 이벤트
        private void bt_calc_click(object sender, EventArgs e)
        {
            Cal();
        }

        private void Cal()
        {//메인 계산 함수.
            if (oper == Convert.ToChar("-"))
            {
                result = num1 - num2;
            }
            else if (oper == Convert.ToChar("+"))
            {
                result = num1 + num2;
            }
            else if (oper == Convert.ToChar("*"))
            {
                result = num1 * num2;
            }
            else if (oper == Convert.ToChar("^"))
            {
                result = Math.Pow(num1, num2);
            }
            else if (oper == Convert.ToChar("%"))
            {
                result = (num1 / 100) * num2;
            }
            else if (oper == Convert.ToChar("/"))
            {
                result = num1 / num2;
            }
            else if (oper == Convert.ToChar("!"))
            {
                int num12 = Convert.ToInt32(num1);
                for (int i = num12 - 1; i > 0; i--)
                {//int 범위를 초과하는 Factorial 계산 시 0 출력
                    num12 *= i;
                    result = num12;
                }
            }
            else if (oper == Convert.ToChar("√"))
            {
                result = Math.Sqrt(num1);
            }
            buff = result.ToString();
            output = result.ToString();
            textBox1.Text = result.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // 3 + 8 = 11 계산일 경우 예를 들어 설명함

        public Form1()
        {
            InitializeComponent();
        }

    }
}
