using System;
using System.Linq;
using CalcMiniScript;

namespace Demo
{
    public static   class Extensions
    {
        
        /// <summary>
        /// Concatena uma string a uma ja Existente
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="str"></param>
        public static void Append(this TextView obj ,string str)
        {
            obj.Text = obj.Text ?? " ";
            
            if (str.Where(CalcCompiller.SuportedOperators.Contains).Any())
            {
                if (obj.Text.Contains("="))
                {
                    var items = obj.Text.Split('=');
                    //obj.Text = string.Empty;
                    var s =items.Last() + $@" {str} ";
                    obj.Text = string.Empty;
                    obj.Text += s;
                  
                }
                else
                {
                    obj.Text += $@" {str} ";
                }
            }
           
            else
            {
                if (obj.Text.Contains("="))
                {
                    obj.Text = string.Empty;
                    obj.Text += str;
                }
                else
                {
                    obj.Text += str;
                }
            }
            
        }
        /// <summary>
        ///  Adiciona uma nova linha de texto
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="str"></param>
        public static void AppendLine(this TextView obj, string str)
        {
            obj.Text += Environment.NewLine;
            obj.Text += str;
        }
        /// <summary>
        ///  Adiciona Efeito da tecla BackSpace do teclado
        /// </summary>
        /// <param name="obj"></param>
        public static void RemoveLastChar(this TextView obj)
        {
            var length = obj.Text?.Length ?? 0;
            if (length < 1) return;
            if (obj.Text == null) return;
            var remove = obj.Text.Remove(length - 1, 1);
            obj.Text = remove;
        }
        public static void Clear(this TextView obj)
        {
            obj.Text = string.Empty;
        }
    }
}
