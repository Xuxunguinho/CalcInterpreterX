/**********************************************
 *  This software was developed by:
 *  
 *  Júlio José de Andrade Reis
 *  Email: julioreisdev@outlook.com 
 * 
 * OpenSource
 **********************************************/

using System.Diagnostics;

namespace CalcMiniScript
{
    
   

    /// <summary>
    /// Compilador do mini-script
    /// </summary>
    public  class CalcCompiller
    {
        public  static char[] SuportedOperators = { '+', '*', 'x', '-', '%', '/', '÷', '\\', '^' };
       
    /// <summary>
    /// Calcula a equação e retorna o resultado
    /// </summary>
    /// <param name="sourceScript">mini-script("2+2*25/4")</param>
    /// <returns></returns>
      public double Compile(string sourceScript)
        {
                var st = new Stopwatch();
                st.Start();
                sourceScript += " + 0";
                return CompillerExtentions.Execute(sourceScript);
           
        }
    }
}
