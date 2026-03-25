using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Common.Exceptions
{
    public class NotFoundException : Exception 
    {
        public NotFoundException(string entidad , object id):base($"{entidad} con el Id {id} no fue encontrado") { }
       




    }
}
