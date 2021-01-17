using System;
using System.Windows.Forms;
using CalcMiniScript;

namespace Demo
{
    public partial class Main : Form
    {
       private readonly CalcCompiller _compiler = new CalcCompiller();
        public Main()
        {
            InitializeComponent();
        }
        private void ButtonsClick(object sender, EventArgs e)
        {
            textView.Append(((Button)sender).Text);
        }

        /// <inheritdoc />
        /// <summary>
        /// Para Obter os valores as teclas precionadas
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.NumPad0:
                    textView.Append("0");
                    btn0.Focus();
                    break;
                case Keys.NumPad1:
                    textView.Append("1");
                    btn1.Focus();
                    break;
                case Keys.NumPad2:
                    textView.Append("2");
                    btn2.Focus();
                    break;
                case Keys.NumPad3:
                    textView.Append("3");
                    btn3.Focus();
                    break;
                case Keys.NumPad4:
                    textView.Append("4");
                    btn4.Focus();
                    break;
                case Keys.NumPad5:
                    textView.Append("5");
                    btn5.Focus();
                    break;
                case Keys.NumPad6:
                    textView.Append("6");
                    btn6.Focus();
                    break;
                case Keys.NumPad7:
                    textView.Append("7");
                    btn7.Focus();
                    break;
                case Keys.NumPad8:
                    textView.Append("8");
                    btn8.Focus();
                    break;
                case Keys.NumPad9:
                    textView.Append("9");
                    btn9.Focus();
                    break;
                case Keys.Add:
                    textView.Append("+");
                    btnPlus.Focus();
                    break;
                case Keys.Subtract:
                    textView.Append("-");
                    btnSubtract.Focus();
                    break;
                case Keys.Divide:
                    textView.Append("÷");
                    btnDivide.Focus();
                    break;
                case Keys.Multiply:
                    textView.Append("x");
                        btnMutiply.Focus();
                    break;
                case Keys.Decimal:
                    textView.Append("x");
                    btnDecimal.Focus();
                    break;
                case Keys.Enter:
                    btnEqual.Focus();
                    break;
                case Keys.Escape:
                    textView.Clear();
                    break;
                case Keys.Back:
                    textView.RemoveLastChar();
                    break;
                case Keys.Delete  :
                    textView.RemoveLastChar();
                    break;
                default:
                    break;
            }
            //MessageBox.Show(keyData.ToString());
            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// Apresenta Resultado da Equacao
        /// </summary>
        private  void Equals()
        {
            if(!textView.Text.Contains("="))
                  textView.AppendLine("= " + _compiler.Compile(textView.Text));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Equals();
        }

        private void aboutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var about = new About();
            about.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            textView.RemoveLastChar();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textView.Clear();
        }
    }
}
