using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experteam.BusinessLayer.Helpers
{
    public static class ExStringHelper
    {
        /// <summary>
        /// Valida mediante las funciones de string que el String ngresado no este vacio
        /// </summary>
        /// <param name="strString">string a evaluar</param>
        /// <returns>bool</returns>
        public static bool ValidateNotNullString(string strString = null)
        {
            bool boolResponse = true;

            if (strString == null)
                return false;

            if (string.IsNullOrEmpty(strString.Trim()) || string.IsNullOrWhiteSpace(strString.Trim()) || strString.Trim().Length <= 0 || strString == string.Empty)
                return false;

            return boolResponse;
        }
    }
}
