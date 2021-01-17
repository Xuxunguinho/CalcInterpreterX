using System;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            
            var str = new StringBuilder();
            str.AppendLine("Developed By: Júlio José de Andrade Reis");
            str.AppendLine("Email: julioreisdev@outlook.com");

            header.Text = str.ToString();
            
            str = new StringBuilder();
            str.AppendLine("Este algoritmo suporta:");
            str.AppendLine("");
            str.AppendLine("  • Ordem de Precedência dos operadores aritméticos");

            str.AppendLine("  • Seguintes Operaores [/,x,%,\\,^,-,+,]");
            str.AppendLine("");
            str.AppendLine("Este algoritmo ainda nao suporta:");
            str.AppendLine("");
            str.AppendLine("  • Numeros superiores 999^5");
            str.AppendLine("  • Interpretação do caracter de Euler");

            txtAbout.Text = str.ToString();
        }
    }
}
